using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar1.Models
{
    internal class FamilyMember
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public FamilyMember Father { get; set; } 
        public FamilyMember Mother { get; set; }
        // public DateTime BirthDate { get;  set; }


        public override string ToString() => Name;
       

    }
}
