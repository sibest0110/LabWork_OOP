using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Vehicles;
using System.Runtime.Serialization.Formatters.Binary;

namespace FuelCostsOfVehicle
{
    //TODO: (v) XML
    /// <summary>
    /// Клас для взаимодействия со внешними файлами
    /// </summary>
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
        public static void UpLoadDataBase(List<VehiclesBase> exportData)
        {
            SaveFileDialog exportDialog = new SaveFileDialog
            {
                Filter = "Секретный тип (*.fomenko)|*.fomenko",
                RestoreDirectory = true
            };

            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream
                    (exportDialog.FileName, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, exportData);
                    MessageBox.Show("База данных успешно выгружена",
                        "Выгрузка БД",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Импорт базы данных. В качестве возвращаемого значения - новый глобальный список ТС
        /// </summary>
        /// <returns></returns>
        public static List<VehiclesBase> DownLoadDataBase()
        {
            MessageBox.Show(
                "Загрузка базы данных приведёт к потере текущей БД",
                "Загрузка БД",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            OpenFileDialog importDialog = new OpenFileDialog
            {
                Filter = "Секретный тип (*.fomenko)|*.fomenko",
                RestoreDirectory = true
            };

            if (importDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream
                    (importDialog.FileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter formatter = new BinaryFormatter();

                    List<VehiclesBase> newTotalList =
                        (List<VehiclesBase>)formatter.Deserialize(fs);

                    MessageBox.Show(
                        "База данных успешно загружена",
                        "Импорт БД",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return newTotalList;
                }
            }
            throw new Exception("Импорт БД прерван");
        }
    }
}
