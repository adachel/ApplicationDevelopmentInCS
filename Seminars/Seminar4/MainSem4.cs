using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar4
{
    internal class MainSem4
    {

        public void Run()
        {
            // Task1. Дан список целых чисел, в кот некоторые числа повторяются. Выведите список, исключив повторы.
            var listTask1 = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 1, 3, 5 });
            var task1 = new HashSet<int>();
            foreach (var item in listTask1)
            {
                task1.Add(item);
            }
            foreach (var item in task1) 
            {
                Console.Write(item + " ");
            }
            
        }

    }
}
