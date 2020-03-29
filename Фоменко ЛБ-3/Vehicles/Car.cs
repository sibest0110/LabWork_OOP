using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : VehiclesBase, IFuelCosts
    {
        private double _distance;
        /// <summary>
        /// Расстояние, которое необходимо преодолеть
        /// </summary>
        public double Distance
        {
            get => _distance;
            set
            {
                _distance = (value >= 0) ? value :
                    throw new NegativeValueExeption("Расстояние");
            }
        }




        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="weight">Масса автомобиля в кг.</param>
        public Car(double weight)
        {
            Weight = weight;
            Type = VehiclesTypes.Car;
        }
        public Car() => Type = VehiclesTypes.Car;


        /// <summary>
        /// Определение расхода топлива
        /// </summary>
        /// <returns></returns>
        public double FuelCost() => Distance * (Weight / 20000);


        /// <summary>
        /// Посигналить как обычная машина
        /// </summary>
        public override void Beep()
        {
            Console.Beep(500, 800);
        }
    }
}
