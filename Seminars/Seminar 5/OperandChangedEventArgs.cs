using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_5
{
    class OperandChangedEventArgs(double operand) : EventArgs
    {
        public double Operand => operand;
    }
}
