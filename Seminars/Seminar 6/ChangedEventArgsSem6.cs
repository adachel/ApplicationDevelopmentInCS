namespace ApplicationDevelopmentInCS.Seminars.Seminar_6
{
    internal class ChangedEventArgsSem6 : EventArgs
    {
        private double operand;
        public double Operand
        {
            get
            {
                return operand;
            }
            set
            {
                operand = value;
            }
        }
        public ChangedEventArgsSem6(double operand) => Operand = operand;

    }
}
