using ApplicationDevelopmentInCS.Seminars.Seminar2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork2
{
    internal class MethodHW2
    {
        public void Run()
        {
            var bitsHW2 = new BitsHW2(255);
            Console.WriteLine("начальное значение: " + bitsHW2.Value);
            Console.WriteLine();

            byte bt = 10;
            bt = bitsHW2;
            Console.WriteLine("не явное byte: " + bt);

            Console.WriteLine();

            bt = 10;
            bitsHW2 = (BitsHW2)bt;
            Console.WriteLine("явное byte: " + bitsHW2.Value);

            Console.WriteLine();

            long lng = 50;
            lng = bitsHW2;

            Console.WriteLine("не явное long: " + lng);

            Console.WriteLine();

            lng = 50;
            bitsHW2 = (BitsHW2)lng;
            Console.WriteLine("явное long: " + bitsHW2.Value);

            Console.WriteLine();

            int i = 100;
            i = bitsHW2;
            Console.WriteLine("не явное int: " + i);

            Console.WriteLine();

            i = 100;
            bitsHW2 = (BitsHW2)i;
            Console.WriteLine("явное int: " + bitsHW2.Value);

        }
    }
}
