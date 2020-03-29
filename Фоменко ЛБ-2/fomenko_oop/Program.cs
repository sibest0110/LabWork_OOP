using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PersonLib;
using ExternalFilesLib;

namespace lab1_1
{
    /// <summary>
    /// Основной класс для ЛБ-1 по ООП
    /// </summary>
    public class Program
    {
        const int ESC = 27;

        /// <summary>
        /// Точка входа программы
        /// </summary>
        /// <param name="args"></param>
        internal static void Main(string[] args)
        {
            var collectionForList1 = new List<PersonBase>()
            {
                new Adult("Владислав", "Фоменко", 23, Gender.Male,
                    111111, "ТПУ", false, null),
                new Adult("Максим", "Бахтеев", 23, Gender.Male,
                    222222, "ТПУ", false, null),
                new Adult("Анастасия", "Жук", 23, Gender.Female,
                    333333, "ТПУ", false, null),
                new Adult("Василий", "Сухоруков", 23, Gender.Male,
                    444444, "ТПУ", false, null),
                new Adult("Дмитрий", "Ращектаев", 23, Gender.Male,
                    555555, "ТПУ", false, null)
            };

            var list1 = new PersonList("Третий ряд");
            var list2 = new PersonList("Пустой лист");

            foreach (PersonBase person in collectionForList1)
            {
                list1.AddPerson(person);
            }

            Menu1(list1, list2);
        }

        /// <summary>
        /// Исходное меню
        /// </summary>
        /// <param name="list1">Первый список людей</param>
        /// <param name="list2">Второй список людей</param>
        public static void Menu1(PersonList list1, PersonList list2)
        {
            bool endProgram = false;
            while (!endProgram)
            {
                Console.Clear();
                Console.WriteLine("/\n");
                Console.WriteLine("1. Выбрать список '" + list1.Name + "'");
                Console.WriteLine("2. Выбрать список '" + list2.Name + "'");

                char modeMenu = Console.ReadKey(true).KeyChar;
                switch (modeMenu)
                {
                    case '1':
                    {
                        Menu2(list1, list2);
                        break;
                    }
                    case '2':
                    {
                        Menu2(list2, list1);
                        break;
                    }
                    default:
                    {
                        if (Convert.ToByte(modeMenu) == ESC)
                        {
                            Console.Clear();
                            Console.WriteLine("Подтвердите выход.\n\n");
                            Console.WriteLine("-Нажмите любую кнопку " +
                                "(ESC - отменить выход)-");
                            if (Convert.ToByte(Console.ReadKey(true).
                                KeyChar) != ESC)
                            {
                                endProgram = true;
                            }
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Меню для взаимодействия со списком людей
        /// </summary>
        /// <param name="list">Выбранный лист.</param>
        /// <param name="anotherList">Другой лист.</param>
        public static void Menu2(PersonList list, PersonList anotherList)
        {
            //TODO:(v) Повыносить методы    (вынес "Menu2Items")

            string path = ("/" + list.Name + "/");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("/" + list.Name + "/\n");
                Console.WriteLine($"{Menu2Items()}");

                var modeMenu2 = Console.ReadKey(true).KeyChar;

                switch (modeMenu2)
                {
                    case '1':
                    {
                        Menu2Item1(list, path);
                        break;
                    }
                    case '2':
                    {
                        Menu2Item2(list, path);
                        break;
                    }
                    case '3':
                    {
                        Menu2Item3(list, path);
                        break;
                    }
                    case '4':
                    {
                        Menu2Item4(list, path);
                        break;
                    }
                    case '5':
                    {
                        Menu2Item5(list, path);
                        break;
                    }
                    case '6':
                    {
                        Menu2Item6(list, path);
                        break;
                    }
                    case '7':
                    {
                        Menu2Item7(list, anotherList, path);
                        break;
                    }
                    case '8':
                    {
                        Menu2Item8(list, path);
                        break;
                    }
                    case '9':
                    {
                        Menu2Item9(list,path);
                        break;
                    }
                    default:
                    {
                        if (Convert.ToByte(modeMenu2) == ESC)
                        {
                            return;
                        }
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Пункты для второго меню
        /// </summary>
        /// <returns></returns>
        private static string Menu2Items()
        {
            return $"1. Вывести содержимое списка.\n\r" +
                $"2. Добавить взрослого человека в список.\n\r" +
                $"3. Добавить ребёнка в список.\n\r" +
                $"4. Удалить человека из списка.\n\r" +
                $"5. Очистить список.\n\r" +
                $"6. Переименовать список.\n\r" +
                $"7. Копироваться человека в другой список\n\r" +
                $"8. Добавить случайного человека\n\r" +
                $"9. Проверить тип человека по индексу\n\r";
        }


        /// <summary>
        /// Содержимое списка.
        /// </summary>
        /// <param name="list">Текущий лист</param>
        /// <param name="path">Путь меню</param>
        private static void Menu2Item1(PersonList list, string path)
        {
            Console.Clear();
            Console.WriteLine(path + "Содержимое списка" +
                " (людей = " + list.Size + ")/");
            IOConsole.DisplayList(list.Info());
            IOConsole.BackToMenu();
        }

        /// <summary>
        /// Добавить взрослого человека в список.
        /// </summary>
        /// <param name="list">Текущий лист</param>
        /// <param name="path">Путь меню</param>
        private static void Menu2Item2(PersonList list, string path)
        {
            Console.Clear();
            Console.WriteLine(path + "Добавить взрослого человека в список/\n");

            list.AddPerson(IOConsole.CreateAdultPerson());
        }

        /// <summary>
        /// Добавить ребёнка в список.
        /// </summary>
        /// <param name="list">Текущий лист</param>
        /// <param name="path">Путь меню</param>
        private static void Menu2Item3(PersonList list, string path)
        {
            Console.Clear();
            Console.WriteLine(path + "Добавить ребёнка в список/\n");

            list.AddPerson(IOConsole.CreateChildPerson());
        }

        /// <summary>
        /// Удалить человека из списка.
        /// </summary>
        /// <param name="list">Текущий лист</param>
        /// <param name="path">Путь меню</param>
        private static void Menu2Item4(PersonList list, string path)
        {
            Console.Clear();
            Console.WriteLine(path + "Удалить человека из списка/\n");
            IOConsole.DisplayList(list.Info());
            if (list.Size == 0)
            {
                IOConsole.BackToMenu();
                return;
            }
            Console.Write("Удалить из списка человека с индексом: ");
            try
            {
                list.DeletePerson(int.Parse(Console.ReadLine()));
            }
            catch (IndexOutOfRangeException)
            {
                IOConsole.BackToMenu
                    ("Указанный индекс не существует.");
            }
            catch
            {
                IOConsole.BackToMenu
                    ("Указана какая-то ерунда.");
            }
        }

        /// <summary>
        /// Очистить список.
        /// </summary>
        /// <param name="list">Текущий лист</param>
        /// <param name="path">Путь меню</param>
        private static void Menu2Item5(PersonList list, string path)
        {
            Console.Clear();
            Console.WriteLine(path + "Очистить список/");
            list.ClearPersonList();
            IOConsole.BackToMenu
                ("Список '" + list.Name + "' очищен");
        }

        /// <summary>
        /// Переименовать список.
        /// </summary>
        /// <param name="list">Текущий лист</param>
        /// <param name="path">Путь меню</param>
        private static void Menu2Item6(PersonList list, string path)
        {
            Console.Clear();
            Console.WriteLine(path + "Переименовать список/");
            Console.Write("\nНовое имя списка: ");
            list.Name = IOConsole.Input();
        }

        /// <summary>
        /// Копировать человека в другой список.
        /// </summary>
        /// <param name="list">Текущий лист</param>
        /// <param name="anotherList">Другой лист</param>
        /// <param name="path">Путь меню</param>
        private static void Menu2Item7(PersonList list, PersonList anotherList, string path)
        {
            Console.Clear();
            Console.WriteLine($"{path}Копировать человека в список" +
                $" {anotherList.Name}/");
            IOConsole.DisplayList(list.Info());
            if (list.Size == 0)
            {
                IOConsole.BackToMenu();
                return;
            }
            Console.Write("Индекс копируемого человека = ");
            try
            {
                anotherList.AddPerson(
                    list[int.Parse(Console.ReadLine())]);
            }
            catch (IndexOutOfRangeException ex)
            {
                IOConsole.BackToMenu
                    (ex.Message);
            }
            catch
            {
                IOConsole.BackToMenu
                    ("Необходимо указать число.");
            }
        }

        /// <summary>
        /// Добавить случайного человека.
        /// </summary>
        /// <param name="list">Текущий лист</param>
        /// <param name="path">Путь меню</param>
        private static void Menu2Item8(PersonList list, string path)
        {
            Console.Clear();
            Console.WriteLine(path + "Добавить случайного человека/");
            try
            {
                list.AddPerson(PersonFactory.GetRandomPerson());
                Console.WriteLine("\n\nДобавлен новый пользователь.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\n" + ex.Message);
            }
            IOConsole.BackToMenu();
        }

        /// <summary>
        /// Узнать тип человека
        /// </summary>
        /// <param name="list">Текущий лист</param>
        /// <param name="path">Путь меню</param>
        private static void Menu2Item9(PersonList list, string path)
        {
            Console.Clear();
            Console.WriteLine(path + "Узнать тип человека/");
            IOConsole.DisplayList(list.Info());
            if (list.Size == 0)
            {
                IOConsole.BackToMenu();
                return;
            }
            Console.Write("\nУзнать тип человека с индексом: ");
            try
            {
                PersonBase person = list[int.Parse(Console.ReadLine())];
                Console.Write($"\n{person.Name} {person.LastName} ");

                switch (person)
                {
                    case Adult adult:
                    {
                        Console.WriteLine($"взрослый человек.");
                        Console.WriteLine((person as Adult).Curse());
                        break;
                    }
                    case Child child:
                    {
                        Console.WriteLine($"ребёнок.");
                        Console.WriteLine((person as Child).Cry());
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            IOConsole.BackToMenu();
        }
    }
}
