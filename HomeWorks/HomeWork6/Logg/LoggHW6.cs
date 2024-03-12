using System.Text;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork6.Logg
{
    internal class LoggHW6
    {
        public Stack<(double, string, double)> logg = new Stack<(double, string, double)>();

        public void AddLogg(double number1, string operation, double number2)
        {
            logg.Push(new(number1, operation, number2));
        }
        public string GetLogg()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("StackTrace: ");

            foreach (var item in logg)
            {
                sb.Append(item.ToString());
            }
            return sb.ToString();
        }
    }
}
