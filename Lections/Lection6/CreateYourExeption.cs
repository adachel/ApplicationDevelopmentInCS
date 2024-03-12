using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection6
{
    internal class CreateYourExeption
    {
        class BitsExeption : Exception
        {
            public BitsExeption(int bit) : base($"Бит {bit} не может быть обработан т.к находится вне диапазона 0...7")
            {}
        }


        class Bits
        {
            public byte Value { get; set; } = 0;
            private void CheckIndex(int index)
            {
                if (index > 7 || index < 0)
                    throw new BitsExeption(index);
                    // throw new IndexOutOfRangeException($"Бит {index} не может быть обработан т.к находится вне диапазона 0...7");
            }
            public bool this[int index]
            { 
                get
                {
                    CheckIndex(index);
                    return ((Value >> index) & 1) == 1;
                }
                set
                {
                    CheckIndex(index);
                    if (value == true)
                        Value = (byte)(Value | (1 << index));
                    else
                    {
                        var mask = (byte)(1 << index);
                        mask = (byte)(0xff ^ mask);
                        Value &= (byte)(Value & mask);
                    }
                }
            }
            public Bits(byte value)
            {
                Value = value;
            }
        }

        public void Run()
        {
            // в качестве объекта, переданного в throw должен выступать класс, унаследованный от типа Exeption.
            // Throw прекращает выполнение кода в том месте, где он был использован и с того момента исключение
            // идет вверх по стеку вызовов в поисках своего обработчика. 
            










        }

    }
}
