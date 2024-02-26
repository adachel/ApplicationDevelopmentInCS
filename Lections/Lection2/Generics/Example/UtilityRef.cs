using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Generics.Example
{
    class UtilityRef<T>  // здесь и референс сработает
    {
        public static void Swap(ref T v1, ref T v2)  // меняем две переменные
        {
            T temp = v1;
            v1 = v2;
            v2 = temp;
        }
    }
}
