using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2
{
    internal class MethodMainLec2
    {
        public void Run()
        {
            /*PersonLec2[] people = new PersonLec2[] {
                new WomanLec2("Anna", DateTime.Parse("12.10.1990")),
                new WomanLec2("Maria", DateTime.Parse("22.12.1980")),
                new WomanLec2("Svetlana", DateTime.Parse("02.01.1999")),
                new ManLec2("Mike", DateTime.Parse("17.11.1985")),
                new ManLec2("Nik", DateTime.Parse("03.03.1979")),
                new ManLec2("Den", DateTime.Parse("08.10.1990"))
            };

            Array.Sort(people);

            foreach (var item in people)
            {
                item.Print();
            }*/


            // Анонимный класс
            var person1 = new ManLec2("Poma");
            var person2 = new ManLec2("Den");
            var person3 = new ManLec2("Ben");
            var person4 = new ManLec2("Poll");

            var group = new {Name1 = person1.Name, Name2 = person2.Name, Name3 = person3.Name, Name4 = person4.Name }; // создали анонимный класс

            Console.WriteLine(group);

        }
    }
}
