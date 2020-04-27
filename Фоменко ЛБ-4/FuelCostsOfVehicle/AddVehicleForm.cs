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
    /// Форма для добавления ТС
    /// </summary>
    public partial class AddVehicleForm : Form
    {
        /// <summary>
        /// Полный список ТС
        /// </summary>
        private List<VehiclesBase> _totalVehicleList;

        /// <summary>
        /// Главная форма
        /// </summary>
        private MainForm _mainForm;

        public AddVehicleForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор с сылкой на главную форму и полный список ТС
        /// </summary>
        /// <param name="mainForm">Главная форма</param>
        /// <param name="totalVehicleList">Полный список ТС</param>
        public AddVehicleForm(
            MainForm mainForm, List<VehiclesBase> totalVehicleList)
            :this()
        {
            _totalVehicleList = totalVehicleList;
            _mainForm = mainForm;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                AddCreatedVehicleInTotalList();
                
                _mainForm.dataGridViewMain.Rows.Add(
                    comboBoxTypesOfVehicles.Text,
                    textBoxNameVehicle.Text,
                    textBoxWeightVehicle.Text);

                textBoxNameVehicle.Text = "";
                textBoxWeightVehicle.Text = "";

                MessageBox.Show("Транспортное средство добавлено!",
                    "Добавление ТС",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                switch (MessageBox.Show("Добавить ещё одно ТС?", "Добавление ТС",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
                {
                    case DialogResult.No:
                    {
                        this.Close();
                        break;
                    }
                }
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
        /// Добавить введённое ТС в глобальный список
        /// </summary>
        private void AddCreatedVehicleInTotalList()
        {
            switch (comboBoxTypesOfVehicles.Text)
            {
                case "Car":
                {
                    _totalVehicleList.Add(
                        new Car(textBoxNameVehicle.Text,
                        Convert.ToDouble(
                            textBoxWeightVehicle.Text.Replace(".", ","))));
                    break;
                }
                case "HybridCar":
                {
                    _totalVehicleList.Add(
                        new HybridCar(textBoxNameVehicle.Text,
                        Convert.ToDouble(
                            textBoxWeightVehicle.Text.Replace(".", ","))));
                    break;
                }
                case "Helicopter":
                {
                    _totalVehicleList.Add(
                        new Helicopter(textBoxNameVehicle.Text,
                        Convert.ToDouble(
                            textBoxWeightVehicle.Text.Replace(".", ","))));
                    break;
                }
                default:
                {
                    throw new Exception("Не указан тип ТС");
                }
            }
        }
    }
}
