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
    }
}
