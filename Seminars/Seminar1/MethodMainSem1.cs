using ApplicationDevelopmentInCS.Seminars.Seminar1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar1
{
    internal class MethodMainSem1
    {
        public void MethodMain()
        {

            var grandFatherFather = new FamilyMember() { Name = "Николай", Gender = Gender.Male, Father = null, Mother = null };
            var grandMotherFather = new FamilyMember() { Name = "Татьяна", Gender = Gender.Female, Father = null, Mother = null };

            var grandFatherMother = new FamilyMember() { Name = "Михаил", Gender = Gender.Male, Father = null, Mother = null };
            var grandMotherMother = new FamilyMember() { Name = "Валентина", Gender = Gender.Female, Father = null, Mother = null };

            var father = new FamilyMember() { Name = "Александр", Gender = Gender.Male, Father = grandFatherFather, Mother = grandMotherFather };
            var mother = new FamilyMember() { Name = "Екотерина", Gender = Gender.Female, Father = grandFatherMother, Mother = grandMotherMother };
            
            var sonFirst = new FamilyMember() { Name = "Дмитрий", Gender = Gender.Male, Father = father, Mother = mother };
            var sonTwo = new FamilyMember() { Name = "Сергей", Gender = Gender.Male, Father = father, Mother = mother };

            var fillArray = new FamilyMemberService();
            fillArray.AddPerson(grandFatherFather, grandMotherFather, grandFatherMother, grandMotherMother, father, mother, sonFirst, sonTwo);

            //foreach (var person in fillArray.GetGrandFathers(sonFirst))
            //{
            //    Console.Write(person);
            //}

            Console.WriteLine(sonTwo.ToString);




        }
    }
}
