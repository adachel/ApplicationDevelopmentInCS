using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Record
{
    record struct ValueRecord(int a) // усли class, то referens, если struct, то value
    {
        public int b { get; set; }
        public int c { get; init; }
    }
}
