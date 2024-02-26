using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Generics
{
    internal class HeirSimpleTuple<T1> : SimpleTuple<T1, int> // второй аргумент принудительно int
    {
        public HeirSimpleTuple(T1 t1, int t2) : base(t1, t2)
        {
        }
    }
}
