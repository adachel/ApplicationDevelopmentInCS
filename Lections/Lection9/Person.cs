using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApplicationDevelopmentInCS.Lections.Lection9
{
    //[XmlType("xmlPerson")] // название типа
    //[XmlRoot("xmlPersonRoot")]
    public class Person
    {
        // [XmlAttribute]
        public string? Name { get; set; }

        // [XmlElement("FamilyName")]  // атрибут, можно задать альтернативное имя для тега, кот будет исп для сериал
        public string? FirstName { get; set; }
        public int Age { get; set; }
        public object[]? Details { get; set; }

        // чтобы получить все элементы, кот не смогли сопоставить с элементами(полями) класса




        public override string? ToString()
        {
            return $"Name: {Name}, FirstName: {FirstName}, Age: {Age}";
        }
    }
}
