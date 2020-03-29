using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;
using static System.Console;
using System.Reflection;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadKey();
            TestsForVehicles();


            WriteLine($"Демонстрация работы бизнес логики");
            //TODO: В следующей редакции реализовать ввод через консоль
            var vehicles = new List<IFuelCosts>
            {
                new Car("Солярис", 900),
                new HybridCar("Приус", 900),
                new Helicopter("OHDUDE", 4000)
            };

            foreach (IFuelCosts veh in vehicles)
            {
                WriteLine(
                    $"{(veh as VehiclesBase).Name} потратит" +
                    $" {veh.FuelCost(100)} литров топлива " +
                    $"чтобы преодалеть {veh.Distance} км.");
            }




            ReadKey();

        }




        private static void TestsForVehicles()
        {
            WriteLine($"Запущен тест Транспортных средств\n");

            WriteLine($"Информация по свойствам:" +
                $"\nName /string/ - на данный момент ограничений нет" +
                $"\nType /enum.VehiclesTypes/ - должен соответствовать соответствующему классу" +
                $"\nWeight /double/ - должна быть не отрицательная" +
                $"\nDistance /double/ - должна быть не отрицательная");


            var typesOfVehicles = new List<Type>
            {
                typeof(Car),
                typeof(HybridCar),
                typeof(Helicopter)
            };

            ColorOutput($"\nПроверка Type каждого класса наследника:\n", ConsoleColor.Yellow);
            typesOfVehicles.ForEach(TestVehiclesType);


            ColorOutput($"\nПроверка ввода массы ТС и дистанции для ТС:\n", ConsoleColor.Yellow);
            typesOfVehicles.ForEach(TestWeightAndDistance);

        }

        /// <summary>
        /// Проверка соответствия типов ТС их классу
        /// </summary>
        /// <param name="typeOfClassVehicles">Проверяемый класс</param>
        private static void TestVehiclesType(Type typeOfClassVehicles)
        {
            if (typeOfClassVehicles is null)
            {
                throw new ArgumentNullException(nameof(typeOfClassVehicles));
            }

            WriteLine($"- Класс {typeOfClassVehicles}:");


            //получаем конструкторы
            ConstructorInfo defCons =
                typeOfClassVehicles.GetConstructor(new Type[] { });

            ConstructorInfo paramCons = typeOfClassVehicles.GetConstructor(
                new Type[] { typeof(string), typeof(double) });


            //вызываем конструторы
            var defVehicle = defCons.Invoke(
                new object[] { });
            var paramVehicle = paramCons.Invoke(
                new object[] { "Название ТС", 1000 });

            var nameOfClass = typeOfClassVehicles.ToString().Split('.');

            Write($"Свойство Type = {(defVehicle as VehiclesBase).Type} " +
                $"(конструктор по умолчанию)");
            if (nameOfClass[nameOfClass.Length - 1]
                == (defVehicle as VehiclesBase).Type.ToString())
            {
                ColorOutput($"\t OK\n", ConsoleColor.Green);
            }
            else
            {
                ColorOutput($"\t Fail\n", ConsoleColor.Red);
            }

            Write($"Свойство Type = {(paramVehicle as VehiclesBase).Type} " +
                $"(конструктор с параметрами)");
            if (nameOfClass[nameOfClass.Length - 1]
                == (paramVehicle as VehiclesBase).Type.ToString())
            {
                ColorOutput($"\t OK\n", ConsoleColor.Green);
            }
            else
            {
                ColorOutput($"\t Fail\n", ConsoleColor.Red);
            }
            WriteLine();
        }

        private static void TestWeightAndDistance(Type typeOfClassVehicles)
        {
            WriteLine($"- Класс {typeOfClassVehicles}:");


            // Так как потом через оконное приложение вводить данные,
            // поэтому сразу работать с массой, как изначально строковым
            // значением
            var monkeyData = new List<string>
            {
                "123",
                "0",
                "-1",
                "99999999999999",
                "@!#",
                "12 321",
                "",
                " ",
                null,
                "масса",
                "100 кило"
            };


            foreach (var testData in monkeyData)
            {
                Write($"Вводимая масса/дистанция = {testData}");

                ConstructorInfo defCons =
                    typeOfClassVehicles.GetConstructor(new Type[] { });

                var defVehicle = defCons.Invoke(new object[] { });

                try
                {
                    // Проверка от совсем дураокв
                    double testDoubleData = Convert.ToDouble(testData);

                    // Проверка работы свойства класса
                    string conditions = "";
                    try
                    {
                        (defVehicle as VehiclesBase).Weight = testDoubleData;
                        conditions += $"OK";
                    }
                    catch
                    {
                        conditions += $"Fail";
                    }

                    try
                    {
                        (defVehicle as VehiclesBase).Distance = testDoubleData;
                        conditions += $"/OK";
                    }
                    catch
                    {
                        conditions += $"/Fail";
                    }
                    Write("\t");
                    foreach (var condition in conditions.Split('/'))
                    {
                        if (condition == "OK")
                        {
                            ColorOutput($"{condition} ", ConsoleColor.Green);
                        }
                        else
                        {
                            ColorOutput($"{condition} ", ConsoleColor.Red);
                        }
                    }
                    WriteLine();
                }
                catch
                {
                    ColorOutput($"\tFail Fail\n", ConsoleColor.Red);
                }

            }
            WriteLine();
        }

        /// <summary>
        /// Console.Writeline() с цветом
        /// </summary>
        /// <param name="message">Сообщение</param>
        /// <param name="color">Цвет</param>
        private static void ColorOutput(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
