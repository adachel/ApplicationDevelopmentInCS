using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection1
{
    public static class StringUse  // статический класс 
    {
        static StringUse()
        {
            Console.WriteLine("конструктор вызван");
        }

        public static string StringReverse(this string str)  // метод переворачивает строку. this - для расширения
        { 
            return new string(str.ToCharArray().Reverse().ToArray());
        }
    }
}
