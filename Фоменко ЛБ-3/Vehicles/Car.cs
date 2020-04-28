using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    [Serializable]
    /// <summary>
    /// Автомобиль с ДВС
    /// </summary>
    public class Car : VehiclesBase
    {
        /// <summary>
        /// Автомобиль с ДВС
        /// </summary>
        /// <param name="name">Название автомобиля</param>
        /// <param name="weight">Масса автомобиля в кг</param>
        public Car(string name, double weight)
        {
            Weight = weight;
            Type = VehiclesTypes.Car;
            Name = name;
        }
        //TODO: (v) XML
        /// <summary>
        /// Конструктор по умолчанию. Присваивается только тип ТС.
        /// </summary>
        public Car() => Type = VehiclesTypes.Car;


        /// <summary>
        /// Определение расхода топлива
        /// </summary>
        /// <param name="distance">расстояние</param>
        /// <returns></returns>
        public override double FuelCost(double distance)
        {
            Distance = distance;
            return Distance * (Weight / 20000);
        }


        /// <summary>
        /// Посигналить как обычная машина
        /// </summary>
        public override void Beep()
        {
            Console.Beep(500, 800);
        }
    }
}
