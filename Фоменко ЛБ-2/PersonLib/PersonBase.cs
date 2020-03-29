using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using ExternalFilesLib;


namespace PersonLib
{
    /// <summary>
    /// Человек
    /// </summary>
    public abstract class PersonBase
    {
        #region Поля

        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _lastName;

        #endregion

        #region Свойства

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            internal set
            {
                Supporting.CheckIsEmptyString(value);
                _name = CheckFIO(value);
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            internal set
            {
                Supporting.CheckIsEmptyString(value);
                _lastName = CheckFIO(value);
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public abstract int Age { get; internal set; }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Общая информация по человеку
        /// </summary>
        public string Info
        {
            get
            {
                return string.Format(
                "Имя:\t\t{0}\nФамилия:\t{1}\nВозраст:\t{2}\nПол:\t\t{3}",
                Name, LastName, Age, Gender);
            }
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="personGender">Пол</param>
        public PersonBase(string name, string lastName, int age, Gender personGender)
        {
            Supporting.CheckIsEmptyString(name);
            Supporting.CheckIsEmptyString(lastName);
            Supporting.CheckIsEmptyString(Convert.ToString(age));
            Supporting.CheckIsEmptyString(Convert.ToString(personGender));

            Name = CheckFIO(name);
            LastName = CheckFIO(lastName);
            Age = age;
            Gender = personGender;
        }

        /// <summary>
        /// Конструктор. Все атрибуты стандартные. 
        /// Требуется дальнейшее переприсваивание атрибутов
        /// </summary>
        public PersonBase() { }

        #endregion


        #region Методы

        /// <summary>
        /// Проверка Имени/Фамилии на наличие только букв
        /// </summary>
        /// <param name="input">Имя или Фамилия</param>
        /// <returns></returns>
        internal static string CheckFIO(string input)
        {
            var expressionForRegex = "(([А-Я]|[а-я]|[Ё]|[ё]|[A-Z]|[a-z])+)";
            var regexForName = new Regex(
                $"^{expressionForRegex}((-)?){expressionForRegex}$");

            if (regexForName.IsMatch(input))
            {
                input = FirstLetterToUpper(input);
            }
            else
            {
                throw new FormatException(
                    "Имя и Фамилия могут состоять " +
                    "только из кириллицы или латиницы");
            }
            return input;
        }

        /// <summary>
        /// Изменение первой буквы в имени/фамилии на заглавную
        /// с учетом двойного имени/фамилии
        /// </summary>
        /// <param name="wordToUpdate">Строка для изменения</param>
        /// <returns>Обновленная строка</returns>
        private static string FirstLetterToUpper(string wordToUpdate)
        {
            string[] words = wordToUpdate.Split('-');
            wordToUpdate = "";

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower();
                words[i] = words[i].First().ToString().ToUpper() +
                    words[i].Substring(1);

                wordToUpdate += $"{words[i]}-";
            }
            return wordToUpdate.Substring(0, wordToUpdate.Length - 1);
        }

        /// <summary>
        /// Абстрактный класс. Получение информации о человеке
        /// </summary>
        /// <returns></returns>
        public abstract string GetInfo();

        /// <summary>
        /// Преобразует фамилию из мужской в женскую или наоборот
        /// </summary>
        /// <param name="lastname">Фамилия</param>
        /// <param name="gender">Из какого пола преобразуется</param>
        /// <returns></returns>
        public static string ChangeGenderLastName(
            string lastname, Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                {
                    lastname += "а";
                    break;
                }
                case Gender.Female:
                {
                    lastname =
                        lastname.Substring(0, lastname.Length - 1);
                    break;
                }
            }
            return lastname;
        }

        #endregion
    }
}
