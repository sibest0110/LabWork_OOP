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
        private List<VehiclesBase> _totalVehicleList;

        /// <summary>
        /// Список, содержащий результат поиска
        /// </summary>
        private List<VehiclesBase> _searchVehicleListGlobal;

        /// <summary>
        /// Локальный список с результатами поиска
        /// </summary>
        private List<VehiclesBase> _searchVehicleListLocal;

        /// <summary>
        /// Словарь соответствий checkbox и поля задания соответствующего
        /// параметра ТС (Заполняется в конструкторе по-умолчанию).
        /// </summary>
        private Dictionary<CheckBox, Control> _controlsDictionary
            = new Dictionary<CheckBox, Control>() { };


        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public FindForm()
        {
            InitializeComponent();


            _controlsDictionary = new Dictionary<CheckBox, Control>
            {
                { checkBoxType, comboBoxType },
                { checkBoxName, textBoxName },
                { checkBoxWeight, textBoxWeight }
            };
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


        //TODO: (v) Применение "_controlsDictionary"

        //TODO: (v) RSDN
        private void CheckBoxType_CheckedChanged(object sender, EventArgs e)
        {
            SwitchConditionByCheckBox(sender);
        }

        private void CheckBoxName_CheckedChanged(object sender, EventArgs e)
        {
            SwitchConditionByCheckBox(sender);
        }

        private void CheckBoxWeight_CheckedChanged(object sender, EventArgs e)
        {
            SwitchConditionByCheckBox(sender);
        }

        /// <summary>
        /// Изменения состояния возможности ввода параметра ТС 
        /// в зависимости от состояния соответствующего CheckBox.
        /// </summary>
        /// <param name="sender">CheckBox, отвечающий за доступ к вводу параметра ТС</param>
        private void SwitchConditionByCheckBox(object sender)
        {
            var localCheckBox = (CheckBox)sender;

            _controlsDictionary[localCheckBox].Enabled
                = localCheckBox.Checked;
        }

        //TODO: (v) RSDN
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //TODO: (v) RSDN
        private void ButtonFind_Click(object sender, EventArgs e)
        {
            try
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
                    Program.CheckWeight(textBoxWeight);

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
            catch (Exception ex)
            {
                MessageBox.Show(
                            $"{ex.Message}",
                            "Внимание",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
            }
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
