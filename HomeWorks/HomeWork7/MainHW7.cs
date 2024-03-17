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

            var fieldsClass = type.GetFields();
            foreach (var item in fieldsClass)
            {
                var rename = item.GetCustomAttribute<CustomNameHW7Attribute>();
                if (rename != null)
                {
                    sb.Append(rename.CustomName + " : ");
                }
                else sb.Append(item.Name + " : ");

                sb.Append(item.GetValue(o) + "\n");
            }

            var propsClass = type.GetProperties();
            foreach (var item in propsClass)
            {
                if (item.GetCustomAttribute<DontSaveHW7Attribute>() != null) continue;

                sb.Append(item.Name + " = ");
                var val = item.GetValue(o);

                if (item.PropertyType == typeof(char[]))
                {
                    sb.Append(new string(val as char[]) + "\n");
                }
                else sb.Append(val + "\n");
            }
            return sb.ToString();
        }

        // Метод StringToObject должен также уметь работать с этим атрибутом для записи значение в свойство
        // по имени его атрибута.
        // Если использовать формат строки с данными использованной нами для предыдущего примера
        // то пара ключ значение для свойства I выглядела бы CustomFieldName:0
        static object StringToObjectHW7(string s)
        {
            string[] arr = s.Split("\n");

            var obj = Activator.CreateInstance(null!, arr[1])?.Unwrap();

            Type type = obj!.GetType();

            var fieldsClass = type.GetFields();
            var propsClass = type.GetProperties();

            var fieldCount = fieldsClass.Length;
            var propsCount = propsClass.Length;

            var count = 0;

            if (obj != null && arr.Length > 2)
            {
                for (int i = 2; i < arr.Length; i++)
                {

                    if (fieldCount > 0)
                    {
                        string[] fieldArr = arr[i].Split(':');
                        string fieldName = fieldArr[0].Trim();
                        string fieldValue = fieldArr[1].Trim();

                        var rename = fieldsClass[count].GetCustomAttribute<CustomNameHW7Attribute>();
                        if (rename != null && rename.CustomName == fieldName)
                        {
                            Type fieldType = fieldsClass[count].FieldType;
                            object parsedValue = Convert.ChangeType(fieldValue, fieldType);
                            fieldsClass[count].SetValue(obj, parsedValue);
                            fieldCount--;
                            count++;
                            continue;
                        }
                        else
                        {
                            var fi = type.GetField(fieldName);

                            if (fi!.Name == fieldName)
                            {
                                if (fi.FieldType == typeof(int))
                                {
                                    fi.SetValue(obj, int.Parse(fieldValue));
                                }
                                else if (fi.FieldType == typeof(string))
                                {
                                    fi.SetValue(obj, fieldValue);
                                }
                                else Console.WriteLine("Другой тип!");
                            }
                            fieldCount--;
                        }
                    }

                    else if (propsCount > 0)
                    {
                        string[] propArr = arr[i].Split('=');
                        if (propArr[0].Trim() == "")
                        {
                            propsCount--;
                            continue;
                        }
                        else
                        {
                            string propName = propArr[0].Trim();
                            string propValue = propArr[1].Trim();

                            var pr = type.GetProperty(propName);

                            if (pr.Name == propName)
                            {
                                if (pr.PropertyType == typeof(int))
                                {
                                    pr.SetValue(obj, int.Parse(propValue));
                                }
                                else if (pr.PropertyType == typeof(string))
                                {
                                    pr.SetValue(obj, propValue);
                                }
                                else if (pr.PropertyType == typeof(decimal))
                                {
                                    pr.SetValue(obj, decimal.Parse(propValue));
                                }
                                else if (pr.PropertyType == typeof(char[]))
                                {
                                    pr.SetValue(obj, propValue.ToCharArray());
                                }
                                propsCount--;
                            }
                        }
                    }
                }
            }
            return obj!;
        }

        public void Run()
        {
            Type typeHW7 = typeof(ClassHW7);
            var instanceHW7 = Activator.CreateInstance(typeHW7, ["Поле с произвольным именем", 181818, 2024, "год дракона", 16.03m, new[] { 'q', 'w', 'e' }]);
            // Console.WriteLine(instanceHW7);

            Console.WriteLine();

            var saveInstance = ObjectToStringHW7(instanceHW7!);
            Console.WriteLine(saveInstance);

            Console.WriteLine();

            var uploadInstance = StringToObjectHW7(saveInstance);
            Console.WriteLine(uploadInstance);

        }
    }
}
