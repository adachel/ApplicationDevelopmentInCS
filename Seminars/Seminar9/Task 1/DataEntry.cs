using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApplicationDevelopmentInCS.Seminars.Seminar9
{
    //<Data.Entry LinkedEntry = "Name1" >
    //< Data.Name > Name2 </ Data.Name >
    //</ Data.Entry >


    [XmlType("Data.Entry")]
    public record class DataEntry
    {
        [XmlAttribute]
        public string? LinkedEntry;
        [XmlElement("Data.Name")]
        public string? DataName;
    }
}
