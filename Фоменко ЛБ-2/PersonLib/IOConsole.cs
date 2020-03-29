using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PersonLib.Supporting;
using static PersonLib.GenderSetup;

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
        /// Создание взрослого человека с вводом данных через консоль
        /// </summary>
        /// <returns></returns>
        public static Adult CreateAdultPerson()
        {
            Adult newAdult = new Adult();

            List<Action> actions = new List<Action>()
            {
                SetName(newAdult),
                SetLastName(newAdult),
                SetAdultAge(newAdult),
                SetGender(newAdult),

                SetPasportNumber(newAdult),
                SetJobName(newAdult),
                SetMarriage(newAdult)
            };
            actions.ForEach(SetParam);

            return newAdult;
        }

        /// <summary>
        /// Создание пары для взрослого человека
        /// </summary>
        /// <returns></returns>
        private static Adult CreateAdultCouple(Adult adult)
        {
            Adult couple = new Adult();

            couple.LastName = Adult.ChangeGenderLastName
                            (adult.LastName, adult.Gender);
            couple.Gender = GenderSetup.ChangeGender(adult.Gender);
            couple.Marriage = true;
            couple.Couple = adult;

            Console.WriteLine("\nДанные по супружеской паре:");
            List<Action> actions = new List<Action>()
            {
                SetName(couple),
                SetAdultAge(couple),

                SetPasportNumber(couple),
                SetJobName(couple),
            };

            actions.ForEach(SetParam);

            return couple;
        }

        /// <summary>
        /// Создание ребёнка
        /// </summary>
        /// <returns></returns>
        public static Child CreateChildPerson()
        {
            Child newChild = new Child();

            List<Action> actions = new List<Action>()
            {
                SetName(newChild),
                SetLastName(newChild),
                SetChildAge(newChild),
                SetGender(newChild),

                SetSchoolName(newChild)
            };

            actions.ForEach(SetParam);

            newChild.Mom = Adult.GetRandomAdult(Gender.Female);
            newChild.Dad = Adult.GetRandomCouple(newChild.Mom);

            // Присвоение фамилий родителям
            if (newChild.Gender == Gender.Male)
            {
                newChild.Dad.LastName = newChild.LastName;
                newChild.Mom.LastName = 
                    PersonBase.ChangeGenderLastName(newChild.LastName, 
                                                        newChild.Gender);
            }
            else
            {
                newChild.Mom.LastName = newChild.LastName;
                newChild.Dad.LastName = PersonBase.ChangeGenderLastName
                                        (newChild.LastName, newChild.Gender);
            }

            return newChild;
        }

        #region Acions для заполнения свойств Person

        /// <summary>
        /// Action для ввода имени
        /// </summary>
        /// <param name="person">Человек</param>
        /// <returns></returns>
        private static Action SetName(PersonBase person)
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
        private static Action SetLastName(PersonBase person)
        {
            return new Action(() =>
            {
                Console.Write("Фамилия: ");
                person.LastName = Console.ReadLine();
            });
        }

        /// <summary>
        /// Action для ввода возраста взрослого человека
        /// </summary>
        /// <param name="adult">Человек</param>
        /// <returns></returns>
        private static Action SetAdultAge(Adult adult)
        {
            return new Action(() =>
            {
                Console.Write("Возраст: ");
                adult.Age = int.Parse(Console.ReadLine());
            });
        }

        /// <summary>
        /// Action для ввода возраста ребёнка
        /// </summary>
        /// <param name="child">Ребёнок</param>
        /// <returns></returns>
        private static Action SetChildAge(Child child)
        {
            return new Action(() =>
            {
                Console.Write("Возраст: ");
                child.Age = int.Parse(Console.ReadLine());
            });
        }

        /// <summary>
        /// Action для ввода пола
        /// </summary>
        /// <param name="person">Человек</param>
        /// <returns></returns>
        private static Action SetGender(PersonBase person)
        {
            return new Action(() =>
            {
                Console.Write("Пол (1 (Male) или 2 (Female)): ");
                int genderCode = int.Parse(Console.ReadLine());
                person.Gender = ConvertToGender(genderCode);
            });
        }

        /// <summary>
        /// Action для ввода номера паспорта
        /// </summary>
        /// <param name="adult">Человек</param>
        /// <returns></returns>
        private static Action SetPasportNumber(Adult adult)
        {
            return new Action(() =>
            {
                Console.Write("6-ти значный номер паспорта: ");
                adult.PasportNumber = int.Parse(Console.ReadLine());
            });
        }

        /// <summary>
        /// Action для ввода места работы
        /// </summary>
        /// <param name="adult">Человек</param>
        /// <returns></returns>
        private static Action SetJobName(Adult adult)
        {
            return new Action(() =>
            {
                Console.Write("Место работы (можно оставить пустым): ");
                adult.JobName = Console.ReadLine();
            });
        }

        /// <summary>
        /// Action для ввода семейного положения
        /// </summary>
        /// <param name="adult">Человек</param>
        /// <returns></returns>
        private static Action SetMarriage(Adult adult)
        {
            return new Action(() =>
            {
                Console.Write("Семейное положение " +
                    "(true в браке / false не в браке): ");
                bool marriage = Convert.ToBoolean(Console.ReadLine());

                if (marriage == true)
                {
                    adult.Marriage = true;
                    adult.Couple = CreateAdultCouple(adult);
                }
                else
                {
                    adult.Marriage = false;
                }
            });
        }

        private static Action SetSchoolName(Child child)
        {
            return new Action(() =>
            {
                Console.Write("Название школы или садика: ");
                child.SchoolName = Console.ReadLine();
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
