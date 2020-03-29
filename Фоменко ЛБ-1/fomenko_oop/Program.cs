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
            var collectionForList1 = new List<Person>()
            {
                new Person("Владислав", "Фоменко", 23, Gender.Male),
                new Person("Максим", "Бахтеев", 23, Gender.Male),
                new Person("Анастасия", "Жук", 23, Gender.Female),
                new Person("Василий", "Сухоруков", 23, Gender.Male),
                new Person("Дмитрий", "Ращектаев", 23, Gender.Male)
            };

            var list1 = new PersonList("Третий ряд");
            var list2 = new PersonList("Пустой лист");

            foreach (Person person in collectionForList1)
            {
                list1.AddPerson(person);
            }

            Menu1(list1, list2);
        }

        /// <summary>
        /// Исходное меню
        /// </summary>
        /// <param name="list1">Первый список людей</param>
        /// <param name="Второй список людей">//TODO</param>
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
                            Console.WriteLine("-Нажмите любую кнопку-");      //!! 78 символов
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
            bool goMenu1 = false;

            string path = ("/" + list.Name + "/");

            while (!goMenu1)
            {
                Console.Clear();
                Console.WriteLine("/" + list.Name + "/\n");
                Console.WriteLine("1. Вывести содержимое списка.");
                Console.WriteLine("2. Добавить человека в список.");
                Console.WriteLine("3. Удалить человека из списка.");
                Console.WriteLine("4. Очистить список.");
                Console.WriteLine("5. Переименовать список.");
                Console.WriteLine("6. Копироваться человека в другой список");
                Console.WriteLine("7. Добавить случайного человека");

                var modeMenu2 = Console.ReadKey(true).KeyChar;

                switch (modeMenu2)
                {
                    case '1':
                    {
                        Console.Clear();
                        Console.WriteLine(path + "Содержимое списка" +
                            " (людей = " + list.Size + ")/");
                        IOConsole.DisplayList(list.Info());
                        IOConsole.BackToMenu();
                        break;
                    }
                    case '2':
                    {
                        Console.Clear();
                        Console.WriteLine(path + "Добавить человека в список/\n");

                        list.AddPerson(IOConsole.CreatePerson());

                        break;
                    }
                    case '3':
                    {
                        Console.Clear();
                        Console.WriteLine(path + "Удалить человека из списка/\n");
                        IOConsole.DisplayList(list.Info());
                        if (list.Size == 0)
                        {
                            IOConsole.BackToMenu();
                            break;
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
                        break;
                    }
                    case '4':
                    {
                        Console.Clear();
                        Console.WriteLine(path + "Очистить список/");
                        list.ClearPersonList();
                        IOConsole.BackToMenu
                            ("Список '" + list.Name + "' очищен");
                        break;
                    }
                    case '5':
                    {
                        Console.Clear();
                        Console.WriteLine(path + "Переименовать список/");
                        Console.Write("\nНовое имя списка: ");
                        list.Name = IOConsole.Input();
                        break;
                    }
                    case '6':
                    {
                        Console.Clear();
                        Console.WriteLine($"{path}Копировать человека в список" +
                            $" {anotherList.Name}/");
                        IOConsole.DisplayList(list.Info());
                        if (list.Size == 0)
                        {
                            IOConsole.BackToMenu();
                            break;
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
                        break;
                    }
                    case '7':
                    {
                        Console.Clear();
                        Console.WriteLine(path + "Добавить случайного человека/");
                        try
                        {
                            list.AddPerson(Person.GetRandomPerson());
                            Console.WriteLine("\n\nДобавлен новый пользователь.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\n\n" + ex.Message);
                        }
                        IOConsole.BackToMenu();
                        break;
                    }
                    default:
                    { 
                    if (Convert.ToByte(modeMenu2) == ESC)
                        {
                            goMenu1 = true;
                        }
                        break;
                    }
                }
                //Console.ReadKey();
            }
        }
    }
}
