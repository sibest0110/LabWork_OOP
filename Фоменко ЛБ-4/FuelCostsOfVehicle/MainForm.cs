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
            var addVehicleForm = 
                new AddVehicleForm(this, _totalListOfVehicles);

            addVehicleForm.Show();
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
