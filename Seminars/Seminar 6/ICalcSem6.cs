namespace ApplicationDevelopmentInCS.Seminars.Seminar_6
{
    internal interface ICalcSem6
    {
        void Sum(double number);
        void Subtract(double number);
        void Multiply(double number);
        void Divide(double number);

        event EventHandler<ChangedEventArgsSem6> GotResult;

        event EventHandler<ChangedEventArgsSem6>? GotNumber;
    }
}
