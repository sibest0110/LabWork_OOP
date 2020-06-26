using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicles;

namespace FuelCostsOfVehicle
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Клонирование списка ТС
        /// </summary>
        /// <param name="original">Исходный список</param>
        /// <returns></returns>
        public static List<VehiclesBase> CloneVehicleList(List<VehiclesBase> original)
        {
            List<VehiclesBase> clone = new List<VehiclesBase> { };

            foreach (var vehicle in original)
            {
                clone.Add(vehicle);
            }

            return clone;
        }

        /// <summary>
        /// Проверка корректности ввода массы ТС
        /// </summary>
        /// <param name="weight">Объект Control, содержащий значение Массы ТС</param>
        public static void CheckWeight(Control weight)
        {
            try
            {
                Convert.ToDouble(weight.Text);
            }
            catch
            {
                throw new Exception("Неверно указана масса ТС. Необходимо ввести число");
            }
        }
    }
}
