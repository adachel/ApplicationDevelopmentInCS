using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection1
{
    public sealed class Man : Person  // слово 'sealed' запрещает создавать потомков
    {
        // переопределение свойств
        // protected override string HelloPhrase { get => base.HelloPhrase; set => base.HelloPhrase = value; }
        protected override string HelloPhrase => "Мужчина";  // или проще


        public Man(string name) : base(name)
        {
        }

        public Man(string name, DateTime birthDate) : base(name, birthDate)
        {
        }

        public Man(string name, DateTime birthDate, int height) : base(name, birthDate, height)
        {
        }

        // добавим мужчине свойство иметь бороду
        public bool HasBeard { get; private set; } = true;

        // метод бритья бороды
        public void Shave()
        {
            Console.WriteLine("Бреется");
            this.HasBeard = false;
        }

        // Переопределение методов
        public override void SayHello()
        {
            Console.WriteLine("Здравствейте уважаемый Дмитрий Александрович");
        }

        public void SayHelloLikeParent()
        {
            base.SayHelloPhrase();        // для обращения в методу из родительского класса без изменений исп 'base'
        }


        // скрытый метод
        public new void Print()  // в базовом классе уже есть такой метод, поэтома нужно слово 'new'
        {
            Console.WriteLine("11111111");
        }
    }
}
