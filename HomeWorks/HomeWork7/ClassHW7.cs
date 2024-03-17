using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork7
{
    internal class ClassHW7
    {


        [CustomNameHW7("AnotherName")]
        public string fff;

        // [CustomNameHW7("oooooooooooo")]
        public int iii;


        public int I {  get; set; }
        public string? S { get; set; }

        [DontSaveHW7] 
        public decimal D { get; set; }

        
        public char[]? Chars { get; set; } = new char[] {};

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

        public ClassHW7(string fff, int i, string? s, decimal d, char[]? chars)
        {
            this.fff = fff;
            I = i;
            S = s;
            D = d;
            Chars = chars;
        }

        public ClassHW7(string fff, int iii, int i, string? s, decimal d, char[]? chars)
        {
            this.fff = fff;
            this.iii = iii;
            I = i;
            S = s;
            D = d;
            Chars = chars;
        }

        public override string? ToString()
        {
            return $"fff : {fff}; \niii : {iii}; \nI = {I}; \nS = {S}; \nD = {D}; \nCh = {String.Concat<char>(Chars)}";
        }
    }
}
