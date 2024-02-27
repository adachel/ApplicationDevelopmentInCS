using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Transformation
{
    internal class MethodBits2
    {
        public void Run() 
        {
            // явное
            var a = new Bits(20);

            byte b = a;

            Console.WriteLine(b);
            // неявное
            b = 21;

            a = (Bits)b;

            Console.WriteLine(a.Value);
        }
    }
}
