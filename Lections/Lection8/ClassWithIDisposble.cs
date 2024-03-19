using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection8
{
    internal class ClassWithIDisposble : IDisposable
    {
        private bool disposedValue;

        /// <summary>
        /// ////////////////////////////////////////////////////////////
        /// </summary>
        // private int handle;  // поле как указатель на открытый ОС объект

        private ClassWithIDisposble another;  // ссылка на еще один класс

        public ClassWithIDisposble() // пусть класс создает ресурс автоматически
        {
            //OpenRes();
            Console.WriteLine("Я создан");
        }

        /*private void OpenRes() // метод открывает ресурс. после вызова этого метода создается указатель на на ресурс
        {
            handle = 123;
        }*/

        /*private void CloseRes() // метод открывает ресурс. когда класс уничтожается, обязательно должны вызвать этот метод
        { }*/


        /// <summary>
        /// ///////////////////////////////////////////////////////////
        /// </summary>

        /*protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты)
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }*/

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~ClassWithIDisposble()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    another?.Dispose(); // вызываем Dispose(); для этого класса
                }

                another = null;
                // CloseRes();  // затем этот класс
                disposedValue = true;
                Console.WriteLine("Я уничтожен коррктно");
            }
        }

        // если Dispose() объекта происходит из пользовательского кода, над кот мы имеем контроль,
        // то Dispose() вызывается с Dispose(disposing: true)[метод public void Dispose()], и это означает,
        // что мы можем очищать любые внутренние ресурсы.
        // Если Dispose() вызывается из финализатора, а финализатор из гарбколлектора,
        // то вызываем ~ClassWithIDisposble() с параметром Dispose(disposing: false), это означает,
        // что мы не уничтожаем те управляемые ресурсы, ссылка на которые есть в нашем классе. 

        /*~ClassWithIDisposble() // для закрытия, вызвали финализатор
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: false);
        }*/

        /// </summary>

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void DoSomeWork()
        {
            Console.WriteLine("DoSomeWork"); 
        }
    }
}
