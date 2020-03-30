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
            Welcome();
            MenuStart();
        }

        /// <summary>
        /// Текст приветствия
        /// </summary>
        private static void Welcome()
        {
            ColorOutput("Д", ConsoleColor.Yellow);
            ColorOutput("о", ConsoleColor.Cyan);
            ColorOutput("б", ConsoleColor.Green);
            ColorOutput("р", ConsoleColor.White);
            ColorOutput("о ", ConsoleColor.DarkCyan);
            ColorOutput("п", ConsoleColor.Blue);
            ColorOutput("о", ConsoleColor.DarkGreen);
            ColorOutput("ж", ConsoleColor.Magenta);
            ColorOutput("а", ConsoleColor.DarkYellow);
            ColorOutput("л", ConsoleColor.DarkBlue);
            ColorOutput("о", ConsoleColor.DarkMagenta);
            ColorOutput("в", ConsoleColor.Yellow);
            ColorOutput("а", ConsoleColor.White);
            ColorOutput("т", ConsoleColor.Blue);
            ColorOutput("ь!", ConsoleColor.Cyan);
            WriteLine();
        }

        /// <summary>
        /// Стартовое меню
        /// </summary>
        private static void MenuStart()
        {
            while(true)
            {
                WriteLine(
                   $"Выберите задачу:" +
                   $"\n1 - Запустить тесты для классов Транспортных средств" +
                   $"\n2 - Выполнение программы согласно заданию" +
                   $"\n\nДля выхода из программы нажмите любую другую кнопку!");
                switch (ReadKey(true).KeyChar)
                {
                    case '1':
                    {
                        TestsForVehicles();
                        Clear();
                        break;
                    }
                    case '2':
                    {
                        MenuFuelCosts();
                        Clear();
                        break;
                    }
                    default:
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Меню ручного создания ТС и получения затрачиваемого топлива на вводимую дистанцию
        /// </summary>
        private static void MenuFuelCosts()
        {
            while (true)
            {
                IFuelCosts vehicle;
                Clear();
                WriteLine($"Демонстрация работы бизнес логики\n");
                WriteLine(
                    $"Необходимо выбрать тип транспортного средства:" +
                    $"\n1 - Автомобиль с ДВС" +
                    $"\n2 - Гибридный автомобиль" +
                    $"\n3 - Вертолёт" +
                    $"\n\nДля выхода в предыдущее меню нажмите любую другую кнопку");
                switch (ReadKey(true).KeyChar)
                {
                    case '1':
                    {
                        Clear();
                        vehicle = IO.CreateVehicle(VehiclesTypes.Car);
                        break;
                    }
                    case '2':
                    {
                        Clear();
                        vehicle = IO.CreateVehicle(VehiclesTypes.HybridCar);
                        break;
                    }
                    case '3':
                    {
                        Clear();
                        vehicle = IO.CreateVehicle(VehiclesTypes.Helicopter);
                        break;
                    }
                    default:
                    {
                        return;
                    }
                }
                WriteLine($"\nДля {(vehicle as VehiclesBase).Type} " +
                    $"{(vehicle as VehiclesBase).Name} " +
                    $"на {vehicle.Distance} км потребуется " +
                    $"{vehicle.FuelCost(vehicle.Distance)} литров топлива");
                WriteLine("Нажмите любую кнопку");
                ReadKey();
            }
        }

        /// <summary>
        /// Запуск тестов для приведённых в данном методе типов ТС
        /// </summary>
        private static void TestsForVehicles()
        {
            Clear();
            WriteLine($"Запущен тест Транспортных средств\n");

            WriteLine($"Информация по свойствам:" +
                $"\nName /string/ - на данный момент ограничений нет" +

                $"\nType /enum.VehiclesTypes/ - должен соответствовать " +
                $"соответствующему классу (реализация в конструкторе)" +

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


            WriteLine("Тесты завершены. " +
                "Для возврата в меню нажмите любую кнопку");
            ReadKey();
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
        public static void ColorOutput(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
