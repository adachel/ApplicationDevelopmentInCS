using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork7
{
    internal class ClassHW7
    {

 
        // [CustomNameHW7("CustomFieldName")]
        public string fieldClass;

        public int I {  get; set; }
        public string? S { get; set; }

        
        public decimal D { get; set; }

        [DontSaveHW7] 
        public char[]? Chars { get; set; } = null;

        public ClassHW7()
        {
        }
        public ClassHW7(int i)
        {
            I = i;
        }

        public ClassHW7(int i, string s, decimal d, char[]? chars) : this (i)
        {
            S = s;
            D = d;
            Chars = chars;
        }

        public ClassHW7(string fieldClass, int i, string? s, decimal d, char[]? chars)
        {
            this.fieldClass = fieldClass;
            I = i;
            S = s;
            D = d;
            Chars = chars;
        }

        /*private string QWE(char[] ch)
        {
            if (ch == null)
            {
                return "null";
            }
            else return String.Concat<char>(ch);
        }


        public override string? ToString()
        {
            return $"fieldClass = {fieldClass};\nI = {I};\nS = {S};\nD = {D};\nCh = {QWE(Chars)}";
        }*/
    }
}
