using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork7
{
    internal class MainHW7
    {
        // Разработайте атрибут позволяющий методу ObjectToString сохранять поля классов с использованием произвольного имени.

        static string ObjectToStringHW7(object o)
        {
            StringBuilder sb = new StringBuilder();
            Type type = o.GetType();
            sb.Append(type.Assembly + "\n");
            sb.Append(type.FullName + "\n");

            var fields = type.GetFields();
            foreach (var field in fields)
            {
                var rename = field.GetCustomAttribute<CustomNameHW7Attribute>();
                if (rename != null)
                {
                    sb.Append(rename.CustomName + "=");
                }
                else sb.Append(field.Name + "=");

                sb.Append(field.GetValue(o) + "\n");
            }

            var properties = type.GetProperties();
            foreach (var item in properties)
            {
                if (item.GetCustomAttribute<DontSaveHW7Attribute>() != null) continue;  // не сохраняет свойство

                sb.Append(item.Name + "=");
                var val = item.GetValue(o);

                if (item.PropertyType == typeof(char[]))
                {
                    sb.Append(new string(val as char[]) + "\n");
                }
                else sb.Append(val + "\n");
            }
            return sb.ToString();
        }

        static object StringToObjectHW7(string s)
        {
            string[] arr = s.Split("\n");

            var typeClass = Activator.CreateInstance(null!, arr[1])?.Unwrap();

            if (typeClass != null && arr.Length > 2)
            {
                Type type = typeClass.GetType();

                for (int i = 2; i < arr.Length; i++)
                {
                    string[] tempArr = arr[i].Split("=");

                    var fi = type.GetField(tempArr[0]);

                    var prop = type.GetProperty(tempArr[0]);

                    if (fi == null && prop == null)
                    {
                        continue;
                    }
                    else if (fi != null)
                    {
                        if (fi.FieldType == typeof(int))
                        {
                            fi.SetValue(typeClass, int.Parse(tempArr[1]));
                        }
                        else if (fi.FieldType == typeof(string))
                        {
                            fi.SetValue(typeClass, tempArr[1]);
                        }
                        else Console.WriteLine("Другой тип!");
                    }
                    else if (prop != null)
                    {
                        if (prop.PropertyType == typeof(int))
                        {
                            prop.SetValue(typeClass, int.Parse(tempArr[1]));
                        }
                        else if (prop.PropertyType == typeof(string))
                        {
                            prop.SetValue(typeClass, tempArr[1]);
                        }
                        else if (prop.PropertyType == typeof(decimal))
                        {
                            prop.SetValue(typeClass, decimal.Parse(tempArr[1]));
                        }
                        else if (prop.PropertyType == typeof(char[]))
                        {
                            prop.SetValue(typeClass, tempArr[1].ToCharArray());
                        }
                    }

                }
            }
            return typeClass!;
        }







        public void Run()
        {
            Type typeHW7 = typeof(ClassHW7);
            var instanceHW7 = Activator.CreateInstance(typeHW7, ["Поле с произвольным именем", 2024, "год дракона", 16.03m, new[] { 'q', 'w', 'e' }]);
            // Console.WriteLine(instanceHW7);

            var saveInstance = ObjectToStringHW7(instanceHW7!);
            // Console.WriteLine(saveInstance);

            var uploadInstance = StringToObjectHW7(saveInstance);
            Console.WriteLine(uploadInstance);

        }
    }
}
