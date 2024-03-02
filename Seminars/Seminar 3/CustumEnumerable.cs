using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_3
{
    internal class CustumEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new CustumEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CustumEnumerator();
        }
    }
}
