using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar7
{
    internal class TestClass
    {
        
        public int I { get; set; }

        [DontSaveForTask3Atribute] // из task3. Свойство не должно подлежать сохранению.
        public string? S { get; set; }
        public decimal D { get; set; }
        public char[]? C { get; set; }

        public TestClass()
        {
        }

        public TestClass(int i)
        {
            I = i;
        }

        public TestClass(int i, string? s, decimal d, char[]? c) : this(i) // использует собственный конструктор, кот принимает (i)
        {
            S = s;
            D = d;
            C = c;
        }
    }
}
