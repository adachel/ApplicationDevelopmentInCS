using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar1.Service
{
    internal class FamilyMemberService
    {
        public List<FamilyMember> Family { get; private set; }

        public FamilyMemberService()
        {
            Family = new List<FamilyMember>();
        }

        public void AddPerson(params FamilyMember[] person)   // у меня без params. Не работает, params нужен
        {
            if (person != null && person.Length > 0)
            {
                Family.AddRange(person);
            }

        }

        public List<FamilyMember> GetGrandFathers(FamilyMember person)
        {
            List<FamilyMember> grandFather = new List<FamilyMember>();
            grandFather.Add(person.Father.Father);
            grandFather.Add(person.Mother.Father);
            return grandFather;
        }

        public List<FamilyMember> GetGrandMothers(FamilyMember person)
        {
            List<FamilyMember> grandMother = new List<FamilyMember>();
            grandMother.Add(person.Father.Mother);
            grandMother.Add(person.Mother.Mother);
            return grandMother;
        }


    }
}
