using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace FuelCostsOfVehicle
{
    public static class ExternalInteraction
    {
        /// <summary>
        /// Получение текста из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns></returns>
        public static string ReadTXT(string path)
        {
            return File.ReadAllText(path);
        }

        /// <summary>
        /// Выгрузка базы данных
        /// </summary>
        /// <param name="exportData">Выгружаемая база данных</param>
        public static void UpLoadDataBase(List<string> exportData)
        {
            SaveFileDialog exportDialog = new SaveFileDialog
            {
                Filter = "Секретный тип (*.fomenko)|*.fomenko",
                RestoreDirectory = true
            };

            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                string exportMessage = "";

                foreach (var exportString in exportData)
                {
                    exportMessage += $"{exportString}\r";
                }

                File.WriteAllText(exportDialog.FileName, $"{exportMessage}\r");

                MessageBox.Show("База данных успешно выгружена",
                    "Выгрузка БД",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }


        public static List<string> DownLoadDataBase()
        {

            return null;
        }
    }
}
