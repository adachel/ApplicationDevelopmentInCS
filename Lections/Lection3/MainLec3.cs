using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection3
{
    internal class MainLec3
    {

        public static void PrintBitArray(BitArray bitar)
        {
            foreach (var item in bitar)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public static bool IsCapital(string str)  // этот метод можно считать, что это пердикат
        {
            foreach (var item in str)
            {
                if (!Char.IsUpper(item))
                {
                    return false;   
                }
            }
            return true;

        }

        public static bool IsIven(int num)  // предикат, определяет, четное ли число
        {
            return num % 2 == 0;
        }

        public static int CompareInt(int x, int y)
        {
            return x.CompareTo(y) * -1;        
        }

        public static bool Positive(int x)  // предикат, все элементы положительные
        {
            return (x > 0);
        }

        public static bool Procces(int x)
        {
            if (x % 2 == 0)
            {
                return true;
            }
            return false;
        }

        public static void AlternativeProcces(int x) 
        {
            Console.WriteLine("Не могу обработать элемент: " + x);
        }

        public static IEnumerable<int> DataSourse()  // источник данных для очереди
        {
            for (int i = 0; i < 30; i++)
            {
                if (i < 25)
                {
                    yield return i;  // yield работает в связке с IEnumerable для синхроннной работы
                }
                else yield return i * i;
            }
            Console.WriteLine("Завершено");
        }

        static bool ValidPernthesis(string str)  // определяет корректность расстановки скобок
        {
            var stack = new Stack<Char>();
            foreach (var item in stack)
            {
                if (item == '(') stack.Push(')');
                if (item == '{') stack.Push('}');
                if (item == '[') stack.Push(']');
                if (")}]".Contains(item))
                { 
                    if (stack.Count == 0) return false;
                    if (stack.Count != 0) return false;
                }
            }
            return stack.Count == 0;    

        }


        public void Run()
        {
            /////////////////////////////////////////////////
            /// Коллекции
            /// ArrayList
            /// 
            var coll = new ArrayList();
            coll.Add("one");
            coll.Add(2);
            coll.Add(3.5);

            foreach (var item in coll)
            {
                // Console.Write(item + " ");
            }

            Console.WriteLine();

            int elem = (int)coll[1]!;   // явная типизация
            // Console.WriteLine(elem);

            // elem = (int)coll[0]!;   // получим исключение, тк [0] это string
            // Console.WriteLine(elem);

            ///////////////////////////////////////////////////////////////////////////
            /// BitArray
            /// 
            // var bitar = new BitArray(8, false);  // 8 элементов и все false
            
            var bits = new BitArray(new bool[] {true, false, false}); // можно так задать
            var bitar = new BitArray(new bool[] {true, true, false}); // можно так задать

            // 1 | 1 = 1
            // 1 | 0 = 1
            // 0 | 0 = 0
            // bitar.Or(bits);  // логическое "или". Длина должна быть одинакова.

            // 1 ^ 1 = 0
            // 1 ^ 0 = 1
            // 0 ^ 0 = 0
            // bitar.Xor(bits);

            // 1 & 1 = 1
            // 1 & 0 = 0
            // 0 & 0 = 0
            // bitar.And(bits);

            // PrintBitArray(bitar);

            ////////////////////////////////////////////////////////////////////////////////
            /// интерфейс IEnumerator
            /// 
            var list = new ArrayList() {1, 22, 3, 48, 6, 7, 12 };
            IEnumerator enumerator = list.GetEnumerator();  // перебирает коллекцию
            while (enumerator.MoveNext())
            {
                // Console.Write(enumerator.Current + " ");
            }

            ///////////////////////////////////////////////////////////////////////////////////
            /// интерфейс IComparer<T>
            /// 
            IComparer<int> comparer = new CustomIntComparer();
            int[] arr = new[] {1, 3, 6, 32, 45, 2, 22, 7, 12, 9};
            Array.Sort(arr, comparer);
            foreach (var item in arr)
            {
                // Console.Write(item + " ");
            }

            ///////////////////////////////////////////////////////////////////////////////////
            /// List<T>
            /// 
            var list1 = new List<int>();
            var list2 = new List<int>(new[] { 1, 3, 6, 32, 45 });
            var list3 = new List<int>(10);

            /*Console.WriteLine(list1.Capacity);  // кол-во элем, кот может хранить список, без увеличения его внутреннего хранилища
            Console.WriteLine(list2.Capacity);
            Console.WriteLine(list3.Capacity);*/

            /////////// Capacity - емкость тек массива в памяти

            for (int i = 4; i < 20; i++)
            {
                // Console.Write(list1.Capacity + " ");  // 0 4 4 4 4 8 8 8 8 16 16 16 16 16 16 16 16 32 32 32
                list1.Add(i);
            }
            Console.WriteLine();

            ///////// Count - сколко элементов в списке
            var list4 = new List<int>(20);
            for (int i = 0; i < 20; i++)
            {
                // O(const) - если добавляется елемент в пустое место
                // O(n) - при увеличении емкости
                list4.Add(i);   // добавляет элемент в конец списка
                // Console.Write(list4.Count + " ");
            }
            Console.WriteLine();
            // Console.WriteLine(list4[6]); // обращение по индексу

            var list5 = new List<int>();
            list5.Add(123);
            list5.AddRange(new[] { 1, 3, 4, 6 }); // добавление в список диапазона элементов
            foreach (var item in list5)
            {
                // Console.Write(item + " ");
            }
            Console.WriteLine();

            // BinarySearch - ищет индекс элемента а ОТСОРТИРОВАННОМ МАССИВЕ, если не найдет - выдаст отрицательное число
            // Console.WriteLine(list1.BinarySearch(7));

            ///////// Clear - чистит список, ПРИ ЭТОМ РАЗМЕР МАССИВА ОСТАЕТСЯ
            /*Console.WriteLine(list5.Count);
            Console.WriteLine(list5.Capacity);
            list5.Clear();
            Console.WriteLine(list5.Count);
            Console.WriteLine(list5.Capacity);*/

            // Contains - есть ли указанный элемент в списке. true или false
            // Console.WriteLine(list1.Contains(1));

            ////////// ConvertAll -  конвертирует
            var ints = new List<int>() { 12, 2, 45, 6, 8, 23, 9 };
            var str = ints.ConvertAll<string>(new Converter<int, string>(Convert.ToString));
            foreach (var item in str)
            {
                //Console.Write(item + " ");
            }

            //////// CopyTo - копирует элементы списка в массив
            ints = new List<int>() { 12, 2, 45, 6, 8, 23, 9, 123, 54 };
            int[] array = new int[ints.Count];
            ints.CopyTo(array);
            foreach (var item in array)
            {
                // Console.Write(item + " ");
            }
            Console.WriteLine();
            int[] array1 = new int[ints.Count + 5];
            ints.CopyTo(array1, 5);  // сдвигает копируемый список на  позиций, копирует весь список
            foreach (var item in array1)
            {
                // Console.Write(item + " ");
            }
            Console.WriteLine();
            int[] array2 = new int[ints.Count];
            ints.CopyTo(1, array2, 0, 3); // где 1 - с этого индекса копирует, 3 - сколько копирует. "2 45 6 0 0 0 0 0 0"
            foreach (var item in array2)
            {
                // Console.Write(item + " ");
            }

            ////////// EnsureCapacity - задает размероность нового маасива для работы
            var mass = new List<int>() { 1, 2 ,3 , 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var mass2 = new List<int>() { };
            mass2.EnsureCapacity(mass.Count);  // задали сразу размерность нового массива

            /////////// Equals - сравнение. Не знаю, зачем он нужен
            var qmass1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var qmass2 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            // Console.WriteLine(qmass1.Equals(qmass2));  // считает, что они разные

            ////////// Условие для поиска - наличие всех заглавных букв в строке
            ///
            /// Предикат - это метод, кот принимает на вход элемент, тип кот равен типу элементов в списке, и в зависимости от прохождения 
            /// какого-то своего внутреннего условия предикат возвращает true или false иными словами буллево значение. 
            /// Т.е предикат это спец метод, имеющий критерий определения подходит ли элемент под условие. 
            /// 
            var strList1 = new List<string>() { "AAAA", "qwerrt? ", "qEEWsdf", "QWEsfsdQWREW", "ZXC" };

            var x =  strList1.Find(IsCapital);  // метод Find использует предикат как способ определения того подходит ли очередной элемент списка нашему критерию. Ищет только первый элемент.
            var y =  strList1.FindLast(IsCapital);  // Ищет только последний элемент.
            var xy =  strList1.FindAll(IsCapital);  // Ищет все элементы.
            foreach (var item in xy)
            {
                // Console.Write(item + " ");
            }
            //Console.WriteLine();
            //Console.WriteLine(x);
            //Console.WriteLine(y);

            // var xInd = strList1.FindIndex(IsCapital);  // находит индекс первого элемента
            // var xInd = strList1.FindIndex(1, IsCapital);  // искать от индекса 1

            ///////// Метод поиска всех индексов
            var yInd = strList1.FindIndex(IsCapital);
            if (yInd >= 0)
            {
                // Console.WriteLine(yInd);
                yInd++;
            }
            while (yInd >= 0 && yInd < strList1.Count) 
            {
                yInd = strList1.FindIndex(yInd, IsCapital);
                if (yInd >= 0)
                {
                    // Console.WriteLine(yInd);
                    yInd++;
                }
            }

            ////////

            // strList1.ForEach(Console.WriteLine);  // Показывает все элементы без фокусов

            // Console.WriteLine(strList1.IndexOf("AAAA"));  // выдаст индекс, если элемент есть, и -1, если нет

            // strList1.Insert(1, "qqqqqqqqqqq");  // вставляет элемент в список
            strList1.InsertRange(1, new string[] { "asdasdads", "cbcbcvbc", "retertet" });  // вставляет список элементои в список
            strList1.Remove("qEEWsdf"); // удаляет элемент по значению
            // Console.WriteLine(strList1.Remove("qEEWsdf"));  // выдаст false, т.к такого элемента уже нет

            while (strList1.Remove("qEEWsdf")); // удалит все элементы с заданным значением

            // strList1.ForEach(Console.WriteLine);

            var qmass3 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var co =  qmass3.RemoveAll(IsIven);  // принимает предикат и возвращает кол-во удаленных элементов. Удалил все четные.
            // Console.WriteLine("четных было: " + co);

            // qmass3.RemoveAt(0);  // удаляет по индексу
            qmass3.RemoveRange(1, 5); // удаляет с 1 по 5 элементы

            qmass3.Reverse();  // переворачивает список
            qmass3.Reverse(2, 4);  // переворачивает со 2 по 4

            qmass3.Sort(); // сортирует по возрастанию
            qmass3.Sort(CompareInt); // меняем порядок сортировки

            //  qmass3.ForEach(Console.WriteLine);

            var qmass4 = new List<int>() { 1, -2, 3, 4, -5, 6, 7, -8, 9, 0, 1, -2, 3, 4, 5, 6, -7, 8, 9, 0, 1, -2, 3, 4, 5, 6, -7, 8, 9, 0 };
            var re = qmass4.TrueForAll(Positive);  // удовлетворенность списка условию. В данном случае проверяет, все ли элементы положительные
            // Console.WriteLine(re);


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            /// В классе, реализующим List есть спец переменная, кот наз vertion. При создании списка она = 0. 
            /// Каждый раз, когда мы модифицируем список эта переменная увеличивается на 1.При получении инумиратора, 
            /// он запоминает это поле и сравнивает его значение с оригинальным перед каждвм вызовом moveNext. 
            /// Если значение version не совпало, это означает, что список был изменен и его перебор с помощью текущего инумиратора может привести к ошибке,
            /// поэтому в случае обнаружения несовпадениия version, инумиратор вызывает исключающую ситуацию. 

            var qmass5 = new List<int>() { 1, -2, 3, 4, -5, 6, 7, -8, 9 };
            foreach (var item in qmass5)
            {
                // Console.WriteLine(item);
                // qmass5.Clear();             // выдаст исключение Unhandled exception. System.InvalidOperationException: Collection was modified;
                                            // enumeration operation may not execute. at System.Collections.Generic.List`1.Enumerator.MoveNext()
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // НЕДОСТАТКИ КОЛЛЕКЦИИ LIST
            // - относительно низкая скорость удаления и вставки элементов
            // - наличие хранилища, размер кот зачастую не соотв кол-ву элементов списка
            // List или список является обобщенным братом-близнецом ArrayList. Эту коллекцию нужно использовать, когда вам нужен функционал массива,
            // но при этом бы имелась возможность добавления элементов.


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            // Для частой вставки и удаления, сохраняя очередность есть LinkedList
            // LinkedList не хранит данные во внутреннем массиве. Вместо этого даннные организованы в специальные классы-узлы списка,
            // где каждый элемент хранит ссылку на предыдущий и следующий. На самом деле это двусвязный список.
            // НЕДОСТАТОК: нет возможности обратится по индексу. 

            var linkList = new LinkedList<int>();  // пустой
            var linkList1 = new LinkedList<int>(new int[] {1, 2, 3, 4 });  // пустой
            linkList1.Count(); // кол-во элементов списка
            //Console.WriteLine(linkList1.First?.Value);  // указывает на первый 
            //Console.WriteLine(linkList1.Last?.Value);  // указывает на последний

            linkList1.AddAfter(linkList1.First, 123); // вставка 123 после первого
            linkList1.AddBefore(linkList1.First, 12323); // вставка 12323 перед первым
            linkList1.AddFirst(00000); // вставка первым
            linkList1.AddLast(999999999); // вставка последним

            // linkList1.Clear();  // очистка

            //var sss = new int[] { };
            //linkList1.CopyTo(sss, 5);  // копируем список в массив

            // linkList1.Remove(999999999); // удаление по значению
            linkList1.RemoveFirst(); // удаление первого
            linkList1.RemoveLast(); // удаление последнего




            // переберем элементы c конца
            var nodeLast = linkList1.Last;
            while (nodeLast != null)
            {
                // Console.WriteLine(nodeLast.Value);
                nodeLast = nodeLast.Previous;  // присваиваем ссылку на предыдущий элемент
            }
            var nodeFirst = linkList1.First;
            Console.WriteLine();
            // переберем элементы c начала
            while (nodeFirst != null)
            {
                // Console.WriteLine(nodeFirst.Value);
                nodeFirst = nodeFirst.Next;  // присваиваем ссылку на предыдущий элемент
            }

            //////////////////////////////////////////////////////////////////////////////////////
            // ОЧЕРЕДЬ

            var q = new Queue<int>(new int[] {2, -5, 3, 345});
            // методв теже, что и list

            q.Enqueue(1);  // добавляет элемент в конец очереди
            var element = q.Dequeue(); // получает элемент из очереди и удаляет его начиная с первого
            
            // Console.WriteLine(element);

            var pee = q.Peek();  // получает элемент, но не удаляет
            // Console.WriteLine(pee);

            //while (q.TryDequeue(out int xxx))  // TryDequeue - true, если элемент есть, и false усли нет
            //{
            //    Console.WriteLine(xxx);
            //} 

            //while (q.Count > 0)
            //{
            //    if (Procces(q.Peek()))
            //    {
            //        q.Dequeue();
            //    }
            //    else
            //    {
            //        AlternativeProcces(q.Dequeue());
            //    }
            //}

            //Console.WriteLine();
            //foreach (var item in q)
            //{
            //    Console.WriteLine(item);
            //}



            
            // задача, не получать последние 5 значений

            // q = new Queue<int>();
            //foreach (var item in DataSourse())
            //{
            //    q.Enqueue(item);
            //    if (q.Count > 5)
            //    {
            //        Console.WriteLine(q.Dequeue());
            //    }
                
            //}


            //////////////////////////////////////////////////////////////////////////////////////////
            /// STACK

            var stack = new Stack<int>(new int[] { 1, 2, 3, 4, 5});
            var queue = new Queue<int>(new int[] { 1, 2, 3, 4, 5});

            //Console.WriteLine(stack.Peek());    // последний элемент попал в стек 5, и извлекается первой 5
            //Console.WriteLine(queue.Peek());  // первый элемент, попавший в очередь это 1

            stack.Pop();    // достает и  удаляет

            foreach (var item in stack)
            {
                // Console.WriteLine(item);
            }

            stack.Push(1111); // добавление элемента

            foreach (var item in stack)
            {
                // Console.WriteLine(item);
            }

            while (stack.TryPop(out int z))
            {
                // Console.WriteLine(z);
            }

            var aarr = stack.ToArray();  // преоразование стека в масси элементов



            string brakets = "(){}[](())[[]{}]";
            Console.WriteLine(ValidPernthesis(brakets));

        }
    }
}
