using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Fibonachi
{
    internal class Fibonacсi
    {
        public int Value { get; private set; } = 1; // первый элемент
        public int valuePrev = 0;  // предыдущий элемент

        public static Fibonacсi operator ++(Fibonacсi f)
        {
            var temp = f.Value;
            f.Value = f.Value + f.valuePrev;
            f.valuePrev = temp;
            return f;
        }

        // переопределим сложение
        public static Fibonacсi operator +(Fibonacсi f, int count) // будем складывать fibo с обычным числом. То число,
                                                                   // кот прибавляем а fibo будет увеличивать число fibo на то самое кол-во позиций
        {
            for (int i = 0; i < count; i++)
            {
                f++;
            }
            return f;
        }



        public override string? ToString()
        {
            return Value.ToString();
        }
    }
}
