using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApplicationDevelopmentInCS.Lections.Lection9
{
    public class MyClass // для XmlSerializer важно, чтобы здесь класс был public
    {
        private int _field1 = 10;
        private int _field2 = 20;

        public int field3 = 30;
        public int field4 = 40;

        public MyClass() // !!! для сериал нужен пустой конструктор
        {
        }

        public MyClass(int x, int y) // не работает сериал с таким конструктором
        {
            this._field1 = x;
            this._field2 = y;
        }

        public override string? ToString()
        {
            return $"_field1: {_field1}, _field2: {_field2}, _field3: {field3}, _field4: {field4}";
        }
    }
}
