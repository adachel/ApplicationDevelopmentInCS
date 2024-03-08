using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_5
{
    internal interface ICalculator
    {
        void Sum(double number);  // сложение
        void Subtraction(double number); // вычитание
        void Multiply(double number); // уумножение
        void Divide(double number);    // деление
        void CancelLast(); // отменяет последнее действие

        event EventHandler<OperandChangedEventArgs> GotResult;
    }

    /*internal interface ICalculator
    {
        double Sum(double number);  // сложение
        double Subtraction(double number); // вычитание
        double Multiply(double number); // уумножение
        double Divide(double number);    // деление

        event EventHandler<OperandChangedEventArgs> GotResult;
    }*/
}
