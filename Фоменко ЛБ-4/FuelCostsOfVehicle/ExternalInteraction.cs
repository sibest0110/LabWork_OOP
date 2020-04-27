using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Vehicles;

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

        /// <summary>
        /// Импорт базы данных. В качестве возвращаемого значения - новый глобальный список ТС
        /// </summary>
        /// <returns></returns>
        public static List<VehiclesBase> DownLoadDataBase()
        {
            List<VehiclesBase> newTotalList = new List<VehiclesBase> { };

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
                string[] importMessage =
                    File.ReadAllText(importDialog.FileName).Split('\r');

                foreach (string importString in importMessage)
                {
                    if (importString == "")
                    {
                        continue;
                    }

                    string[] vehicleInfo =
                        importString.Replace("\\|/", "`").Split('`');

                    string name = vehicleInfo[1];
                    double weight = Convert.ToDouble(vehicleInfo[2]);
                    switch (vehicleInfo[0])
                    {
                        case "Car":
                        {
                            newTotalList.Add(new Car(name, weight));
                            break;
                        }
                        case "HybridCar":
                        {
                            newTotalList.Add(new HybridCar(name, weight));
                            break;
                        }
                        case "Helicopter":
                        {
                            newTotalList.Add(new Helicopter(name, weight));
                            break;
                        }
                    }
                }
                MessageBox.Show(
                "База данных успешно загружена",
                "Импорт БД",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                return newTotalList;
            }
            throw new Exception("Импорт БД прерван");
        }
    }
}
