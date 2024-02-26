using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Generics.LimitationGeneric
{
    class GenericClassNew<T> where T : new()  // для создания экземпляров, должен иметь конструктор 
    {
        public T getInstance() 
        {
            return new T();
        }
    }
}
