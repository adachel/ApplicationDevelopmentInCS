namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork6
{
    internal class ChangedEventArgsHW6 : EventArgs
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
        public ChangedEventArgsHW6(double operand) => Operand = operand;
    }
}
