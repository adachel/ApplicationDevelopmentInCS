using ApplicationDevelopmentInCS.Lections.Lection2.Generics.Covariant;
using ApplicationDevelopmentInCS.Lections.Lection2.Generics.Example;
using ApplicationDevelopmentInCS.Lections.Lection2.Generics.GenericInterface;
using ApplicationDevelopmentInCS.Lections.Lection2.Generics.LimitationGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Metrics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Generics
{
    internal class MethodGenerics
    {
        public void Run()
        {
            /*Tuple<int, string> tuple = new Tuple<int, string>(1, "qwe");

            SimpleTuple<int, string> simpleTuple = new SimpleTuple<int, string>(12312313, "asdasafadfs");

            Console.WriteLine(tuple);
            Console.WriteLine(simpleTuple);

            SimpleTuple<SimpleTuple<int, string>, SimpleTuple<int, string>> tupleTuples = new SimpleTuple<SimpleTuple<int, string>, SimpleTuple<int, string>>(simpleTuple, simpleTuple);
            Console.WriteLine(tupleTuples);*/

            /*HeirSimpleTuple<String> heirSimpleTuple = new HeirSimpleTuple<string>("string", 12313243);
            Console.WriteLine(heirSimpleTuple);*/

            // var s = new GenericClass<object>(); // создать не можем, т.к. есть ограничения
            //var s1 = new GenericClassValueType<int>();  // так работает

            //var s2 = new GenericClassReferenceType<StringBuilder>();  // доступны референсные типы

            /*var qwe = new GenericClassName<PersonLec2>(); // ограничения по имени
            var qwe1 = new GenericClassName<ManLec2>(); // ограничения по имени
            var qwe2 = new GenericClassName<WomanLec2>(); // ограничения по имени*/

            /*var iqwe = new GenericClassInterface<PersonLec2>();  // интерфейс поддерживается в классе PersonLec2
            var iqw2 = new GenericClassInterface<WomanLec2>();  // наследник с реализацией*/

            //////////////////////////////////////////////////////////////////////////////////////////////////////
            // пример
            /*int a = 20;
            int b = 2000000;

            UtilityStruct<int>.Swap(ref a, ref b);

            Console.WriteLine($"{a}, {b}");

            string str1 = "20";
            string str2 = "200002020";
            UtilityRef<String>.Swap(ref str1, ref str2);

            Console.WriteLine($"{str1}, {str2}");

            string qwe1 = "000";
            string qwe2 = "12313213";
            Utility.Swap(ref qwe1, ref qwe2); // компилятор сам понимает по типам входящих параметров
            Console.WriteLine($"{qwe1}, {qwe2}");

            int asd1 = 123132;
            string asd2 = "0";
            // Utility.Swap(ref asd1, ref asd2);  // так не  хочет*/
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            

            /*Metric[] temperatures = new Metric[] {
                new Metric{ Month = 1, Temperature = -10, Day = 1 },
                new Metric{ Month = 2, Temperature = -30, Day = 5 },
                new Metric{ Month = 3, Temperature = 0, Day = 15 },
                new Metric{ Month = 4, Temperature = 10, Day = 4 },
                new Metric{ Month = 7, Temperature = 20, Day = 6 },
                new Metric{ Month = 5, Temperature = 1, Day = 7 },
                new Metric{ Month = 8, Temperature = 5, Day = 12 },
                new Metric{ Month = 10, Temperature = -5, Day = 24 },
                new Metric{ Month = 9, Temperature = -18, Day = 2 }
            };

            Array.Sort(temperatures);
            foreach (var item in temperatures)
            {
                Console.WriteLine(item);
            }

            // нет не упаковки и распаковки, но код работает также(навернр оптимаотней и быстрей) 

            GeneralizedMetric[] temper = new GeneralizedMetric[] {
                new GeneralizedMetric{ Month = 1, Temperature = -10, Day = 1 },
                new GeneralizedMetric{ Month = 2, Temperature = -30, Day = 5 },
                new GeneralizedMetric{ Month = 3, Temperature = 0, Day = 15 },
                new GeneralizedMetric{ Month = 4, Temperature = 10, Day = 4 },
                new GeneralizedMetric{ Month = 7, Temperature = 20, Day = 6 },
                new GeneralizedMetric{ Month = 5, Temperature = 1, Day = 7 },
                new GeneralizedMetric{ Month = 8, Temperature = 5, Day = 12 },
                new GeneralizedMetric{ Month = 10, Temperature = -5, Day = 24 },
                new GeneralizedMetric{ Month = 9, Temperature = -18, Day = 2 }
            };

            Array.Sort(temperatures);
            foreach (var item in temperatures)
            {
                Console.WriteLine(item);
            }*/



            ICovariant<string> str1 = new SomeClass<string>();
            ICovariant<object> obj1 = str1;



        }

    }
}
