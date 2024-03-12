using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS
{
    internal class B
    {
        public void MethodB()
        {
            Console.WriteLine("Метод класса В");
        }

        public void MetB() 
        { 
            MyDeleg myDeleg = MethodB; 
        }
    }
}
