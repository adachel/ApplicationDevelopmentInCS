using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ApplicationDevelopmentInCS.Seminars.Seminar9
{
    internal class Task1
    {
        public void Deserial(string s)
        {

        }
        public void Run()
        {
            string obj = """
                <?xml version="1.0" encoding="utf-8"?>
                <Data.Root xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">

                <Data.Root.Names>
                <Name>Name1</Name>
                <Name>Name2</Name>
                <Name>Name3</Name>
                </Data.Root.Names>

                <Data.Entry LinkedEntry="Name1">
                <Data.Name>Name2</Data.Name>
                </Data.Entry>

                <Data_x0023_ExtendedEntry LinkedEntry="Name2">
                <Data.Name>Name1</Data.Name>
                <Data_x0023_Extended>NameOne</Data_x0023_Extended>
                </Data_x0023_ExtendedEntry>

                </Data.Root>
                """;

            var dl = new DataRoot
            {
                Names = new List<string>
                {
                    "Name1", "Name2", "Name3"
                },
                Entries = new List<DataEntry>
                {
                    new DataEntry { LinkedEntry = "Name1", DataName = "Name2" },
                    new DataExtendedEntry
                    {
                        LinkedEntry = "Name2", DataName = "Name1",ExtendedEntry = "NameOne"
                    }
                }
            };

            var serializer = new XmlSerializer(typeof(DataRoot)); // создали объект класса XmlSerializer
            serializer.Serialize(Console.Out, dl);

            using ( var stream = new StringReader(obj) )
            {
                DataRoot res = (DataRoot)serializer.Deserialize(stream)!;
            }

            

            // Console.WriteLine(dl);

        }
    }
}



