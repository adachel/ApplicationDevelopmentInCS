using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar9.Task_3
{
    public class JsonParser
    {
        private string? _value;
        private List<string> _results = new List<string>();


        private void ParseObj(JsonElement element)
        {
            foreach (var elem in element.EnumerateObject())
            {
                Console.WriteLine($"Property = {elem.Name}");
                bool save = elem.Name == _value;
                ParseElement(elem.Value, save);
            }
        }

        private void ParseArray(JsonElement element)
        {
            foreach (var elem in element.EnumerateArray())
            {
                ParseElement(elem);
            }
        }

        private void ParseString(JsonElement element, bool save)
        {
            if (save) 
            {
                _results.Add(element.GetString());
            }
            Console.WriteLine("String = " + element.GetString());
        }

        private void ParseNumber(JsonElement element, bool save)
        {
            if (save)
            {
                _results.Add(element.GetRawText());
            }
            Console.WriteLine("Number = " + element.GetRawText());
        }

        private void ParseBoolean(JsonElement element)
        {
            Console.WriteLine("Boolean value: " + element.GetBoolean());
        }

        private void ParseNull()
        {
            Console.WriteLine("Null value");
        }

        private void ParseElement(JsonElement element, bool save = false)
        {
            switch (element.ValueKind)
            {
                //case JsonValueKind.Undefined:
                //    break;
                case JsonValueKind.Object:
                    ParseObj(element);
                    break;
                case JsonValueKind.Array:
                    ParseArray(element);
                    break;
                case JsonValueKind.String:
                    ParseString(element, save);
                    break;
                case JsonValueKind.Number:
                    ParseNumber(element, save); 
                    break;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    ParseBoolean(element);
                    break;
                case JsonValueKind.Null:
                    ParseNull();
                    break;
                default:
                    throw new NotSupportedException("Unsupported JSON value kind: " + element.ValueKind);
                    break;
            }
        }

        public List<string> ParsJson(string json, string value)
        {
            _value = value;

            var jsonDoc =  JsonDocument.Parse(json);
            var root = jsonDoc.RootElement;
            ParseElement(root);
            return _results;
        }

    }
}
