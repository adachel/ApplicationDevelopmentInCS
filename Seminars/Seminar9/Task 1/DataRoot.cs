using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApplicationDevelopmentInCS.Seminars.Seminar9
{
    //<Data.Root.Names>
    //<Name>Name1</Name>
    //<Name>Name2</Name>
    //<Name>Name3</Name>
    //</Data.Root.Names>


    [XmlRoot("Data.Root")]
    public record class DataRoot
    {
        [XmlArray("Data.Root.Names")]
        [XmlArrayItem("Name")]
        public List<string>? Names;
        //public DataEntry Entry { get; set; } // <Data.Entry LinkedEntry="Name1">
        //public DataExtendedEntry? ExtendedEntry { get; set; }
        [XmlElement(typeof(DataEntry))]
        [XmlElement(typeof(DataExtendedEntry))]
        public List<DataEntry>? Entries;

    }
}
