using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicles;

namespace FuelCostsOfVehicle
{
    /// <summary>
    /// Основная (главная) форма
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список всех ТС в программе
        /// </summary>
        private List<VehiclesBase> _totalVehicleList
            = new List<VehiclesBase> { };

        /// <summary>
        /// Список ТС, полученный в результате поиска
        /// При обращении к полю не клонируется глобальный список в данный список
        /// </summary>
        private List<VehiclesBase> _searchVehicleList =
            new List<VehiclesBase> { };


        public MainForm()
        {
            InitializeComponent();

#if DEBUG
            toolStripButtonRandom.Visible = true;
#else
            toolStripButtonRandom.Visible = false;
#endif

        }

        /// <summary>
        /// Обновляет содержимое DataGridViewMain содержимым vehicleList
        /// </summary>
        /// <param name="vehicleList">Источник данных для DataGridViewMain</param>
        private void RefreshDataGrid(List<VehiclesBase> vehicleList)
        {
            dataGridViewMain.Rows.Clear();
            foreach (var vehicle in vehicleList)
            {
                dataGridViewMain.Rows.Add(
                    vehicle.Type,
                    vehicle.Name,
                    vehicle.Weight);
            }
        }


        private void DataGridViewMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Чтобы не ломать при двойном клике колесом или ПКМ
            dataGridViewMain.Rows
                [dataGridViewMain.SelectedCells[0].RowIndex]
                .Selected = true;
        }

        private void DataGridViewMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewMain_CellClick(sender, e);

            GetFuelCost();
        }

        /// <summary>
        /// Расчёт расхода топлива по выделенной строке
        /// </summary>
        private void GetFuelCost()
        {
            string typeCell = Convert.ToString(
                dataGridViewMain.SelectedRows[0].Cells[0].Value);
            string nameCell = Convert.ToString(
                dataGridViewMain.SelectedRows[0].Cells[1].Value);
            string weightCell = Convert.ToString(
                dataGridViewMain.SelectedRows[0].Cells[2].Value);

            //Проверка на выделение пустой строки
            if (typeCell == "" && nameCell == "" && weightCell == "")
            {
                return;
            }

            var fuelCostForm = new FuelCostForm(FindVehicleBySelectedRow());
            fuelCostForm.Show();
            //TODO: (v) wat? (был ненужный try catch)
        }

        /// <summary>
        /// Поиск ТС по выделенной строке
        /// </summary>
        /// <returns></returns>
        private VehiclesBase FindVehicleBySelectedRow()
        {
            foreach (var vehicle in _totalVehicleList)
            {
                if (Convert.ToString(vehicle.Type) == Convert.ToString(
                    dataGridViewMain.SelectedRows[0].Cells[0].Value) &&
                    Convert.ToString(vehicle.Name) == Convert.ToString(
                        dataGridViewMain.SelectedRows[0].Cells[1].Value) &&
                    Convert.ToString(vehicle.Weight) == Convert.ToString(
                        dataGridViewMain.SelectedRows[0].Cells[2].Value))
                {
                    return vehicle;
                }
            }
            throw new Exception(
                    "Не найдено ТС. " +
                    "Ошибка в базе данных, срочно закройте программу!");
        }


        private void ToolStripButtonHelp_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(ExternalInteraction.ReadTXT("readme\\help.txt"),
                    "Помощь",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Question);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Помощь",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Непредвиденная ошибка!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ToolStripButtonAddVehicle_Click(object sender, EventArgs e)
        {
            var addVehicleForm =
                new AddVehicleForm(_totalVehicleList);

            addVehicleForm.FormClosed += AddVehicleForm_FormClosed;

            addVehicleForm.ShowDialog();
        }

        private void AddVehicleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshDataGrid(_totalVehicleList);
        }

        private void ToolStripButtonRemoveVehicle_Click(object sender, EventArgs e)
        {
            int counter = 0;
            var listToRemove = new List<VehiclesBase> { };

            // Если выделено всё (в том числе и последняя пустая строка)
            if (dataGridViewMain.SelectedRows.Count > _totalVehicleList.Count)
            {
                counter = _totalVehicleList.Count;
                dataGridViewMain.Rows.Clear();
                _totalVehicleList.Clear();
            }

            foreach (DataGridViewRow delRow
                in dataGridViewMain.SelectedRows)
            {
                counter++;

                dataGridViewMain.Rows.Remove(delRow);

                foreach (VehiclesBase vehicle in _totalVehicleList)
                {
                    if (Convert.ToString(
                        vehicle.Type) == Convert.ToString(
                                        delRow.Cells[0].Value) &&
                        Convert.ToString(
                            vehicle.Name) == Convert.ToString(
                                        delRow.Cells[1].Value) &&
                        Convert.ToString(
                            vehicle.Weight) == Convert.ToString(
                                        delRow.Cells[2].Value))
                    {
                        listToRemove.Add(vehicle);
                    }
                }
            }
            foreach (var remVehicle in listToRemove)
            {
                _totalVehicleList.Remove(remVehicle);
            }

            // Чтобы не бесило сообщение про 0 удалённых строк при пустом датагриде
            if (counter != 0)
            {
                MessageBox.Show($"Удалено строк: {counter}",
                    "Удаление строк",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ToolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(_totalVehicleList);
        }

        private void ToolStripButtonSearch_Click(object sender, EventArgs e)
        {
            FindForm findForm =
                new FindForm(_totalVehicleList, _searchVehicleList);

            findForm.FormClosed += FindForm_FormClosed;
            findForm.ShowDialog();
        }

        private void FindForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RefreshDataGrid(_searchVehicleList);
            if (dataGridViewMain.Rows.Count == 1)
            {
                RefreshDataGrid(_totalVehicleList);
            }
        }

        private void ToolStripButtonExport_Click(object sender, EventArgs e)
        {
            List<VehiclesBase> exportList = new List<VehiclesBase> { };

            foreach (DataGridViewRow row in dataGridViewMain.Rows)
            {
                if (row.Cells["TypeOfVehicle"].Value != null)
                {
                    exportList.Add(
                        AddVehicleForm.CreateVehicleByString(
                        Convert.ToString(row.Cells["TypeOfVehicle"].Value),
                        Convert.ToString(row.Cells["NameOfVehicle"].Value),
                        Convert.ToString(row.Cells["WeightOfVehicle"].Value)));
                }
            }

            if (exportList.Count == 0)
            {
                MessageBox.Show("Невозможно выгрузить пустую базу данных",
                    "Выгрузка БД",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            ExternalInteraction.UpLoadDataBase(exportList);
        }

        private void ToolStripButtonImport_Click(object sender, EventArgs e)
        {
            try
            {
                _totalVehicleList =
                    ExternalInteraction.DownLoadDataBase();
                RefreshDataGrid(_totalVehicleList);
            }
            //TODO: (v) wat? (был пустой catch)
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Импорт БД",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Невозможно загрузить файл",
                    "Импорт БД",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ToolStripButtonRandom_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewMain.AllowUserToAddRows = true;
                Random rand = new Random();


                var weightCars = rand.Next(600, 2000);
                var weightHelicopter = rand.Next(5000, 10000);
                VehiclesBase vehicle = null;

                var randomNumber = rand.Next(0, 3);
                switch (randomNumber)
                {
                    case 0:
                    {
                        string name =
                            $"Авто №{rand.Next(999)}";
                        vehicle = new Car(name, weightCars);
                        break;
                    }
                    case 1:
                    {
                        string name =
                            $"Гибрид №{rand.Next(999)}";
                        vehicle =
                            new HybridCar(name, weightCars);
                        break;
                    }
                    case 2:
                    {
                        string name =
                            $"Вертолёт №{rand.Next(999)}";
                        vehicle =
                            new Helicopter(name, weightHelicopter);
                        break;
                    }
                }
                _totalVehicleList.Add(vehicle);
                dataGridViewMain.Rows.Add
                    (vehicle.Type, vehicle.Name, vehicle.Weight);
            }
            catch
            {
                MessageBox.Show("Не получилось получить случайное ТС");
            }
        }


    }
}
