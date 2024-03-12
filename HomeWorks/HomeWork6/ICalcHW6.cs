namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork6
{
    internal interface ICalcHW6
    {
        void Sum(double number);
        void Subtract(double number);
        void Multiply(double number);
        void Divide(double number);

        event EventHandler<ChangedEventArgsHW6> GotResult;

        event EventHandler<ChangedEventArgsHW6>? GotNumber;
    }
}
