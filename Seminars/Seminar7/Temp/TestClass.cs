using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar7.Temp
{
    internal class TestClass
    {
        
        public int I { get; set; }
        public char[]? C { get; set; }
        [DontSave]
        public string? S { get; set; }
        public decimal D { get; set; }

        /*[CustomName("CustomFieldName")]
        public string F = "Hello";*/

        public TestClass(int i)
        {
            I = i;
        }

        public TestClass()
        {
        }

        public TestClass(int i, char[]? c, string? s, decimal d) : this(i)
        {
            C = c;
            S = s;
            D = d;
            /*F = f;*/
        }


        private string QWE(char[] ch)
        {
            if (ch == null)
            {
                return "null";
            }
            else return String.Concat<char>(ch);
        }



        /*public override string? ToString()
        {
            return $"I = {I};\nS = {S};\nD = {D};\nCh = {QWE(C)}";
        }*/
    }
}
