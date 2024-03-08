using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_5
{
    internal class Calculator : ICalculator
    {
        public event EventHandler<EventArgs>? GotResult;
        private double result = 0;

        class ResultEvenArgs
        {
            public double Result { get; set; }
        }

        public void RaiseResult()
        { 
            
        }

        public double Divide(double number)
        {
            return result = result / number;
        }

        public double Multiply(double number)
        {
            return result = result * number;
        }

        public double Subtraction(double number)
        {
            return result -= number;
        }

        public double Sum(double number)
        {
            return result += number;
        }
    }
}
