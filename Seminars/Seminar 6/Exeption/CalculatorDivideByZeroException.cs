using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_6.Exeption
{
    internal class CalculatorDivideByZeroException : Exception
    {
        public CalculatorDivideByZeroException(string? message) : base(message)
        {}
    }
}
