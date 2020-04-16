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
        private string _name = "empty name";

        //TODO: (v) XML
        //TODO: (v) Совсем без проверок?
        // Согласен, не кошерно
        /// <summary>
        /// Название ТС
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = (value != null && value.Replace(" ", "") != "") 
                ? value : throw new Exception("Имя не может быть пустым! ");
        }

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

        //TODO: Базовый класс ничего не должен знать о наследниках - этот метод стоит вынести
        /// <summary>
        /// Получение класса ТС по его типу
        /// </summary>
        /// <param name="enumType">Тип ТС по набору VehiclesTypes</param>
        /// <returns></returns>
        public static Type GetClassByType(VehiclesTypes enumType)
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
