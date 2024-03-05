using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_4
{
    internal class MainSem4
    {

        public void Run() 
        {
            // Task 1. Дан список целых чисел. Вывести список без повторов.

            /*var listTask1 = new List<int>{ -1, 34, 1, 3, 7, 14, 3, 55, -1};            
            *//*var resTask1 = new HashSet<int>();

            foreach (var item in listTask1)
                resTask1.Add(Math.Abs( item ));
            
            foreach (var item in resTask1)
                Console.Write(item + " ");

            Console.WriteLine();*/

            /*var resTask1_2 = new HashSet<int>(listTask1);
            foreach (var item in resTask1_2)
                Console.Write(item + " ");*//*

            Console.WriteLine();

            var resTask1_1 = new List<int>();
            foreach (var item in listTask1)
            {

                if (!resTask1_1.Any(x => x == item || x == -item))
                    resTask1_1.Add(item);
                
            }
            foreach (var item in resTask1_1)
            {
                Console.Write(item + " ");
            }*/


            // Task 2. Дан список целых чисел. Вывести упорядоченно частоты повторений.
            /*var listTask2 = new List<int> { 1, 34, 1, 3, 7, 14, 3, 55, 1, 14, 3, 1 };
            var dictTask2 = new Dictionary<int, int>();

            foreach (var item in listTask2)
            {
                if(!dictTask2.ContainsKey(item))
                {
                    dictTask2.Add(item, 1);
                }
                else dictTask2[item]++;
            }

            var resTask3 = dictTask2.OrderBy(x => x.Value);

            foreach (var item in resTask3)
            {
                Console.WriteLine($"'{item.Key}'\tкол-во {item.Value}");
            }

            PriorityQueue<int, int> priorityTask2 = new PriorityQueue<int, int>();
            foreach (var item in resTask3)
            {
                priorityTask2.Enqueue(item.Key, item.Value);
            }
            while (priorityTask2.Count > 0)
            {
                Console.WriteLine(priorityTask2.Dequeue());
            }*/

            // Task 3. Дан список студентов. Отфильтровать кому более 20 и отсортировать по алфавиту
            /*List<Student> listStudent = new List<Student>();
            var st1 = new Student() { FullName = "Den", Age = 20 };
            var st2 = new Student() { FullName = "Ben", Age = 21 };
            var st3 = new Student() { FullName = "Poll", Age = 19 };
            var st4 = new Student() { FullName = "Maria", Age = 18 };
            var st5 = new Student() { FullName = "Ulya", Age = 22 };
            var st6 = new Student() { FullName = "Sveta", Age = 20 };
            var st7 = new Student() { FullName = "Ken", Age = 22 };

            listStudent.Add(st1);
            listStudent.Add(st2);
            listStudent.Add(st3);
            listStudent.Add(st4);
            listStudent.Add(st5);
            listStudent.Add(st6);
            listStudent.Add(st7);

            listStudent = listStudent.Where(x => x.Age >= 20).OrderBy(x => x.FullName).ToList();

            foreach (var item in listStudent)
            {
                Console.WriteLine(item);
            }*/


            // Task 4. Дан список целых чисел. Вывести упорядоченно частоты повторений  впорядке убывания.
            /*var listTask4 = new List<int> { 1, 34, 1, 3, 7, 14, 3, 55, 1, 14, 3, 1 };
            var dictTask4 = new Dictionary<int, int>();

            foreach (var item in listTask4)
            {
                if (!dictTask4.ContainsKey(item))
                {
                    dictTask4.Add(item, 1);
                }
                else dictTask4[item]++;
            }

            var resTask3 = dictTask4.OrderBy(x => x.Value);
            var resReversTask3 = dictTask4.OrderByDescending(x => x.Value);

            foreach (var item in resTask3)
                Console.WriteLine($"'{item.Key}'\tкол-во {item.Value}");
            
            Console.WriteLine();

            foreach (var item in resReversTask3)
                Console.WriteLine($"'{item.Key}'\tкол-во {item.Value}");

            Console.WriteLine();




            PriorityQueue<int, int> priorityTask2 = new PriorityQueue<int, int>();
            foreach (var item in resTask3)
            {
                priorityTask2.Enqueue(item.Key, -item.Value);
            }
            while (priorityTask2.Count > 0)
            {
                Console.WriteLine(priorityTask2.Dequeue());
            }*/


            // Task 5. Вывести первые пять, пропустив перед этим три. Возраст > 20, отсорт по имени.
            
            List<Student> listStudent = new List<Student>();
            var st1 = new Student() { FullName = "Den", Age = 20 };
            var st2 = new Student() { FullName = "Ben", Age = 21 };
            var st3 = new Student() { FullName = "Poll", Age = 19 };
            var st4 = new Student() { FullName = "Maria", Age = 18 };
            var st5 = new Student() { FullName = "Ulya", Age = 22 };
            var st6 = new Student() { FullName = "Sveta", Age = 20 };
            var st7 = new Student() { FullName = "Ken", Age = 22 };
            var st8 = new Student() { FullName = "Fanny", Age = 24 };
            var st9 = new Student() { FullName = "Molly", Age = 18 };
            var st10 = new Student() { FullName = "Kurt", Age = 22 };

            listStudent.Add(st1);
            listStudent.Add(st2);
            listStudent.Add(st3);
            listStudent.Add(st4);
            listStudent.Add(st5);
            listStudent.Add(st6);
            listStudent.Add(st7);
            listStudent.Add(st8);
            listStudent.Add(st9);
            listStudent.Add(st10);

            listStudent = listStudent.Skip(3).Take(5).Where(x => x.Age >= 20).OrderBy(x => x.FullName).ToList(); ;
            foreach (var item in listStudent)
                Console.WriteLine(item);
        }
    }
}
