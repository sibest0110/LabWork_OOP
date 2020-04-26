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
    public partial class AddVehicleForm : Form
    {
        private List<VehiclesBase> _totalVehicleList;

        private MainForm _mainForm;

        public AddVehicleForm()
        {
            InitializeComponent();
        }

        public AddVehicleForm(
            MainForm mainForm, List<VehiclesBase> totalVehicleList)
        {
            _totalVehicleList = totalVehicleList;
            _mainForm = mainForm;
            InitializeComponent();
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

                comboBoxTypesOfVehicles.Text = "-выбрать тип-";
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
                if (textBoxWeightVehicle.Text == "")
                {
                    MessageBox.Show(
                            "Не указана масса ТС!",
                            "Масса транспортного средства",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(
                            $"{ex.Message}",
                            "ИСКЛЮЧЕНИИЕ!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
            }
        }

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
                    MessageBox.Show(
                        "Не указан тип ТС!",
                        "Тип транспортного средства",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    throw new Exception("Не указан тип ТС");
                }
            }
        }
    }
}
