using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork9
{
    public class ConvertJsonToXML
    {
        private JsonDocument? jsonDocument;
        private XmlDocument xmlDocument = new XmlDocument();

        public void Run(string json, string path)
        {
            using (jsonDocument = JsonDocument.Parse(json))
            {
                XmlElement root = xmlDocument.CreateElement("root");
                xmlDocument.AppendChild(root);

                JsonToXml(jsonDocument.RootElement, root);

                xmlDocument.Save(path);
            }
        }

        private void JsonToXml(JsonElement jsonElement, XmlElement xmlElement)
        {
            foreach (JsonProperty property in jsonElement.EnumerateObject())
            {
                if (property.Value.ValueKind == JsonValueKind.Object)
                {
                    XmlElement child = xmlElement.OwnerDocument.CreateElement(property.Name);
                    xmlElement.AppendChild(child);
                    JsonToXml(property.Value, child);
                }
                else if (property.Value.ValueKind == JsonValueKind.Array)
                {
                    foreach (JsonElement element in property.Value.EnumerateArray())
                    {
                        XmlElement child = xmlElement.OwnerDocument.CreateElement(property.Name);
                        xmlElement.AppendChild(child);
                        JsonToXml(element, child);
                    }
                }
                else
                {
                    XmlElement child = xmlElement.OwnerDocument.CreateElement(property.Name);
                    child.InnerText = property.Value.ToString();
                    xmlElement.AppendChild(child);
                }
            }
        }

    }
}
