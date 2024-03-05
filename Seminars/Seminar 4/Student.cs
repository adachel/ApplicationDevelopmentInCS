using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_4
{
    internal class Student
    {
        public string? FullName { get; set; }
        public int Age { get; set; }

        public override string? ToString()
        {
            return $"Имя - {FullName},\tвозраст - {Age}";
        }
    }
}
