using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    /// <summary>
    /// Перечень типов ТС
    /// </summary>
    public enum VehiclesTypes
    {
        Car,
        HybridCar,
        Helicopter,
        Undefined
    }

    public static class TypesOfVevicles
    {
        /// <summary>
        /// Получение класса ТС по его типу
        /// </summary>
        /// <param name="enumType">Тип ТС по набору VehiclesTypes</param>
        /// <returns></returns>
        public static Type GetClassByType(this VehiclesTypes enumType)
        {
            switch (enumType)
            {
                case VehiclesTypes.Car:
                {
                    return typeof(Car);
                }
                case VehiclesTypes.HybridCar:
                {
                    return typeof(HybridCar);
                }
                case VehiclesTypes.Helicopter:
                {
                    return typeof(Helicopter);
                }
                default:
                {
                    throw new ArgumentException("Передан несуществующий тип ТС!");
                }
            }
        }
    }
}
