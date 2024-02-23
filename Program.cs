using ApplicationDevelopmentInCS.Lections.Lection1;
using ApplicationDevelopmentInCS.Seminars.Seminar1;

namespace ApplicationDevelopmentInCS
{
    partial class Program  // partial - для него можно делать реализацию в отдельном файле. Если метод partial - то же самое
    {
        

        static void Main(string[] args)
        {
            /*// Лекция 1
            var lec1 = new MethodsMeinLection1();
            lec1.MethodMain();*/

            var seminar1 = new MethodMainSem1();
            seminar1.MethodMain();


            
        }
    }
}
