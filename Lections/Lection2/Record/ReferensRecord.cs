using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Record
{
    record class ReferensRecord(int a)
    {
        public int b { get; set; }
        public int c { get; init; }
    }
}
