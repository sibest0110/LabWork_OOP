using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    [Serializable]
    /// <summary>
    /// Гибридный автомобиль
    /// </summary>
    public class HybridCar: VehiclesBase
    {
        /// <summary>
        /// Гибридный автомобиль
        /// </summary>
        /// <param name="name">Название автомобиля</param>
        /// <param name="weight">Масса автомобиля в кг</param>
        public HybridCar(string name, double weight)
        {
            Weight = weight;
            Type = VehiclesTypes.HybridCar;
            Name = name;
        }

        /// <summary>
        /// Конструктор по-умолчанию HybridCar
        /// </summary>
        public HybridCar()
        {
            Type = VehiclesTypes.HybridCar;
        }

        /// <summary>
        /// Определение расхода топлива
        /// </summary>
        /// <param name="distance">расстояние</param>
        /// <returns></returns>
        public override double FuelCost(double distance)
        {
            Distance = distance;
            return Distance * (Weight / 30000);
        }


        /// <summary>
        /// Издать звуки гибридной машины
        /// </summary>
        public override void Beep()
        {
            Console.Beep(700, 800);
        }
    }
}
