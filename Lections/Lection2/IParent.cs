using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2
{
    internal interface IParent
    {
        public bool GetChildren(out PersonLec2[] children);  // возвращает массив объектов типа PersonLec2
        public void TakeCare(); // ф-ция, реализующая заботу о детях
    }
}
