using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork6.Exeption
{
    internal class CalculateOperationCauseOverflowExceptionHW6 : Exception
    {
        public CalculateOperationCauseOverflowExceptionHW6(string? message) : base(message)
        {
        }
    }
}
