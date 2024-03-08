using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar4
{
    internal static class MyExtension  // делаем расширение над IEnuvirable
    {
        /*public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> collections, Predicate<T> predicate)
        {
            foreach (var item in collections)
            {
                if (predicate(item))
                    yield return item;
            }
        }*/

        // если без yield
        public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> collections, Predicate<T> predicate)
        {
            List<T> list = new List<T>();  // здесь выделяется отдельно память
            foreach (var item in collections)
            {
                if (predicate(item))
                    list.Add(item);
            }
            return list;
        }


    }
}
