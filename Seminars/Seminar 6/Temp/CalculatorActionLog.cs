using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_6.Temp
{
    internal class CalculatorActionLog
    {
        public CalculatorAction CalcAction;
        public int CalcArgument;

        public CalculatorActionLog(CalculatorAction calcAction, int calcArgument)
        {
            this.CalcAction = calcAction;
            this.CalcArgument = calcArgument;
        }
    }
}
