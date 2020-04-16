using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;
using static System.Console;
using System.Reflection;
using System.Threading;

namespace ConsoleTests
{
    //TODO: (v) RSDN
    public class Program
    {
        //TODO: (v) RSDN
        public static void Main(string[] args)
        {
            Welcome();
            MenuStart();
        }

        /// <summary>
        /// Текст приветствия
        /// </summary>
        private static void Welcome()
        {
            var lettersOfMessage = new List<Action>
            {
                new Action(()=> ColorOutput("Д", ConsoleColor.Yellow)),
                new Action(()=> ColorOutput("о", ConsoleColor.Cyan)),
                new Action(()=> ColorOutput("б", ConsoleColor.Green)),
                new Action(()=> ColorOutput("р", ConsoleColor.White)),
                new Action(()=> ColorOutput("о ", ConsoleColor.DarkCyan)),
                new Action(()=> ColorOutput("п", ConsoleColor.Blue)),
                new Action(()=> ColorOutput("о", ConsoleColor.DarkGreen)),
                new Action(()=> ColorOutput("ж", ConsoleColor.Magenta)),
                new Action(()=> ColorOutput("а", ConsoleColor.DarkYellow)),
                new Action(()=> ColorOutput("л", ConsoleColor.DarkBlue)),
                new Action(()=> ColorOutput("о", ConsoleColor.DarkMagenta)),
                new Action(()=> ColorOutput("в", ConsoleColor.Yellow)),
                new Action(()=> ColorOutput("а", ConsoleColor.White)),
                new Action(()=> ColorOutput("т", ConsoleColor.Blue)),
                new Action(()=> ColorOutput("ь!", ConsoleColor.Cyan))
            };

            // Псевдокрасивый вывод приветствия
            for (int i = 0; i < lettersOfMessage.Count; i++)
            {
                // Пустая позиция на месте предыдущих букв
                for (int empty = 0; empty < i; empty++)
                {
                    Write(" ");
                }
                lettersOfMessage[i].Invoke();

                Thread.Sleep(50);

                Clear();
            }
            foreach (var action in lettersOfMessage)
            {
                action.Invoke();
            }

            WriteLine();
        }

        /// <summary>
        /// Стартовое меню
        /// </summary>
        private static void MenuStart()
        {
            while (true)
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
                $"\nName /string/ - не пустое (пробелы) и не null" +

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

            //TODO: (v) RSDN
            ColorOutput($"\nПроверка Type каждого класса наследника:\n",
                ConsoleColor.Yellow);
            typesOfVehicles.ForEach(TestVehiclesType);

            //TODO: (v) RSDN
            ColorOutput($"\nПроверка ввода массы ТС и дистанции для ТС:\n",
                ConsoleColor.Yellow);
            typesOfVehicles.ForEach(TestWeightAndDistance); 
            
            
            ColorOutput($"\nПроверка ввода названия ТС:\n",
                ConsoleColor.Yellow);
            typesOfVehicles.ForEach(TestName);




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
            //TODO: Дубль ниже
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
            //TODO: Дубль выше
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

        // Так как потом через оконное приложение вводить данные,
        // поэтому сразу работать с массой, как изначально строковым
        // значением
        /// <summary>
        /// Данные со всевозможными вариациями значений
        /// </summary>
        private static List<string> _monkeyData = new List<string>
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
            "буквы",
            "100 кило",
            "13.37",
            "3,14159"
        };


        //TODO: (v) XML
        /// <summary>
        /// Тестирование ввода значений массы автомобиля и дистанции.
        /// </summary>
        /// <param name="typeOfClassVehicles">Класс ТС</param>
        private static void TestWeightAndDistance(Type typeOfClassVehicles)
        {
            WriteLine($"- Класс {typeOfClassVehicles}:");


            foreach (var testData in _monkeyData)
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

        //TODO XXXXXXXXMMMMMMMMMMLLLLLLLLLLL

        private static void TestName(Type typeOfClassVehicles)
        {
            WriteLine($"- Класс {typeOfClassVehicles}:");

            foreach (var testData in _monkeyData)
            {
                Write($"Вводимое название ТС = {testData}");

                ConstructorInfo defCons =
                    typeOfClassVehicles.GetConstructor(new Type[] { });

                var defVehicle = defCons.Invoke(new object[] { });

                try
                {
                    (defVehicle as VehiclesBase).Name = testData;
                    ColorOutput($"\tOK\n", ConsoleColor.Green);
                }
                catch
                {
                    ColorOutput($"\tFail\n", ConsoleColor.Red);
                }

            }
            WriteLine();
        }

        /// <summary>
        /// Console.Write() с цветом
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
