using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    /// <summary>
    /// Интерфейс для получения расхода топлива транспортного средства
    /// </summary>
    public interface IFuelCosts
    {
        /// <summary>
        /// Расстояние, которое необходимо преодолеть
        /// </summary>
        double Distance { get; set; }

        /// <summary>
        /// Расход топлива
        /// </summary>
        /// <returns></returns>
        double FuelCost(double distance);
    }
}
