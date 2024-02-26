using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Record
{
    internal class MethodRecord
    {
        public void Run() 
        {
            /*var valueRec = new ValueRecord(10) { b = 25, c = 20 };
            valueRec.b = 30;
            // rec.a = 14;  // ругается, менять уже нельзя, только для a

            Console.WriteLine(valueRec);  // ToString уже переопределен. Показывает все поля со значениями*/

            /*var referensRec = new ReferensRecord(123) { b = 3453445, c = 456464 };
            var r2 = referensRec;
            r2.b = 20;

            Console.WriteLine(referensRec);
            Console.WriteLine(r2);

            Console.WriteLine();

            var valueRec = new ValueRecord(123) { b = 3453445, c = 456464 };
            var vr2 = valueRec;
            vr2.b = 20;

            Console.WriteLine(valueRec);
            Console.WriteLine(vr2);*/


            var referensRec = new ReferensRecord(123) { b = 3453445, c = 456464 };
            var r2 = referensRec with { b = 55 };  // используем with, создается копия и не важно reference или value
            var r3 = referensRec with { c = 5 };

            Console.WriteLine(referensRec);
            Console.WriteLine(r2);
            Console.WriteLine(r3);
        }
    }
}
