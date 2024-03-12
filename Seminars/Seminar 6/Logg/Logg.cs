using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_6.Logger
{
    internal class Logg
    {
        public Stack<(double, string, double)> logg = new Stack<(double, string, double)>();

        public void AddLogg(double number1, string operation, double number2)
        {
            logg.Push(new (number1, operation, number2));
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
