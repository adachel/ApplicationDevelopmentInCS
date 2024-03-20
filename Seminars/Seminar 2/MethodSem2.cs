using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar2
{
    internal class MethodSem2
    {
        public void Run()
        {
            var bitsSem2 = new BitsSem2(255);
            Console.WriteLine("начальное значение: " + bitsSem2.Value);
            Console.WriteLine();

            // byte явное
            byte bt = 10;
            bt = bitsSem2;
            Console.WriteLine("явное byte: " + bt);

            Console.WriteLine();

            // byte неявное
            bt = 10;
            bitsSem2 = (BitsSem2)bt;
            Console.WriteLine("не явное byte: " + bitsSem2.Value);

            Console.WriteLine();

            // long явное
            long lng = 50;
            lng = bitsSem2;
            Console.WriteLine("явное long: " + lng);

            Console.WriteLine();

            // long неявное
            lng = 50;
            bitsSem2 = (BitsSem2)lng;
            Console.WriteLine("не явное long: " + bitsSem2.Value);

            Console.WriteLine();

            // int явное
            int i = 100;
            i = bitsSem2;
            Console.WriteLine("явное int: " + i);

            Console.WriteLine();

            // int неявное
            i = 100;
            bitsSem2 = (BitsSem2)i;
            Console.WriteLine("не явное int: " + bitsSem2.Value);


            byte bbb = 10;
            long llll = 50;
            llll = bbb;


        }
    }
}
