using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class VehiclesBase
    {
        /// <summary>
        /// Тип транспортного средства
        /// </summary>
        public VehiclesTypes Type { get; protected set; } 
            = VehiclesTypes.Undefined;

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
        /// Посигналить
        /// </summary>
        public abstract void Beep();
    }
}
