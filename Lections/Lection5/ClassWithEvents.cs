using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection5
{
    public class ClassWithEvents
    {
        public event MyEvenHandler? SomeEven;

        protected void OnSomeEven(MyEvenArgs args)  // метод, вызывающий события
        {
            SomeEven?.Invoke(this, args);
        }

        public void DoSomeWork() // метод, генерирующий события
        {
            new Thread
                (
                    () =>
                    {
                        Thread.Sleep(10000);
                        OnSomeEven(new MyEvenArgs { Message = "Все" });
                    }
                ).Start();
        }
    }
}
