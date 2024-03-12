using ApplicationDevelopmentInCS.HomeWorks.HomeWork6.Exeption;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork6
{
    internal class CalcHW6 : ICalcHW6
    {
        private Stack<double> stack = new Stack<double>();

        public event EventHandler<ChangedEventArgsHW6>? GotResult;

        public event EventHandler<ChangedEventArgsHW6>? GotNumber;

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

        public void RaiseEvent() => GotResult?.Invoke(this, new ChangedEventArgsHW6(Result));

        public void RaiseEventNum() => GotNumber?.Invoke(this, new ChangedEventArgsHW6(Result));


        public void Sum(double number)
        {
            try
            {
                checked
                {
                    Result += number;
                }
            }
            catch
            {
                throw new CalculateOperationCauseOverflowExceptionHW6("Превышено допустимое число!");
            }
        }

        public void Subtract(double number)
        {
            try
            {
                checked
                {
                    Result -= number;
                }
            }
            catch
            {
                throw new CalculateOperationCauseOverflowExceptionHW6("Превышено допустимое число!");
            }
        }

        public void Multiply(double number)
        {
            try
            {
                checked
                {
                    Result *= number;
                }
            }
            catch
            {
                throw new CalculateOperationCauseOverflowExceptionHW6("Превышено допустимое число!");
            }
        }

        public void Divide(double number)
        {
            try
            {
                checked
                {
                    if (number == 0)
                        throw new CalculatorDivideByZeroExceptionHW6("Деление на ноль!!!\n");

                    Result /= number;
                }
            }
            catch (OverflowException)
            {
                throw new CalculateOperationCauseOverflowExceptionHW6("Превышено допустимое число!");
            }
        }
    }
}
