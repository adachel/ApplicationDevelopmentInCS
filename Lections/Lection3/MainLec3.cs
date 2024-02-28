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

            // Capacity - емкость тек массива в памяти

            for (int i = 4; i < 20; i++)
            {
                // Console.Write(list1.Capacity + " ");  // 0 4 4 4 4 8 8 8 8 16 16 16 16 16 16 16 16 32 32 32
                list1.Add(i);
            }
            Console.WriteLine();

            // Count - сколко элементов в списке
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

            // Clear - чистит список, ПРИ ЭТОМ РАЗМЕР МАССИВА ОСТАЕТСЯ
            /*Console.WriteLine(list5.Count);
            Console.WriteLine(list5.Capacity);
            list5.Clear();
            Console.WriteLine(list5.Count);
            Console.WriteLine(list5.Capacity);*/

            // Contains - есть ли указанный элемент в списке. true или false
            // Console.WriteLine(list1.Contains(1));

            // ConvertAll -  конвертирует
            var ints = new List<int>() { 12, 2, 45, 6, 8, 23, 9 };
            var str = ints.ConvertAll<string>(new Converter<int, string>(Convert.ToString));
            foreach (var item in str)
            {
                //Console.Write(item + " ");
            }

            // CopyTo - копирует элементы списка в массив
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
                Console.Write(item + " ");
            }
        }
    }
}
