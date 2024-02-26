using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem2
{
    // спроектируйте интерфейс для класса способного устанавливать и получать значения отдельных бит в заданном числе.
    // Т.е должен быть какой-то тнтерфейс, у которого должно быть два метода. 

    internal interface IBitsSem2
    {
        public bool GetBits(int num);

        public void SetBits(int num, bool value);
    }
}
