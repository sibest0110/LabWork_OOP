using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Helicopter : VehiclesBase, IFuelCosts
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
        public Helicopter(double weight)
        {
            Weight = weight;
            Type = VehiclesTypes.Helicopter;
        }
        public Helicopter() => Type = VehiclesTypes.Helicopter;


        /// <summary>
        /// Определение расхода топлива
        /// </summary>
        /// <returns></returns>
        public double FuelCost() => Distance * (Weight / 15000);


        /// <summary>
        /// Издать звуки вертолёта
        /// </summary>
        public override void Beep()
        {
            Console.Beep(500, 200);
            Console.Beep(500, 200);
            Console.Beep(500, 200);
            Console.Beep(500, 200);
        }
    }
}
