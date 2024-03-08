using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_5
{
    internal interface ICalculator
    {
        double Sum(double number);  // сложение
        double Subtraction(double number); // вычитание
        double Multiply(double number); // уумножение
        double Divide(double number);    // деление

        event EventHandler<EventArgs> GotResult;
    }
}
