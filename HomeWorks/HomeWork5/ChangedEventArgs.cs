using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork5
{
    internal class ChangedEventArgs : EventArgs
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

        public ChangedEventArgs(double operand)
        {
            Operand = operand;
        }
    }
}
