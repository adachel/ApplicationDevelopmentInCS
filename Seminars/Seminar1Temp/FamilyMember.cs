using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar1
{
    internal  class FamilyMember
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public FamilyMember Father { get; set; }
        public FamilyMember Mother { get; set; }
        public DateTime BirthDate { get; internal set; }

        public void InfoPerson()    // инфо о члене семьи
        {
            Console.WriteLine($"Личные данные: Имя - {Name}, Пол - {Gender}, Отец - {Father?.Name}, Мать - {Mother?.Name}");
        }

        public void InfoParents() // инфо о родителях
        {
            Console.WriteLine($"{Name}, родители: Отец - {Father?.Name}, Мать - {Mother?.Name}");
        }

        public void InfoGrandParents()  // инфо о дидах
        {
            Console.WriteLine($"{Name} - Отцовская линия: {Father?.Father.Name}, {Father?.Mother.Name}"
                    + "\n" + $"{Name} - Материнская линия: {Mother?.Father.Name}, {Mother?.Mother.Name}");
        }

        public virtual void InfoChildren() { } // инфо о детях


        public virtual void InfoBrothersAndSisters() { }



        public void Info(int indent = 0)    // вывод древа от предка
        {
            Console.WriteLine($"{new String('-', indent)}Имя: {this.Name}");
        }



        public virtual void Print(int indent = 0)   // метод вывода
        {
            Info(indent);
        }

    }
}
