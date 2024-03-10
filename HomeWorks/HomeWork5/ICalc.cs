using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork5
{
    internal interface ICalc
    {
        void Sum(double number);
        void Subtract(double number);
        void Multiply(double number);
        void Divide(double number);

        event EventHandler<ChangedEventArgs> GotResult;

        event EventHandler<ChangedEventArgs>? GotNumber;
    }
}
