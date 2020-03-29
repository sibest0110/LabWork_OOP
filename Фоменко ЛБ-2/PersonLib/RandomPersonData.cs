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
        private const string pathMaleNames = "data/name_m.txt";

        /// <summary>
        /// Путь к файлу с женскими именами
        /// </summary>
        private const string pathFemaleNames = "data/name_f.txt";

        /// <summary>
        /// Путь к файлу с мужскими фамилиями
        /// </summary>
        private const string pathMaleLastnames = "data/lastname_m.txt";

        /// <summary>
        /// Путь к файлу с женскими фамилиями
        /// </summary>
        private const string pathFemaleLastnames = "data/lastname_f.txt";

        /// <summary>
        /// Путь к файлу со списком компаний
        /// </summary>
        private const string pathJobNames = "data/Список компаний.txt";

        /// <summary>
        /// Путь к файлу со списком школ
        /// </summary>
        private const string pathSchoolNames = "data/Список Школ.txt";

        /// <summary>
        /// Путь к файлу со списком садиков
        /// </summary>
        private const string pathKindergartenNames = "data/Список Садиков.txt";


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

        /// <summary>
        /// Случайное место работы
        /// </summary>
        /// <returns></returns>
        public static string GetRandomJobName()
        {
            Random rand = new Random();
            string[] jobNames = ExternalFiles.ReadTxtFile(pathJobNames);
            return jobNames[rand.Next(1, jobNames.Length)];
        }

        /// <summary>
        /// Случайное название школы
        /// </summary>
        /// <returns></returns>
        public static string GetRandomSchool()
        {
            Random rand = new Random();
            string[] schools = ExternalFiles.ReadTxtFile(pathSchoolNames);
            return schools[rand.Next(1, schools.Length)];
        }
        
        /// <summary>
        /// Случайное название садика
        /// </summary>
        /// <returns></returns>
        public static string GetRandomKindergarten()
        {
            Random rand = new Random();
            string[] kindergartens = ExternalFiles.ReadTxtFile(pathKindergartenNames);
            return kindergartens[rand.Next(1, kindergartens.Length)];
        }
    }
}
