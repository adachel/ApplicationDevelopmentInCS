using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApplicationDevelopmentInCS.Seminars.Seminar9
{
    //<Data_x0023_ExtendedEntry LinkedEntry = "Name2" >
    //< Data.Name > Name1 </ Data.Name >
    //< Data_x0023_Extended > NameOne </ Data_x0023_Extended >
    //</ Data_x0023_ExtendedEntry >


    [XmlType("Data#ExtendedEntry")]
    public record class DataExtendedEntry : DataEntry
    {
        [XmlElement("Data#Extended")]
        public string? ExtendedEntry;
    }
}
