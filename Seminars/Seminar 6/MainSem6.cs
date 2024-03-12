using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_6
{
    internal class MainSem6
    {
        // В прошлой лекции мы реализовали метод CancelLast позволяющий отменить любое сделанное действие.
        // Реализуйте класс - список, описывающий последовательность действий приведших исключению.
        // Очевидно что класс калькулятора должен быть доработан чтобы хранить не только информацию
        // необходимую нам для отмены но и информацию о самом действии.

        public void Run()
        {
            MenuSem6 menu = new MenuSem6();
            menu.RunMenu();
        }
    }
}
