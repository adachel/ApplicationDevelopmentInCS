using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork7
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class CustomNameHW7Attribute : Attribute
    {
        public string? CustomName { get; set; }

        public CustomNameHW7Attribute(string? name)
        {
            CustomName = name;
        }
    }
}
