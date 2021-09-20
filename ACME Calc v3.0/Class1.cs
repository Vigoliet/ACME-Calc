using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_Calc_v3._0
{
    class CalculationEngine
    {
        public double Add(double number1, double number2)
        {
            return number1 + number2;
        }
        public double Multiply(double number1, double number2)
        {
            return number1 * number2;
        }
        public double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }
        public double Divide(double number1, double number2)
        {
            return number1 / number2;
        }
    }
}
