using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2
{
    // спроектируйте интерфейс для класса способного устанавливать и получать значения отдельных бит в заданном числе.
    // Т.е должен быть какой-то интерфейс, у которого должно быть два метода.


    internal class BitsSem2 : IBitsSem2
    {
        public byte Value { get; private set; } = 0;
        private readonly int size = 0;  // добавили поле для универсальности


        public BitsSem2(byte value)
        {
            Value = value;
            size = sizeof(int); 
        }

        public bool GetBits(int index)  // выводит значение по индексу
        {
            return this[index];
        }

        public void SetBits(int index, bool value)  // меняет значение по индексу
        {
            this[index] = value;
        }


        // переопределение индексатора
        public bool this[int index]
        {
            get
            {
                if (index > size || index < 0)
                {
                    return false;
                }
                return ((Value >> index) & 1) == 1;
            }
            set 
            {
                if (index > size || index < 0)
                {
                    return;
                }
                if (value == true)
                {
                    Value = (byte)(Value | (1 << index));
                }
                else
                {
                    var mask = (byte)(1 << index);
                    mask = (byte)(0xff ^ mask);
                    Value &= (byte)(Value & mask);
                }

            }
        }


    }
}
