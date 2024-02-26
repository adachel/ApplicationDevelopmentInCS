﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Transformation
{
    internal class Bits // должен преобразовывать явно из байта и неявно в байт
    {
        public byte Value { get; private set; } = 0;

        public Bits(byte b)
        {
            Value = b;
        }


        public static explicit operator byte(Bits b) => b.Value;  // явное преобразование
        public static implicit operator Bits(byte b) => new Bits(b);  // неявное преобразование
    }
}