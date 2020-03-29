using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    /// <summary>
    /// Вспомогательный класс. Набор вспомогательных методов
    /// </summary>
    internal static class Supporting
    {
        /// <summary>
        /// Проверка, является ли строка пустой.
        /// Если пустая строка, формируется исключение "ArgumentNullException"
        /// (может потом перенести в отдельный .cs)
        /// </summary>
        /// <param name="checkedString">Проверяемая строка</param>
        internal static void CheckIsEmptyString(string checkedString)
        {
            checkedString = checkedString.Replace(" ", "");
            if (string.IsNullOrEmpty(checkedString))
            {
                throw new ArgumentNullException(
                    $"{nameof(checkedString)} is null or empty!");
            }
        }


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
    }
}
