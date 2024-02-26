using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2
{
    internal abstract class PersonLec2 : IComparable, IParent
    {
        public string Name = string.Empty; 
        public DateTime BirthDate;

        protected PersonLec2(string name)
        {
            Name = name;
        }

        public PersonLec2(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public readonly int Height;                  

        public PersonLec2 Father = null!;
        public PersonLec2 Mother = null!;
        public PersonLec2[] Children = null!;





        public int CompareTo(object? obj)
        {
            // throw new NotImplementedException();

            if (obj == null)
            {
                return -1;
            }
            return this.BirthDate.CompareTo((obj as PersonLec2).BirthDate);
        }

        public void Print()
        {
            Console.WriteLine($"Имя - {Name}, Дата рождения - {BirthDate}, Рост - {Height}");
        }


        public override string? ToString()
        {
            return $"Имя - {Name}, Дата рождения - {BirthDate}";
        }

        public bool GetChildren(out PersonLec2[] children)
        {
            if (Children != null && Children.Length != 0)
            {
                children = Children;
                return true;
            }
            else 
            {
                children = null;
                return true;   
            }

        }

        protected abstract void TakeCareImplementation(); // создаем абстр метод

        public void TakeCare() // убираем абстракность
        {
            if (Children != null)
                TakeCareImplementation(); // абстр метод вставляет сюда
        }









    }
}