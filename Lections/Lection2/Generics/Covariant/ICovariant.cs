using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Generics.Covariant
{
    internal interface ICovariant<out T>
    {
        T GetDufault();
    }
}
