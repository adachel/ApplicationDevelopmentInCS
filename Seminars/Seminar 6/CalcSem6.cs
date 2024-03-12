using ApplicationDevelopmentInCS.Seminars.Seminar_6.Exeption;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_6
{
    internal class CalcSem6 : ICalcSem6
    {
        private Stack<double> stack = new Stack<double>();

        public event EventHandler<ChangedEventArgsSem6>? GotResult;

        public event EventHandler<ChangedEventArgsSem6>? GotNumber;

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

        public void RaiseEvent() => GotResult?.Invoke(this, new ChangedEventArgsSem6(Result));

        public void RaiseEventNum() => GotNumber?.Invoke(this, new ChangedEventArgsSem6(Result));


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
                throw new CalculateOperationCauseOverflowException("Превышено допустимое число!");
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
                throw new CalculateOperationCauseOverflowException("Превышено допустимое число!");
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
                throw new CalculateOperationCauseOverflowException("Превышено допустимое число!");
            }
        }

        public void Divide(double number)
        {
            try
            {
                checked
                {
                    if (number == 0)
                        throw new CalculatorDivideByZeroException("Деление на ноль!\n");

                    Result /= number;
                }
            }
            catch (OverflowException)
            {
                throw new CalculateOperationCauseOverflowException("Превышено допустимое число!");
            }
        }
    }
}
