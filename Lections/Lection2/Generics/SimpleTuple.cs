using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Generics
{
    internal class SimpleTuple<T1, T2>
    {
        // private Tuple<int, string>? tuple1;
        // private Tuple<int, string>? tuple2;

        public T1 Item1 { get; init; }
        public T2 Item2 { get; init;}

        public SimpleTuple(T1? t1, T2? t2)
        {
            this.Item1 = t1!;
            this.Item2 = t2!;
        }


        public override string? ToString()
        {
            return $"{{{Item1}}}, {{{Item2}}}";
        }
    }
}
