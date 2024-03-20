namespace ApplicationDevelopmentInCS.Seminars.Seminar2
{
    // спроектируйте интерфейс для класса способного устанавливать и получать значения отдельных бит в заданном числе.
    // Т.е должен быть какой-то интерфейс, у которого должно быть два метода.


    internal class BitsSem2 : IBitsSem2
    {
        public byte Value { get; private set; } = 0;
        private readonly int size = 0;


        public BitsSem2(byte value)
        {
            Value = value;
            size = sizeof(byte) * 8;
        }

        public BitsSem2(long value)
        {
            Value = (byte)value;
            size = sizeof(byte) * 8;
        }





        public bool GetBits(int index)  // выводит значение по индексу
        {
            return this[index];
        }

        public void SetBits(int index, bool value)  // меняет значение по индексу
        {
            this[index] = value;
        }


        public static implicit operator byte(BitsSem2 bt) => bt.Value;  // явное преобразование
        public static explicit operator BitsSem2(byte bt) => new BitsSem2(bt);  // неявное преобразование

        public static implicit operator long(BitsSem2 lng) => lng.Value;  // явное преобразование
        public static explicit operator BitsSem2(long lng) => new BitsSem2(lng);  // неявное преобразование

        public static implicit operator int(BitsSem2 i) => i.Value;  // явное преобразование
        public static explicit operator BitsSem2(int i) => new BitsSem2(i);  // неявное преобразование






        // переопределение индексатора
        public bool this[int index]
        {
            get
            {
                if (index > size || index < 0)
                {
                    return false;
                }
                return (Value >> index & 1) == 1;
            }
            set
            {
                if (index > size || index < 0)
                {
                    return;
                }
                if (value == true)
                {
                    Value = (byte)(Value | 1 << index);
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
