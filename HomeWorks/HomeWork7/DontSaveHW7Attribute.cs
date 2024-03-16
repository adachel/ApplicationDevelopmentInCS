using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork7
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class DontSaveHW7Attribute : Attribute
    {
        public DontSaveHW7Attribute() { }
    }
}
