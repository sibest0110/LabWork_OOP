using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Набор "Пол". Мужской/Женский
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    };

    /// <summary>
    /// Статический метод, служащий для ваимодействия с набором Gender
    /// </summary>
    public static class GenderSetup
    {
        /// <summary>
        /// Преобразует число в пол
        /// </summary>
        /// <param name="genderCode">1 - Male; 2 - Female</param>
        /// <returns></returns>
        public static Gender ConvertToGender(int genderCode)
        {
            switch (genderCode)
            {
                case 1:
                {
                    return Gender.Male;
                }
                case 2:
                {
                    return Gender.Female;
                }
                default:
                {
                    throw new FormatException(
                "Возможно указать только 1 (Male) или 2 (Female)");
                }
            }
        }

        /// <summary>
        /// Возвращает код пола (1 - Male; 2 - Female)
        /// </summary>
        /// <param name="gender">Пол</param>
        /// <returns></returns>
        public static int ConvertGenderToInt(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                {
                    return 1;
                }
                case Gender.Female:
                {
                    return 2;
                }
                default:
                {
                    throw new FormatException("ConvertGenderToInt");
                }
            }
        }

        /// <summary>
        /// Смена пола
        /// </summary>
        /// <param name="gender">Исходный пол</param>
        /// <returns></returns>
        public static Gender ChangeGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.Female:
                {
                    return Gender.Male;
                }
                case Gender.Male:
                {
                    return Gender.Female;
                }
                default:
                {
                    throw new FormatException("ChangeGender");
                }
            }
        }

        /// <summary>
        /// Получение случайного пола
        /// </summary>
        /// <returns></returns>
        public static Gender GetRandomGender()
        {
            Random randGenderCode = new Random();
            // Без этого рандом заедает (одни женщины)
            randGenderCode.Next(1, 666);    
            return ConvertToGender(randGenderCode.Next(1, 3));
        }
    }
}
