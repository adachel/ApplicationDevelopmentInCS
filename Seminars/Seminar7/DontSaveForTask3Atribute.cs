using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar7
{
    [AttributeUsage(AttributeTargets.Property)] // для управления атрибутами свойств класса
    internal class DontSaveForTask3Atribute : Attribute
    {
        public DontSaveForTask3Atribute()
        {
        }
    }
}
