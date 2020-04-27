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
    /// Форма для расчёта затрат топлива
    /// </summary>
    public partial class FuelCostForm : Form
    {
        /// <summary>
        /// ТС, для которого рассчитывается расход топлива
        /// </summary>
        IFuelCosts _vehicle;

        public FuelCostForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Форма с ссылкой на ТС, для которого рассматриваются затраты топлива. 
        /// Необходимо использовать этот конструктор.
        /// </summary>
        /// <param name="vehicle"></param>
        public FuelCostForm(IFuelCosts vehicle)
            : this()
        {
            _vehicle = vehicle;

            listBoxInfo.Items.Add(
                $"Тип: {(_vehicle as VehiclesBase).Type}");
            listBoxInfo.Items.Add(
                $"Название: {(_vehicle as VehiclesBase).Name}");
            listBoxInfo.Items.Add(
                $"Масса: {(_vehicle as VehiclesBase).Weight}, кг");

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            double distance = 0;
            try
            {
                if (textBoxDistance.Text != "")
                {
                    distance = Convert.ToDouble(
                    textBoxDistance.Text.Replace(".", ","));
                }
                
                double fuelCost = Math.Round(_vehicle.FuelCost(distance), 2);

                textBoxFuelCost.Text = fuelCost.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Ввод дистанции",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
