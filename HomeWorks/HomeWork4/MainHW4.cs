using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork4
{
    internal class MainHW4
    {
        public List<List<int>> SumNumbers(int[] arr, int target)
        {
            var result = new List<List<int>>();
            
            for (int i = 0; i < arr.Length; i++)
            {
                var hashSet = new HashSet<int>();
                var tempIter = target - arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    var temp = tempIter - arr[j];

                    if (hashSet.Contains(temp))
                    {
                        var tempArr = new List<int>();

                        tempArr.Add(arr[i]);
                        tempArr.Add(temp);
                        tempArr.Add(arr[j]);
                        
                        result.Add(tempArr);
                    }
                    else hashSet.Add(arr[j]);
                }
            }
            return result;
        }

        public void ViewResult(List<List<int>> list, int target)
        {
            if (list.Count > 0) 
            {
                for (int i = 0; i < list.Count; i++)
                    Console.WriteLine($"{target} = {list[i][0]} + {list[i][1]} + {list[i][2]}");
            }
            else Console.WriteLine("Вариантов нет");

        }
        public void Run()
        {
            // Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу.
            // Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части
            // два числа равных по сумме первому.

            int[] arr = { 1, 2, 1, 4, 2, 6, 3, 8, 9, 10 };
            int terget = 10;

            ViewResult(SumNumbers(arr, terget), terget);

            


        }
    }
}
