using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork3
{
    internal class MainHW3
    {
        // Доработайте приложение поиска пути в лабиринте, но на этот раз вам нужно определить сколько всего выходов имеется в лабиринте:

        // int[,] labirynth1 = new int[,]
        // {
        // {1, 1, 1, 1, 1, 1, 1 },
        // {1, 0, 0, 0, 0, 0, 1 },
        // {1, 0, 1, 1, 1, 0, 1 },
        // {0, 0, 0, 0, 1, 0, 0 },
        // {1, 1, 0, 0, 1, 1, 1 },
        // {1, 1, 1, 0, 1, 1, 1 },
        // {1, 1, 1, 0, 1, 1, 1 }
        // };

        // Сигнатура метода:  static int HasExit(int startI, int startJ, int[,] l)

        static int HasExit(int startI, int startJ, int[,] labirynth)
        {
            var temp = new Queue<(int, int)>();
            
            int i = startI;
            int j = startJ;
            
            int counter = 0;

            if (labirynth[i, j] == 1) return 0;
            else
            {
                while (labirynth[i, j] != 1 || temp.Count > 0)
                {
                    if (labirynth[i, j] == 2) { counter++; }

                    if ((i - 1) >= 0 && labirynth[(i - 1), j] != 1) temp.Enqueue(((i - 1), j));
                    if ((i + 1) < labirynth.GetLength(0) && labirynth[(i + 1), j] != 1) temp.Enqueue(((i + 1), j));
                    if ((j - 1) >= 0 && labirynth[i, (j - 1)] != 1) temp.Enqueue((i, (j - 1)));
                    if ((j + 1) < labirynth.GetLength(1) && labirynth[i, (j + 1)] != 1) temp.Enqueue((i, (j + 1)));

                    labirynth[i, j] = 1;

                    if (temp.Count > 0)
                    {
                        (i, j) = temp.Dequeue();
                    }
                    
                }
            }
            return counter;
        }


        public void Run()
        {
            int[,] labirynth = new int[,]
            {
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 0, 0, 0, 0, 0, 1 },
            {1, 0, 1, 1, 1, 0, 1 },
            {2, 0, 0, 2, 1, 0, 0 },
            {1, 1, 0, 2, 1, 1, 1 },
            {1, 1, 1, 0, 1, 1, 1 },
            {1, 1, 1, 2, 1, 1, 1 }
            };

            var res = HasExit(3, 0, labirynth);

            if (res == 0)
            {
                Console.WriteLine("при такой стартовой точке выходов нет");
            }
            else Console.WriteLine("Выходов: " + res);

        }
    }
}
