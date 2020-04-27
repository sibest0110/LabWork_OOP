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
    /// Форма для поиска ТС
    /// </summary>
    public partial class FindForm : Form
    {
        /// <summary>
        /// Полный список ТС
        /// </summary>
        List<VehiclesBase> _totalVehicleList;

        /// <summary>
        /// Список, содержащий результат поиска
        /// </summary>
        List<VehiclesBase> _searchVehicleList;

        /// <summary>
        /// Главная форма
        /// </summary>
        MainForm _mainForm;

        public FindForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор с сылкой на главную форму и полный список ТС
        /// </summary>
        /// <param name="mainForm">Главная форма</param>
        /// <param name="totalVehicleList">Полный список ТС</param>
        public FindForm(MainForm mainForm,
            List<VehiclesBase> totalVehicleList)
            : this()
        {
            _totalVehicleList = totalVehicleList;
            _searchVehicleList = CloneVehicleList(_totalVehicleList);
            _mainForm = mainForm;
        }

        /// <summary>
        /// Клонирование списка ТС
        /// </summary>
        /// <param name="original">Исходный список</param>
        /// <returns></returns>
        private List<VehiclesBase> CloneVehicleList(List<VehiclesBase> original)
        {
            List<VehiclesBase> clone = new List<VehiclesBase> { };

            foreach (var vehicle in original)
            {
                clone.Add(vehicle);
            }

            return clone;
        }

        private void checkBoxType_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxType.Checked)
            {
                comboBoxType.Enabled = true;
            }
            else
            {
                comboBoxType.Enabled = false;
            }
        }

        private void checkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxName.Checked)
            {
                textBoxName.Enabled = true;
            }
            else
            {
                textBoxName.Enabled = false;
            }
        }

        private void checkBoxWeight_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWeight.Checked)
            {
                textBoxWeight.Enabled = true;
            }
            else
            {
                textBoxWeight.Enabled = false;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {

            if (checkBoxType.Checked)
            {
                _searchVehicleList = FindVehiclesByType(comboBoxType.Text);
            }
            if (checkBoxName.Checked)
            {
                _searchVehicleList = FindVehiclesByName(textBoxName.Text);
            }
            if (checkBoxWeight.Checked)
            {
                _searchVehicleList = FindVehiclesByWeight(
                    Convert.ToDouble(textBoxWeight.Text.Replace(".", ",")));
            }

            _mainForm.dataGridViewMain.Rows.Clear();
            foreach (var vehicle in _searchVehicleList)
            {
                _mainForm.dataGridViewMain.Rows.Add(
                    vehicle.Type,
                    vehicle.Name,
                    vehicle.Weight);
            }
            MessageBox.Show(
                $"Найдено транспортных средств: {_searchVehicleList.Count}",
                "Результат поиска",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
        }

        /// <summary>
        /// Список ТС, удовлетворяющих условию по типу
        /// </summary>
        /// <param name="type">Тип ТС</param>
        /// <returns></returns>
        private List<VehiclesBase> FindVehiclesByType(string type)
        {
            var findingList = CloneVehicleList(_searchVehicleList);
            foreach (var vehicle in _searchVehicleList)
            {
                if (Convert.ToString(vehicle.Type) != type)
                {
                    findingList.Remove(vehicle);
                }
            }
            return findingList;
        }

        /// <summary>
        /// Список ТС, удовлетворяющих условию по названию
        /// </summary>
        /// <param name="name">Название</param>
        /// <returns></returns>
        private List<VehiclesBase> FindVehiclesByName(string name)
        {
            var findingList = CloneVehicleList(_searchVehicleList);
            foreach (var vehicle in _searchVehicleList)
            {
                if (vehicle.Name != name)
                {
                    findingList.Remove(vehicle);
                }
            }
            return findingList;
        }

        /// <summary>
        /// Список ТС, удовлетворяющих условию по массе
        /// </summary>
        /// <param name="weight">Масса, кг</param>
        /// <returns></returns>
        private List<VehiclesBase> FindVehiclesByWeight(double weight)
        {
            var findingList = CloneVehicleList(_searchVehicleList);
            foreach (var vehicle in _searchVehicleList)
            {
                if (vehicle.Weight != weight)
                {
                    findingList.Remove(vehicle);
                }
            }
            return findingList;
        }
    }
}
