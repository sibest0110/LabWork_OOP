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
        /// Конструктор по умолчанию
        /// </summary>
        public AddVehicleForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор с сылкой на главную форму и полный список ТС
        /// </summary>
        /// <param name="totalVehicleList">Полный список ТС</param>
        public AddVehicleForm(List<VehiclesBase> totalVehicleList)
            : this()
        {
            _totalVehicleList = totalVehicleList;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                _totalVehicleList.Add(
                    CreateVehicleByString(
                        comboBoxTypesOfVehicles.Text, 
                        textBoxNameVehicle.Text, 
                        textBoxWeightVehicle.Text));

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
        /// Создание ТС по строковым параметрам
        /// </summary>
        /// <param name="type">Тип ТС</param>
        /// <param name="name">Название ТС</param>
        /// <param name="weight">Масса ТС в кг</param>
        /// <returns></returns>
        public static VehiclesBase CreateVehicleByString(string type, string name, string weight)
        {
            switch (type)
            {
                case "Car":
                {
                    return new Car(name, Convert.ToDouble(
                            weight.Replace(".", ",")));
                }
                case "HybridCar":
                {
                    return new HybridCar(name, Convert.ToDouble(
                            weight.Replace(".", ",")));
                }
                case "Helicopter":
                {
                    return new Helicopter(name, Convert.ToDouble(
                            weight.Replace(".", ",")));
                }
                default:
                {
                    throw new Exception("Не указан тип ТС");
                }
            }
        }
    }
}
