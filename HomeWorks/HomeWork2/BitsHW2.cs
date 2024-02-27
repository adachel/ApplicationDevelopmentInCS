using ApplicationDevelopmentInCS.Seminars.Seminar2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork2
{
    internal class BitsHW2 : IBitsHW2
    {
        public byte Value { get; private set; } = 0;
        private readonly int size = 0;

        public BitsHW2(byte value)
        {
            Value = value;
            size = sizeof(byte) * 8;
        }

        public BitsHW2(long value)
        {
            Value = (byte)value;
            size = sizeof(byte) * 8;
        }


        public bool GetBits(int index)
        {
            return this[index];
        }

        public void SetBits(int index, bool value)
        {
            this[index] = value;
        }

        public static implicit operator byte(BitsHW2 bt) => bt.Value;           // неявное
        public static explicit operator BitsHW2(byte bt) => new BitsHW2(bt);    // явное

        public static implicit operator long(BitsHW2 lng) => lng.Value;
        public static explicit operator BitsHW2(long lng) => new BitsHW2(lng);

        public static implicit operator int(BitsHW2 i) => i.Value;
        public static explicit operator BitsHW2(int i) => new BitsHW2(i);

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
