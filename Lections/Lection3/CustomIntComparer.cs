using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection3
{
    internal class CustomIntComparer : IComparer<int>
    {
        public int Compare(int x, int y)  // сначало четные, потом нечетные
        {
            if ((x % 2 == 0 && y % 2 == 0) || (x % 2 == 1 && y % 2 == 1))
            {
                return x.CompareTo(y);
            }
            else
            {
                if (x % 2 == 1)
                {
                    return 1;
                }
                else return -1;
            }
        }
    }
}
