using System;
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
        List<VehiclesBase> _totalListOfVehicles = new List<VehiclesBase> { };


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
        /// Обновляет содержимое DataGridView
        /// </summary>
        private void RefreshDataGrid()
        {
            dataGridViewMain.Rows.Clear();
            foreach (var vehicle in _totalListOfVehicles)
            {
                dataGridViewMain.Rows.Add(
                    vehicle.Type,
                    vehicle.Name,
                    vehicle.Weight);
            }
        }

        private void dataGridViewMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Чтобы не ломать при двойном клике колесом или ПКМ
            dataGridViewMain.Rows
                [dataGridViewMain.SelectedCells[0].RowIndex]
                .Selected = true;
        }

        private void dataGridViewMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Чтобы не ломать при двойном клике колесом или ПКМ
            dataGridViewMain.Rows
                [dataGridViewMain.SelectedCells[0].RowIndex]
                .Selected = true;

            GetFuelCost();
        }

        /// <summary>
        /// Расчёт расхода топлива по выделенной строке
        /// </summary>
        private void GetFuelCost()
        {
            //Проверка на выделение пустой строки
            try
            {
                string typeCell = Convert.ToString(
                    dataGridViewMain.SelectedRows[0].Cells[0].Value);
                string nameCell = Convert.ToString(
                    dataGridViewMain.SelectedRows[0].Cells[1].Value);
                string weightCell = Convert.ToString(
                    dataGridViewMain.SelectedRows[0].Cells[2].Value);

                if (typeCell == "" && nameCell == "" && weightCell == "")
                {
                    return;
                }

                var fuelCostForm = new FuelCostForm(FindVehicleBySelectedRow());
                fuelCostForm.Show();
            }
            catch { }
        }

        /// <summary>
        /// Поиск ТС по выделенной строке
        /// </summary>
        /// <returns></returns>
        private VehiclesBase FindVehicleBySelectedRow()
        {
            foreach (var vehicle in _totalListOfVehicles)
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


        private void toolStripButtonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ExternalInteraction.ReadTXT("readme\\help.txt"),
                "Помощь",
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }

        private void toolStripButtonAddVehicle_Click(object sender, EventArgs e)
        {
            var addVehicleForm =
                new AddVehicleForm(this, _totalListOfVehicles);

            addVehicleForm.Show();
        }

        private void toolStripButtonRemoveVehicle_Click(object sender, EventArgs e)
        {
            int counter = 0;
            var listToRemove = new List<VehiclesBase> { };
            try
            {
                foreach (DataGridViewRow delRow
                    in dataGridViewMain.SelectedRows)
                {
                    counter++;
                    dataGridViewMain.Rows.Remove(delRow);

                    foreach (VehiclesBase vehicle in _totalListOfVehicles)
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
                    _totalListOfVehicles.Remove(remVehicle);
                }

                MessageBox.Show($"Удалено строк: {counter}",
                    "Удаление строк",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch { }
        }

        private void toolStripButtonUpdate_Click(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            FindForm findForm =
                new FindForm(this, _totalListOfVehicles);

            findForm.Show();
        }

        private void toolStripButtonExport_Click(object sender, EventArgs e)
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

        private void toolStripButtonImport_Click(object sender, EventArgs e)
        {
            try
            {
                _totalListOfVehicles =
                    ExternalInteraction.DownLoadDataBase();
                RefreshDataGrid();
            }
            catch { }
        }

        private void toolStripButtonRandom_Click(object sender, EventArgs e)
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
                _totalListOfVehicles.Add(vehicle);
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
