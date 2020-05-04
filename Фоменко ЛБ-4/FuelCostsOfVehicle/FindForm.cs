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
        //TODO: (v) RSDN
        /// <summary>
        /// Полный список ТС
        /// </summary>
        private List<VehiclesBase> _totalVehicleList;

        /// <summary>
        /// Список, содержащий результат поиска
        /// </summary>
<<<<<<< HEAD
        private List<VehiclesBase> _searchVehicleListGlobal;
=======
        private List<VehiclesBase> _searchVehicleList;
>>>>>>> ReplaceIcoLab4

        /// <summary>
        /// Локальный список с результатами поиска
        /// </summary>
        private List<VehiclesBase> _searchVehicleListLocal;

        //TODO: (v) Отстой (Была ссылка на MainForm)

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public FindForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор с сылкой на главную форму и полный список ТС
        /// </summary>
        /// <param name="mainForm">Главная форма</param>
        /// <param name="totalVehicleList">Полный список ТС</param>
        public FindForm(List<VehiclesBase> totalVehicleList,
            List<VehiclesBase> searchVehicleList)
            : this()
        {
            _totalVehicleList = totalVehicleList;

            _searchVehicleListGlobal = searchVehicleList;
            _searchVehicleListGlobal.Clear();

            _searchVehicleListLocal = 
                Program.CloneVehicleList(_totalVehicleList);
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
                _searchVehicleListLocal = FindVehiclesByType(comboBoxType.Text);
            }
            if (checkBoxName.Checked)
            {
                _searchVehicleListLocal = FindVehiclesByName(textBoxName.Text);
            }
            if (checkBoxWeight.Checked)
            {
                _searchVehicleListLocal = FindVehiclesByWeight(
                    Convert.ToDouble(textBoxWeight.Text.Replace(".", ",")));
            }


            _searchVehicleListLocal.ForEach(_searchVehicleListGlobal.Add);


            MessageBox.Show(
                $"Найдено транспортных средств: {_searchVehicleListGlobal.Count}",
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
            var findingList = Program.CloneVehicleList(_searchVehicleListLocal);
            foreach (var vehicle in _searchVehicleListLocal)
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
            var findingList = Program.CloneVehicleList(_searchVehicleListLocal);
            foreach (var vehicle in _searchVehicleListLocal)
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
            var findingList = Program.CloneVehicleList(_searchVehicleListLocal);
            foreach (var vehicle in _searchVehicleListLocal)
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
