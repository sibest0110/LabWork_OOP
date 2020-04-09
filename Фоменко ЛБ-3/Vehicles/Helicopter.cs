using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    /// <summary>
    /// Вертолёт
    /// </summary>
    public class Helicopter : VehiclesBase
    {
        /// <summary>
        /// Вертолёт
        /// </summary>
        /// <param name="name">Название вертолёта</param>
        /// <param name="weight">Масса вертолёта в кг</param>
        public Helicopter(string name, double weight)
        {
            Weight = weight;
            //TODO: СПЕЦИАЛЬНО ДЛЯ ДЕМОНСТРАЦИИ ТЕСТА
            //Type = VehiclesTypes.Helicopter;
            Name = name;
        }
        //TODO: XML
        public Helicopter() => Type = VehiclesTypes.Helicopter;

        /// <summary>
        /// Определение расхода топлива
        /// </summary>
        /// <param name="distance">расстояние</param>
        /// <returns></returns>
        public override double FuelCost(double distance)
        {
            Distance = distance;
            return Distance * (Weight / 15000);
        }

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
