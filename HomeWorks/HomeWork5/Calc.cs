using ApplicationDevelopmentInCS.Seminars.Seminar_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork5
{
    internal class Calc : ICalc
    {
        private Stack<double> stack = new Stack<double>();

        public event EventHandler<ChangedEventArgs>? GotResult;

        public event EventHandler<ChangedEventArgs>? GotNumber;

        public double Result
        {
            get
            {
                return stack.Count == 0 ? 0 : stack.Peek();
            }
            set
            {
                stack.Push(value);
                RaiseEvent();
            }
        }

        public void FirstNumber(double number) => stack.Push(number); 

        public void CancelLast()
        {
            if (stack.Count > 0) stack.Pop();
            RaiseEventNum();
        }

        public void RaiseEvent() => GotResult?.Invoke(this, new ChangedEventArgs(Result));

        public void RaiseEventNum() => GotNumber?.Invoke(this, new ChangedEventArgs(Result));


        public void Sum(double number) => Result += number;

        public void Subtract(double number) => Result -= number;

        public void Multiply(double number) => Result *= number;

        public void Divide(double number) => Result /= number;
    }
}
