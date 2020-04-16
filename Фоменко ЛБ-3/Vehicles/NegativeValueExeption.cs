using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    /// <summary>
    /// Дистанция не может быть отрицательной
    /// </summary>
    public class NegativeValueExeption : Exception
    {
        //TODO: (v) XML
        // Тогда и это нафиг не надо (см ТУДУ ниже)
        /// <summary>
        /// Название величины, которая не может быть отрицательной
        /// </summary>
        //private string _argumentForMessage;

        /// <summary>
        /// Исключение, уведомляющее о том, что величина не может быть отрицательной
        /// </summary>
        /// <param name="argument">Величина, которая не должна быть отрицательной</param>
        public NegativeValueExeption(string argument) :
            base($"{argument} не может быть отрицательным числом") { }
        

        //TODO: (v) XML или, если передать в конструктор base - можно не перегружать свойство
        // Наверное, эстетичнее в конструктор поместить

        //public override string Message => 
        //    $"{_argumentForMessage} не может быть отрицательным числом";
    }
}
