using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class HybridCar: VehiclesBase, IFuelCosts
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
        public HybridCar(double weight)
        {
            Weight = weight;
            Type = VehiclesTypes.HybridCar;
        }
        public HybridCar() => Type = VehiclesTypes.HybridCar;


        /// <summary>
        /// Определение расхода топлива
        /// </summary>
        /// <returns></returns>
        public double FuelCost() => Distance * (Weight / 30000);



        /// <summary>
        /// Издать звуки гибридной машины
        /// </summary>
        public override void Beep()
        {
            Console.Beep(700, 800);
        }
    }
}
