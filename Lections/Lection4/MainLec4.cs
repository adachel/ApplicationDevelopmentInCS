using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection4
{
    internal class MainLec4
    {
        struct SomeStruct()
        {
            public int? X = 0;
        }
        class SomeClass
        {
            public int X = 0;
        }
        /// /////////////////////////////////////////////////////////////////////

        static int[] buckets = new int[10];
        static DictionaryEntry[] entries = new DictionaryEntry[10];
        static int c = 0;

        static void Add(object key, object value)
        {
            int bucketNum = key.GetHashCode() & 0x7fffffff % buckets.Length;
            buckets[bucketNum] = c;
            entries[c].Value = value;
            c++;
        }
        static object Get(object key)
        {
            int bucketNum = key.GetHashCode() & 0x7fffffff % buckets.Length;
            return entries[buckets[bucketNum]].Value!;
        }

        /// ///////////////////////////////////////////////////////////////////////////


        public void Run()
        {
            /*var o = new Object();
            int i = o.GetHashCode();
            Console.WriteLine(o.GetHashCode());     // одинаковый хэшкод
            Console.WriteLine(i.GetHashCode());     // хэшкод значения равен самому значению*/

            // Equals. Сравнивает тек экземпляр объекта с экз, переданным в метод. Если они идентичны, то вернет true, иначе false.
            // Для рефов, является ли объект одним экз путем сравнения ссылок на это объекты. Для value метод сравнивает значения.

            /*// для value
            var a = new SomeStruct { X = 10 };
            var b = new SomeStruct { X = 10 };
            Console.WriteLine(a.Equals(b));
            
            // для рефов
            var aref = new SomeClass { X = 10 };
            var bref = new SomeClass { X = 10 };
            Console.WriteLine(aref.Equals(bref));*/

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Коллекция Dictionary или словарь представляет собой хранилище элементов типа ключ-значение. Ключем может быть любой объект.
            // Стоимость О(1) иногда О(n).

            /*Add(5, "Elevent5");
            Add(6, "Elevent6");
            Console.WriteLine(Get(5));
            Console.WriteLine(Get(6));*/

            // var dicEmpty = new Dictionary<string, string>();  // самый частый
            //var dicList = new Dictionary<string, int>(new List<KeyValuePair<string, int>> {new KeyValuePair<string, int> ("1", 1) });
            //var dicDict = new Dictionary<string, int>(dicList);

            //dicEmpty["Россия"] = "Москва";
            //dicEmpty["Украина"] = "Киев";
            //dicEmpty["Беларусь"] = "Минск";
            //dicEmpty["Казахстан"] = "Астана";

            /*Console.WriteLine(dicEmpty.Count());  // сколько пар

            foreach (var key in dicEmpty.Keys)
            {
                Console.Write(key + " ");  // список ключей
            }
            Console.WriteLine();
            foreach (var value in dicEmpty.Values)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
            Console.WriteLine(dicEmpty["Россия"]);*/

            // если попытаемся извлеч значение, кот не сущ, то получим ошибку

            // dicEmpty.Add("США", "Вашингтон");  // добавление элемента

            // !!! ВСЕ КЛЮЧИ УНИКАЛЬНЫ
            /*if (!dicEmpty.TryAdd("Россия", "Воронеж"))  // проверяет на наличие 
            {
                Console.WriteLine("Такой ключ уже есть!");
            }

            Console.WriteLine(dicEmpty.ContainsKey("США"));     // проверяет на наличие
            Console.WriteLine(dicEmpty.ContainsValue("Киев"));  // проверяет на наличие

            dicEmpty.Clear();  // очищает*/

            //dicEmpty.Remove("Россия");
            //Console.WriteLine(dicEmpty.ContainsKey("Россия"));
            //Console.WriteLine(dicEmpty.ContainsValue("Москва"));
            /*f(dicEmpty.Remove("Россия", out string val))  // значение удаляемого ключа
            {
                Console.WriteLine(val);
            }*/

            // другое название словаря - хэш таблица

            // пример: подсчет уникальных слов в тексте

            /*var dictText = new Dictionary<string, int>();
            var sb = new StringBuilder();
            string str = "Я текст текст текст, подсчитай, сколько уникальных слов слов";
            foreach (var item in str)
            {
                if(Char.IsLetter(item))  // если буква
                {
                    sb.Append(item);
                }
                else 
                {
                    if (sb.Length > 0)
                    {
                        var key = sb.ToString().ToLower(); // в нижний регистр
                        if (dictText.ContainsKey(key))
                        {
                            dictText[key]++;
                        }
                        else dictText[key] = 0;
                        sb.Clear();
                    }
                }
            }
            if (sb.Length > 0)
            {
                var key = sb.ToString().ToLower();
                if (dictText.ContainsKey(key))
                {
                    dictText[key]++;
                }
                else dictText[key] = 0;
                sb.Clear();
            }

            foreach (var item in dictText)
            {
                Console.WriteLine($"{item.Key} = {item.Value + 1}");
            }*/
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Коллекция HashSet<T> или множество. Работает по аналогии с Dictionary, но хранит только значения. Стоимость О(1) иногда О(n).

            /*var hashSetEmpty = new HashSet<int>();
            var hashSetInt = new HashSet<int>(new int[] { 1, 2, 3, 4, 5 });
            var hashSetHashSet = new HashSet<int>(hashSetInt);

            var count = hashSetInt.Count;  // длина множества
            hashSetInt.Add(123);    // добавляет только уникальные
            hashSetInt.Add(1);      // этот не добавит и ошибку не даст
            hashSetInt.Remove(1);   // удаляет элементы

            Console.WriteLine(hashSetInt.Contains(1));  // есть ли элемент*/

            // операции над множествами
            //var hashSet1 = new HashSet<int>(new int[] { 1, 2, 3, 4, 5, 6 });
            //var hashSet2 = new HashSet<int>(new int[] { 1, 2, 3, 4, 123 });

            // hashSet1.SymmetricExceptWith(hashSet2);     // уникальные элементы обоих множеств

            // hashSet1.IntersectWith(hashSet2);   // выводит только совпадающие

            // Console.WriteLine(hashSet1.Overlaps(hashSet2));     // пересекаются ли множества

            // hashSet1.UnionWith(hashSet2);   // объединение множеств. Порядок не учитывается

            //var e = hashSet1.SetEquals(new int[] { 1, 2, 3, 4, 5 });     // соответствует или нет
            //Console.WriteLine(e);

            //foreach (var item in hashSet1)
            //{
            //    Console.Write(item + " ");
            //}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// Задача: дан массив целых чисел и искомое число. Найти в массиве два числа, сумма кот равна искомому. Минус - это память.
            /// 
            /*int[] arr = { 1, 2, 3, 44, 5, 6, 7, 8, 9, 10, 11 };  // искомое 50
            int target = 50;

            // вариант с for. Стоимость О(n^2)
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target)
                    {
                        Console.WriteLine($"{arr[i]} + {arr[j]}");
                    }
                }
            }

            // вариант через HashSet. Стоимость О(n)
            var hashSet = new HashSet<int>();
            foreach (var item in arr)
            {
                var temp = target - item;
                if (hashSet.Contains(temp))
                {
                    Console.WriteLine($"{temp} + {item}");
                }
                else hashSet.Add(item);
            }*/
            //////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Коллекция PriorityQueue. Приоритетная очередь, позволяет считывать элементы в порядке заланного приоритета, 
            ///при этом очередность элем с одинаковым приоритетом не гарантируется.
            ///
            /*var pq = new PriorityQueue<string, int>();
            pq.Enqueue("Elem1", 1);
            pq.Enqueue("Elem2", 2);
            pq.Enqueue("Elem3", 3);
            pq.Enqueue("Elem4", 1);
            pq.Enqueue("Elem5", 5);
            pq.Enqueue("Elem6", 6);
            pq.Enqueue("Elem7", 7);

            while (pq.Count > 0)
                Console.WriteLine(pq.Dequeue());*/
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// Коллекция SortedDictionary. Так же как и словарь, только все элементы отсортированы
            /// 
            /*var sd = new SortedDictionary<string, int>();
            sd["2"] = 2;
            sd["1"] = 1;
            sd["110"] = 110;
            sd["3"] = 3;
            sd["5"] = 5;

            foreach (var item in sd)
            {
                Console.WriteLine(item.Key);  // сорт по ключу, а ключ здесь стринг, будет: 1, 100, 2, 3,5
            }*/

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///Коллекция SortedSet.
            ///
            /*var ss = new SortedSet<int>();
            ss.Add(2);
            ss.Add(1);
            ss.Add(10);
            ss.Add(100);
            ss.Add(5);
            ss.Add(8);

            foreach (var item in ss)
            {
                Console.WriteLine(item);
            }*/

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            /*var list = new List<int> { 1, 2, 3, 4, 5 };

            var a = list.AsReadOnly(); // нельзя менять исходную. То же самое можно делать со словарем

            var b = list.ToList();  // cоздаем новую по ссылке

            b[0] = 123123123;       // меняем

            list.ForEach(Console.WriteLine);
            b.ForEach(Console.WriteLine);*/

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///LINQ - встроенный язык запросов. Методы расширений для IEnumerable
            ///

            string[] names = { "Анна", "Алена", "Елена", "Мария", "Екатерина" };
            // это через Енумиратор
            /*IEnumerable<string> wordsA = from name in names
                                         where name.StartsWith('А')     // возвращает имена на 'A'
                                        select name;
            foreach (var item in wordsA)
            {
                Console.WriteLine(item);
            }*/

            Console.WriteLine();

            // через LINQ
            /*IEnumerable<string> wordsLINQ1 = names.Where(x => x.StartsWith('А'));
            IEnumerable<string> wordsLINQ2 = names.Where(x => x.StartsWith('А')).Where(x => x[1] == 'н');

            foreach (var item in wordsLINQ2)
            {
                Console.WriteLine(item);
            }*/

            /*var namesA = from name in names
                         select
                         new { Name = name, StartsWithA = name.StartsWith('А') };
            foreach (var item in namesA)
            {
                Console.WriteLine($"{item.Name} starts with A {item.StartsWithA}");
            }*/

            int[] ints = { 9, 1, 2, 3, 4, 5, 6 };

            // var res = ints.OrderBy(x => x); // сортирует

            // var resRevers = ints(x => x); // в обратном порядке

            /*foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in resRevers)
            {
                Console.WriteLine(item);
            }*/

            // var resAgreg = ints.Aggregate((x, y) => x * y); // в данном случае перемножает все элементы
            // Console.WriteLine(resAgreg);

            // var resAll = ints.All(x => x > 0);  // все элем > 0?
            // Console.WriteLine(resAll);

            // var resAny = ints.Any(x => x == 5); // true, усли хоть один элем = 5

            // var resDist = ints.Distinct(); // избавляется от дубликатов при переборе

            /*var resExc = ints.Except(new int[] { 2, 3 });  // исключает из перебора
            foreach (var item in resExc)
            {
                Console.WriteLine(item);
            }*/

            // var resUni = ints.Union(new int[] { 2, 3, 12 });  // объединяет коллекциии, исключая дубликаты

            // var resInter = ints.Intersect(new int[] { 2, 3}); // вoзвращает элем, кот есть в обоих коллекциях    

            // var resCount = ints.Count(); // кол-во элем
            // var resCount = ints.Count(x => x % 2 == 0); // можно задавать условия предиката

            /*var resSum = ints.Sum(); // сумма всех элементов

            var resAver = ints.Average();  // среднее арифметическое
            var resMin = ints.Min();  // мин
            var resMax = ints.Max();  // мах

            var resTake = ints.Take(5);  // берет  5 первых элементов
            var resSkip = ints.Skip(2).Take(5);  // пропустили первые 2, взяли 5 следующих элементов
            var resTW = ints.TakeWhile(x => x < 5);  // где берем элементы меньше 5
            var resSW = ints.SkipWhile(x => x < 5);  // где не берем элементы меньше 5

            var resConcat = ints.Concat(ints); // объединяет коллекции*/

            var intss = new List<int> { 1, 2, 3, 4 };
            var chars = new List<char> { 'a', 'b', 'c', 'd' };

            /*var res = intss.Zip(chars, (i, c) => $"{i} = {c}"); // объеденили. Только совпадающие по кол-ву, остальных не будет, ошибки не будет.
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }*/

            // var res = intss.First(x => x == 1); // либо просто первый, либо по условию. Если пустая, то исключение.
            // var res = intss.FirstOrDefault(x => x == 1, -1); // если не найдет, то -1.
            // var res = intss.Single(x => x == 1); // первый элем, подходящий под условие, если их несколько, то исключение
            // var res = intss.SingleOrDefault(x => x == 1, 0); // если элем нет, то 0

            // var res = intss.ElementAt(0);  // возвр элем в указанной позиции, если позиция неврн, то исключ
            // var res = intss.ElementAtOrDefault(0);  // возвр элем в указанной позиции, если позиция неврн, то 0

            var res = intss.Select(x => "(" + x.ToString() + ")");  // преобразует каждый элемент в строку
            foreach (var item in res)
            {
                Console.Write(item);
            }
        }
    }
}
