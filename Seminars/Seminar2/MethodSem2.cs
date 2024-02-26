using ApplicationDevelopmentInCS.Lections.Lection2.Transformation;
using Sem2;
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

            /*var newBits = new BitsSem2(55);

            for (int i = 0; i < newBits.Value; i++)
            {
                Console.WriteLine(newBits[i]);
            }

            
            Console.WriteLine(newBits.Value);*/


            IBitsSem2 bitsSem2 = new BitsSem2(99);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(bitsSem2.GetBits(i));
            }

            bitsSem2.SetBits(1, false);

            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(bitsSem2.GetBits(i));
            }

        }
    }
}
