using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExternalFilesLib;

namespace PersonLib
{
    /// <summary>
    /// Работа с текстовыми файлами, содержащие имена и фамилии
    /// </summary>
    internal static class RandomPersonData
    {
        /// <summary>
        /// Путь к файлу с мужскими именами
        /// </summary>
        private const string pathMaleNames = "name_m.txt";

        /// <summary>
        /// Путь к файлу с женскими именами
        /// </summary>
        private const string pathFemaleNames = "name_f.txt";

        /// <summary>
        /// Путь к файлу с мужскими фамилиями
        /// </summary>
        private const string pathMaleLastnames = "lastname_m.txt";

        /// <summary>
        /// Путь к файлу с женскими фамилиями
        /// </summary>
        private const string pathFemaleLastnames = "lastname_f.txt";


        /// <summary>
        /// Случайное имя в зависимости от пола
        /// </summary>
        /// <param name="gender">Пол человека</param>
        /// <returns></returns>
        public static string GetRandomName(Gender gender)
        {
            Random rand = new Random();
            string[] names;

            switch (gender)
            {
                case Gender.Male:
                {
                    names =
                        ExternalFiles.ReadTxtFile(pathMaleNames);
                    return names[rand.Next(names.Length)];
                }
                case Gender.Female:
                {
                    names =
                        ExternalFiles.ReadTxtFile(pathFemaleNames);
                    return names[rand.Next(names.Length)];
                }
                default:
                {
                    // Честно, не знаю как сюда вообще можно попасть, 
                    // однако на всякий случай решил поместить тут исключение. 
                    // Через case - для масштабируемости 
                    // (вдруг приступ толерантности словлю)

                    // И сразу вопрос - в такой ситуации что лучше использовать?
                    // case или if/else (if/elseif/else)
                    throw new Exception(
                        "Проблемы в формировании случайного человека");
                }
            }
        }

        /// <summary>
        /// Случайная фамилия в зависимости от пола
        /// </summary>
        /// <param name="gender">Пол человека</param>
        /// <returns></returns>
        public static string GetRandomLastname(Gender gender)
        {
            Random rand = new Random();
            string[] lastnames;

            switch (gender)
            {
                case Gender.Male:
                {
                    lastnames =
                        ExternalFiles.ReadTxtFile(pathMaleLastnames);
                    return lastnames[rand.Next(lastnames.Length)];
                }
                case Gender.Female:
                {
                    lastnames =
                        ExternalFiles.ReadTxtFile(pathFemaleLastnames);
                    return lastnames[rand.Next(lastnames.Length)];
                }
                default:
                {
                    throw new Exception(
                        "Проблемы в формировании случайного человека");
                }
            }
        }
    }
}
