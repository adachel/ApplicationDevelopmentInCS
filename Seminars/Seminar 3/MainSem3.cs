using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_3
{
    internal class MainSem3
    {
        public static void ViewList(List<int> list) 
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        public static List<int> ReversList(List<int> list)
        { 
            var tempList = new List<int>();
            var tempStack = new Stack<int>();
            foreach (var item in list)
            {
                tempStack.Push(item);
            }
            while (tempStack.Count > 0) 
            {
                tempList.Add(tempStack.Pop());
            }
            return tempList;
        }

        static bool HasExit(int startI, int startJ, int[,] labirynth)  // для task3
        {
            var coords = new Queue<(int, int)>();
            if (labirynth[startI, startJ] != 1)
            {
                coords.Enqueue((startI, startJ));
            }
            while (coords.Count > 0)
            {
                (int i, int j) = coords.Dequeue();
                if (labirynth[i, j] == 2) return true;

                labirynth[i, j] = 1;


                if (i - 1 >= 0 && labirynth[i - 1, j] != 1) coords.Enqueue((i -1, j));
                if (i + 1 < labirynth.GetLength(0) && labirynth[i + 1, j] != 1) coords.Enqueue((i + 1, j));
                if (j - 1 >= 0 && labirynth[i, j - 1] != 1) coords.Enqueue((i, j - 1));
                if (j + 1 < labirynth.GetLength(1) && labirynth[i, j + 1] != 1) coords.Enqueue((i, j + 1));


            }
            return false;
        }

        public void Run() 
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Task1. Через стек инвертировать список

            /*var task1 = new List<int>(new int[] { 1, 2, 3, 4, 5 });
            ViewList(task1);
            var res = ReversList(task1);
            ViewList(res);*/

            ////////////////////////////////////////////////////////////////////////////////
            // Task 2. Pеализоваит класс поддержка IEnumerable<int> CastumEnumerable, кот в случае исп его в
            // foreich(var x in new CastumEnumerable()){ Console.WriteLine(x); } выведет на экран значения от 0 до 10.
            // Подумайте, возможно придется использовать еще и IEnumerator.

            /*foreach (var x in new CustumEnumerable())
            { 
                Console.Write(x + " "); 
            }

            foreach (var x in new CustumEnumerable())
            {
                Console.Write(x + " ");
            }*/

            ///////////////////////////////////////////////////////////////////////////////////////////
            // Task 3. Дан лабиринт, найти точку входа "0"

            int[,] labirynth = new int[,]
            {
                {1, 1, 1, 0, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 2 },
                {1, 1, 0, 0, 1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1 }
            };

            if (HasExit(3, 0, labirynth))
                Console.WriteLine("Выход найден");
            else Console.WriteLine("Выход не найден");





        }
    }
}
