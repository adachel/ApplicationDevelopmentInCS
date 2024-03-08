using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_5
{
    internal class Calculator : ICalculator
    {
        public event EventHandler<OperandChangedEventArgs>? GotResult;
        // private double result = 0;
        private Stack<double> stack = new Stack<double>(); // ++

        // public double Result { get => result; set { result = value; RaiseResult(); } }
        public double Result 
        {
            get
            {
                return stack.Count() == 0 ? 0 : stack.Peek(); // если stack.Count() == 0 то возвр 0 иначе stack.Peek()
            }
            set 
            { 
                stack.Push(value); 
                RaiseEvent(); 
            } 
        } // ++

        public void RaiseEvent()
        {
            GotResult?.Invoke(this, new OperandChangedEventArgs(Result));
        }

        public void CancelLast()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
                RaiseEvent();
            }
        }

        public void Divide(double number)
        {
            Result /= number;
        }

        public void Multiply(double number)
        {
            Result *= number;
        }

        public void Subtraction(double number)
        {
            Result -= number;
        }

        public void Sum(double number)
        {
            Result += number;
        }
    }
}
