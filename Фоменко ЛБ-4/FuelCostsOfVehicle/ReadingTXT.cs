using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FuelCostsOfVehicle
{
    public static class ReadingTXT
    {
        /// <summary>
        /// Получение текста из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public static string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
