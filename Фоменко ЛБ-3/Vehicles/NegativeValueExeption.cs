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
        private string _argumentForMessage;

        /// <summary>
        /// Исключение, уведомляющее о том, что величина не может быть отрицательной
        /// </summary>
        /// <param name="argument">Величина, которая не должна быть отрицательной</param>
        public NegativeValueExeption(string argument) : base()
        {
            _argumentForMessage = argument;
        }
        public override string Message => 
            $"{_argumentForMessage} не может быть отрицательным числом";
    }
}
