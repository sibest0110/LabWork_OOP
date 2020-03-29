using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ExternalFilesLib
{
    /// <summary>
    /// Работа с внешними .txt файлами
    /// </summary>
    public static class ExternalFiles
    {
        /// <summary>
        /// Чтение .txt файла и запись в строковый массив, 
        /// где элементы массива - это строки исходного .txt файла
        /// </summary>
        /// <param name="path">Путь к .txt файлу</param>
        /// <returns></returns>
        public static string[] ReadTxtFile(string path)
        {
            if (File.Exists(path))
            {
                FileStream fileStream = File.OpenRead(path);

                int lengthByteArray = int.Parse(Convert.ToString(fileStream.Length));
                byte[] dataByteArray = new byte[lengthByteArray];
                fileStream.Read(dataByteArray, 0, lengthByteArray);

                fileStream.Close();

                string dataString = Encoding.Default.GetString(dataByteArray);
                string[] dataStringArray = dataString.Replace("\n", "").Split('\r');

                return dataStringArray;
            }
            else
            {
                throw new FileNotFoundException(
                    "Отсутствует файл " + path);
            }
        }
    }
}
