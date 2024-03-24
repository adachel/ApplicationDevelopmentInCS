using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ApplicationDevelopmentInCS.Seminars.Seminar9
{
    internal class Temp1
    {
        public void Run(string json)
        {
            using (var doc = JsonDocument.Parse(json))
            {
                // создание элемента XML
                XmlElement rootElement = CreateXmlElement(doc.RootElement);

                // создание документа XML и добавление корневого элемента
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.AppendChild(xmlDocument.ImportNode(rootElement, true));

                // сохранение в файл
                xmlDocument.Save("output123.xml");
            }
        }

        private XmlElement CreateXmlElement(JsonElement jsonElement)
        {
            XmlDocument xmlDocument = new XmlDocument();

            // создание элем XML c именем, соответствующим имени элемента Json
            XmlElement element = xmlDocument.CreateElement(jsonElement.ValueKind.ToString());

            switch (jsonElement.ValueKind)
            {
                case JsonValueKind.Object:
                    // для объекта JSON рекурсивно создаем XML элементы для каждого свойства
                    foreach (JsonProperty property in jsonElement.EnumerateObject())
                    {
                        XmlElement propertyElement = CreateXmlElement(property.Value);
                        propertyElement.SetAttribute("Name", property.Name);
                        element.AppendChild(propertyElement);
                    }
                    break;
                case JsonValueKind.Array:
                    // для массива json рекурсивно создаем XML элементы для каждого элемента
                    foreach (JsonElement elemArr in jsonElement.EnumerateArray())
                    {
                        XmlElement arrItemElem = CreateXmlElement(elemArr);
                        element.AppendChild(arrItemElem);
                    }
                    break;
                case JsonValueKind.String:
                    element.InnerText = jsonElement.GetString();
                    break;
                case JsonValueKind.Number:
                case JsonValueKind.True:
                case JsonValueKind.False:
                    element.InnerText = jsonElement.GetRawText();
                    break;
                case JsonValueKind.Null:
                    element.SetAttribute("null", "true");
                    break;
            }
            return element;
        }
    }
}



