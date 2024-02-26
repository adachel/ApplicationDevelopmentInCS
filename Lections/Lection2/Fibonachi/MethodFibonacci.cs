using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Fibonachi
{
    internal class MethodFibonacci
    {
        public void Run()
        {
            /*var fibo = new Fibonacсi();
            for (int i = 0; i <= 8; i++)
            {
                Console.Write(fibo + " ");
                fibo++;
            }*/

            var plus = new Fibonacсi() + 8;  // когда переопределили сложение
            Console.WriteLine(plus);
        }
    }
}
