using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_8
{
    internal class MainSem8
    {


        public void Run(string[] args) 
        {
            /*Task1 task1 = new Task1();
            task1.CreateFiles(args);*/

            /*Task2 task2 = new Task2();
            task2.ViewFile(args[0], args[1]);*/

            Task3 task3 = new Task3();
            task3.GetWord(args[0], args[1]);
        }
    }
}
