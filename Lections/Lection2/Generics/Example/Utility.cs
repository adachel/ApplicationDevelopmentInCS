using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Generics.Example
{
    internal class Utility // Обобщенный тип. Отсюда все убираем
    {
        public static void Swap<T>(ref T v1, ref T v2)  // <T> ставим в метод
        {
            T temp = v1;
            v1 = v2;
            v2 = temp;
        }
    }
}
