using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    /// <summary>
    /// Транспортное средство
    /// </summary>
    public abstract class VehiclesBase : IFuelCosts
    {
        public string Name { get; protected set; }

        /// <summary>
        /// Тип транспортного средства
        /// </summary>
        public VehiclesTypes Type { get; protected set; }
            = VehiclesTypes.Undefined;

        private double _distance;
        /// <summary>
        /// Расстояние, которое необходимо преодолеть
        /// </summary>
        public double Distance
        {
            get => _distance;
            set => _distance = (value >= 0) ? value :
                throw new NegativeValueExeption("Расстояние");
        }

        private double _weight;
        /// <summary>
        /// Масса транспортного средства.
        /// </summary>
        public double Weight
        {
            get => _weight;
            set => _weight = (value >= 0) ? value :
                throw new NegativeValueExeption("Масса транспортного средства");
        }


        /// <summary>
        /// Метод рассчёта затрачиваемого топлива
        /// </summary>
        /// <param name="distance">Расстояния, на которое рассчитывается расход</param>
        /// <returns></returns>
        public abstract double FuelCost(double distance);

        /// <summary>
        /// Посигналить. 
        /// Данный метод приведён в качестве иллюстрации того,
        /// что при обращении к объекту как к интерфейсу, 
        /// мы не увидим других, в том числе публичных, методов, 
        /// не приведённых в интерфейсе (инкапсуляция)
        /// </summary>
        public abstract void Beep();
    }
}
