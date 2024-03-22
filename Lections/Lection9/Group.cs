using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApplicationDevelopmentInCS.Lections.Lection9
{
    [XmlRoot("xmlPeople")] // переобозвали группу
    public class Group
    {
        [XmlElement(typeof(Person))]            // при помощи этих атрибутов десериал знает типы 
        [XmlElement(typeof(AnotherPerson))]
        public object[]? People { get; set; }
    }
}
