using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;
using System.Reflection;

namespace ConsoleTests
{
    /// <summary>
    /// Класс ввода/вывода информации через консоль, 
    /// связанной с бизнес логикой программы
    /// </summary>
    public static class IO
    {
        /// <summary>
        /// Создание транспортного средства
        /// </summary>
        /// <param name="enumType">Тип ТС</param>
        /// <returns></returns>
        public static VehiclesBase CreateVehicle(VehiclesTypes enumType)
        {
            Console.WriteLine($"Выбранный тип ТС - {enumType}");

            Type type = VehiclesBase.GetClassByType(enumType);


            var vehicle = (Activator.CreateInstance(type) as VehiclesBase);

            var settingsParams = new List<Action>
            {
                //TODO зачем кастить, если это итак vehicleBase?
                SetName(vehicle as VehiclesBase),
                SetWeight(vehicle as VehiclesBase),
                SetDistance(vehicle as VehiclesBase)
            };

            settingsParams.ForEach(SetParam);

            return vehicle;
        }

        /// <summary>
        /// Задание параметра в бесконечном цикле проверки
        /// </summary>
        /// <param name="enterAction">Action, определяющий какой параметр задавать</param>
        private static void SetParam(Action enterAction)
        {
            while (true)
            {
                try
                {
                    enterAction.Invoke();
                    return;
                }
                catch (Exception ex)
                {
                    Program.ColorOutput($"Исключение: {ex.Message}", ConsoleColor.Red);
                    Console.WriteLine($"Повторите ввод:\n");
                }
            }
        }

        /// <summary>
        /// Action для ввода названия
        /// </summary>
        /// <param name="vehicle">Транспортное средство</param>
        /// <returns></returns>
        private static Action SetName(VehiclesBase vehicle)
        {
            return new Action(() =>
            {
                Console.Write("Название ТС: ");
                vehicle.Name = Console.ReadLine();
            });
        }

        /// <summary>
        /// Action для ввода массы ТС
        /// </summary>
        /// <param name="vehicle">Транспортное средство</param>
        /// <returns></returns>
        private static Action SetWeight(VehiclesBase vehicle)
        {
            return new Action(() =>
            {
                Console.Write("Масса, кг: ");
                vehicle.Weight = double.Parse(Console.ReadLine());
            });
        }

        /// <summary>
        /// Action для ввода дистанции
        /// </summary>
        /// <param name="vehicle">Транспортное средство</param>
        /// <returns></returns>
        private static Action SetDistance(VehiclesBase vehicle)
        {
            return new Action(() =>
            {
                Console.Write("Дистанция, км: ");
                vehicle.Distance = (double.Parse(Console.ReadLine()));
            });
        }
    }
}
