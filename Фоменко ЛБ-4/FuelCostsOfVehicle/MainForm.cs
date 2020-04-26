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
    public partial class MainForm : Form
    {
        /// <summary>
        /// Список всех ТС в программе
        /// </summary>
        List<VehiclesBase> _totalListOfVehicles = new List<VehiclesBase> { };


        public MainForm()
        {
            InitializeComponent();

            comboBoxTypesOfVehicles.Items.Add("Car");
            comboBoxTypesOfVehicles.Items.Add("HybridCar");
            comboBoxTypesOfVehicles.Items.Add("Helicopter");

            comboBoxTypesOfVehicles.Text = "-выбрать тип-";
            //dataGridViewMain.Columns.Add("Type", "Тип");
            //dataGridViewMain.Columns.Add("Name", "Название");
            //dataGridViewMain.Columns.Add("Weight", "Масса, кг");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Нажатие на кнопку "Добавить ТС" (AddVehicle)
        /// </summary>
        /// <param name="sender">хороший</param>
        /// <param name="e">вопрос</param>
        private void buttonAddVehicle_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBoxTypesOfVehicles.Text)
                {
                    case "Car":
                    {
                        _totalListOfVehicles.Add(
                            new Car(textBoxNameVehicle.Text,
                            Convert.ToDouble(
                                textBoxWeightVehicle.Text.Replace(".", ","))));
                        break;
                    }
                    case "HybridCar":
                    {
                        _totalListOfVehicles.Add(
                            new HybridCar(textBoxNameVehicle.Text,
                            Convert.ToDouble(
                                textBoxWeightVehicle.Text.Replace(".", ","))));
                        break;
                    }
                    case "Helicopter":
                    {
                        _totalListOfVehicles.Add(
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
                dataGridViewMain.Rows.Add(
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
            }
            catch (Exception ex)
            {
                if (textBoxNameVehicle.Text=="")
                {
                    MessageBox.Show(
                            "Не указано название ТС",
                            "Название транспортного средства",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                }
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


        private double checkWeight()
        {

            try
            {
                return Convert.ToDouble(
                    textBoxWeightVehicle.Text.Replace(".", ","));

            }
            catch (Exception ex)
            {
                textBoxWeightVehicle.Text = "Ошибка!";
                MessageBox.Show("Неверно указана масса ТС!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;
        }


        private void buttonRandVehicle_Click(object sender, EventArgs e)
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
                            $"Автомобиль №{rand.Next(999)}";
                        vehicle = new Car(name, weightCars);
                        break;
                    }
                    case 1:
                    {
                        string name =
                            $"Гибридный автомобиль №{rand.Next(999)}";
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
