using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PersonLib.Supporting;

namespace PersonLib
{
    /// <summary>
    /// Класс, реализующий взаимодействие пользователя с программой через консоль
    /// </summary>
    public static class IOConsole
    {
        /// <summary>
        /// Ввод текста через консоль с проверкой на пустой ввод
        /// </summary>
        /// <returns></returns>
        public static string Input()
        {
            bool trouble = true;
            string newName = "";
            while (trouble)
            {
                newName = Console.ReadLine();
                try
                {
                    CheckIsEmptyString(newName);
                    trouble = false;
                }
                catch (ArgumentNullException)
                {
                    WarningMessage("Указана пустая строка");
                    Console.Write("Введите ещё раз: ");
                }
            }
            return newName;
        }


        /// <summary>
        /// Создание человека с вводом данных через консоль
        /// </summary>
        /// <returns></returns>
        public static Person CreatePerson()
        {
            var newPerson = new Person();

            List<Action> actions = new List<Action>()
            {
                SetName(newPerson),
                SetLastName(newPerson),
                SetAge(newPerson),
                SetGender(newPerson)
            };

            actions.ForEach(SetParam);

            return newPerson;
        }

        #region Acions для заполнения свойств Person

        /// <summary>
        /// Action для ввода имени
        /// </summary>
        /// <param name="person">Человек</param>
        /// <returns></returns>
        private static Action SetName(Person person)
        {
            return new Action(() =>
            {
                Console.Write("Имя: ");
                person.Name = Console.ReadLine();
            });
        }

        /// <summary>
        /// Action для ввода фамилии
        /// </summary>
        /// <param name="person">Человек</param>
        /// <returns></returns>
        private static Action SetLastName(Person person)
        {
            return new Action(() =>
            {
                Console.Write("Фамилия: ");
                person.LastName = Console.ReadLine();
            });
        }

        /// <summary>
        /// Action для ввода возраста
        /// </summary>
        /// <param name="person">Человек</param>
        /// <returns></returns>
        private static Action SetAge(Person person)
        {
            return new Action(() =>
            {
                Console.Write("Возраст: ");
                person.Age = int.Parse(Console.ReadLine());
            });
        }

        /// <summary>
        /// Action для ввода пола
        /// </summary>
        /// <param name="person">Человек</param>
        /// <returns></returns>
        private static Action SetGender(Person person)
        {
            return new Action(() =>
            {
                Console.Write("Пол (1 (Male) или 2 (Female)): ");
                int genderCode = int.Parse(Console.ReadLine());
                person.Gender = ConvertToGender(genderCode);
            });
        }


        #endregion

        /// <summary>
        /// Задание свойства, определяемого Action
        /// </summary>
        /// <param name="enterAction">
        /// Определяет задаваемое свойство</param>
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
                    WarningMessage($"Исключение: {ex.Message}");
                    Console.WriteLine($"Повторите ввод:\n");
                }
            }
        }


        /// <summary>
        /// Вывод сообщения и уведомление о выходе в предыдущее меню 
        /// с ожиданием нажатия любой кнопки
        /// </summary>
        /// <param name="message">Сообщение</param>
        public static void BackToMenu(string message)
        {
            Console.WriteLine("\n\n" + message);
            Console.WriteLine("--Вернуться в предыдущее меню--");
            Console.ReadKey();
        }

        /// <summary>
        /// Уведомление о выходе в предыдущее меню 
        /// с ожиданием нажатия любой кнопки
        /// </summary>
        public static void BackToMenu()
        {
            Console.WriteLine("\n\n--Вернуться в предыдущее меню--");
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод сообщения в консоль красным цветом.
        /// </summary>
        /// <param name="msg">Сообщение.</param>
        private static void WarningMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + msg);
            Console.ResetColor();
        }

        /// <summary>
        /// Отображение содержимого объекта PersonList
        /// </summary>
        /// <param name="listInfo">Массив с информацией по PersonList
        /// (Получается методом "PersonList.Info()")</param>
        public static void DisplayList(string[] listInfo)
        {
            if (listInfo.Length == 0)
            {
                Console.WriteLine($"\nДанный список пуст!");
            }
            
            for (int index = 0; index < listInfo.Length; index++)
            {
                Console.WriteLine($"\nИндекс:\t\t{index}" +
                    $"\n{listInfo[index]}");
            }
        }
    }
}
