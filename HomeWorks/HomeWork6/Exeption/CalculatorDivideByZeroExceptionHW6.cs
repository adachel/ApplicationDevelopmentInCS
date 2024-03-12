using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork6.Exeption
{
    internal class CalculatorDivideByZeroExceptionHW6 : Exception
    {
        public CalculatorDivideByZeroExceptionHW6(string? message) : base(message)
        {
        }
    }
}
