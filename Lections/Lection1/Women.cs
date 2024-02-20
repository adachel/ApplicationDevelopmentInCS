using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection1
{
    class Women : Person
    {
        // переопределение свойств
        // protected override string HelloPhrase { get => base.HelloPhrase; set => base.HelloPhrase = value; }
        protected override string HelloPhrase => "Женщина";  // или проще


        public bool HasMakeup { get; private set; } = false;  // изначально у женцины нет макияжа

        public Women(string name) : base(name)
        {
        }

        public Women(string name, DateTime birthDate) : base(name, birthDate)
        {
        }

        public Women(string name, DateTime birthDate, int height) : base(name, birthDate, height)
        {
        }

        // наносит макияж
        public void PutMakeup()
        {
            Console.WriteLine("Наносит макияж");
            HasMakeup = true;

            // смывает макияж
        }
        public void RemoveMakeup()
        {
            Console.WriteLine("Смывает макияж");
            HasMakeup = false;
        }

        // переопределение методов
        public sealed override void SayHello()  // 'sealed' - запрещает переопределять метод у потомков
        {
            Console.WriteLine("Моя жена Елена Владимировна");
        }

        // обращение к базовому методу
        public void SayHelloLikeParent()
        {
            base.SayHello();        // для обращения в методу из родительского класса без изменений исп 'base'
        }
    }
}
