using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vehicles;
using System.Reflection;

namespace FuelCostsOfVehicle
{
    /// <summary>
    /// Форма для добавления ТС
    /// </summary>
    public partial class AddVehicleForm : Form
    {
        /// <summary>
        /// Полный список ТС
        /// </summary>
        private List<VehiclesBase> _totalVehicleList;

        //TODO: (V) глобальный словарь ТС
        /// <summary>
        /// Тип ТС и название типа
        /// </summary>
        private static Dictionary<Type, string> _vehicleTypesAndStrings =
            new Dictionary<Type, string>
            {
                {typeof(Car), nameof(Car)},
                {typeof(HybridCar), nameof(HybridCar)},
                {typeof(Helicopter), nameof(Helicopter)},
            };

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public AddVehicleForm()
        {
            InitializeComponent();



            foreach (var type in _vehicleTypesAndStrings)
            {
                comboBoxTypesOfVehicles.Items.Add(type.Value);
            }
        }

        /// <summary>
        /// Конструктор с сылкой на главную форму и полный список ТС
        /// </summary>
        /// <param name="totalVehicleList">Полный список ТС</param>
        public AddVehicleForm(List<VehiclesBase> totalVehicleList)
            : this()
        {
            _totalVehicleList = totalVehicleList;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Program.CheckWeight(sender as Control);

                _totalVehicleList.Add(
                    CreateVehicleByString(
                        comboBoxTypesOfVehicles.Text,
                        textBoxNameVehicle.Text,
                        textBoxWeightVehicle.Text));



                textBoxNameVehicle.Text = "";
                textBoxWeightVehicle.Text = "";

                MessageBox.Show("Транспортное средство добавлено!",
                    "Добавление ТС",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                switch (MessageBox.Show("Добавить ещё одно ТС?", "Добавление ТС",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question))
                {
                    case DialogResult.No:
                    {
                        this.Close();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                            $"{ex.Message}",
                            "Внимание",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Создание ТС по строковым параметрам
        /// </summary>
        /// <param name="type">Тип ТС</param>
        /// <param name="name">Название ТС</param>
        /// <param name="weight">Масса ТС в кг</param>
        /// <returns></returns>
        public static VehiclesBase CreateVehicleByString(string type, string name, string weight)
        {
            Type typeClass = null;

            //TODO: (v) Со стрингами разобрался

            #region ВАРИАНТ 1 (Мне больше нравится)

            // Так как у нас список _vehicleTypesAndStrings формируется
            // в одном месте и тут мы ссылаемся на это же место,
            // гарантированно найдёнся одно соответствие названия типа и 
            // самого типа

            foreach (var vehicle in _vehicleTypesAndStrings)
            {
                if (type == vehicle.Value)
                {
                    typeClass = vehicle.Key;
                }
            }

            if (typeClass == null)
            {
                throw new Exception("Не найден тип ТС (см метод CreateVehicleByString)");
            }

            #endregion

            #region ВАРИАНТ 2

            //switch (type)
            //{
            //    case nameof(Car):
            //    {
            //        typeClass = typeof(Car);
            //        break;
            //    }
            //    case nameof(HybridCar):
            //    {
            //        typeClass = typeof(HybridCar);
            //        break;
            //    }
            //    case nameof(Helicopter):
            //    {
            //        typeClass = typeof(Helicopter);
            //        break;
            //    }
            //    default:
            //    {
            //        throw new Exception("Не указан тип ТС");
            //    }
            //}

            #endregion

            //получаем конструктор
            ConstructorInfo paramCons = typeClass.GetConstructor(
                new Type[] { typeof(string), typeof(double) });


            //вызываем конструтор
            return (VehiclesBase)paramCons.Invoke(
                new object[] { name, Convert.ToDouble(weight) });
        }
    }
}
