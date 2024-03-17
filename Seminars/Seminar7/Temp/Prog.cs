using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar7.Temp
{
    internal class Prog
    {
        static object StringToObject(string s)
        {
            string[] arrayInfo = s.Split("\n");

            var t4 = Activator.CreateInstance(null, arrayInfo[1])?.Unwrap();

            //TODO: Сделать так, чтобы и поле можно было обрабатывать
            if (t4 != null && arrayInfo.Length > 2)
            {
                Type type = t4.GetType();

                for (int i = 2; i < arrayInfo.Length; i++)
                {
                    string[] arrayInfo2 = arrayInfo[i].Split("=");
                    var prop = type.GetProperty(arrayInfo2[0]);

                    if (prop == null) continue;
                    if (prop.PropertyType == typeof(int))
                    {
                        prop.SetValue(t4, int.Parse(arrayInfo2[1]));
                    }
                    else if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(t4, arrayInfo2[1]);
                    }
                    else if (prop.PropertyType == typeof(char[]))
                    {
                        prop.SetValue(t4, arrayInfo2[1].ToCharArray());
                    }
                    else if (prop.PropertyType == typeof(decimal))
                    {
                        prop.SetValue(t4, decimal.Parse(arrayInfo2[1]));
                    }
                }
            }

            return t4;
        }

        static string ObjectToString(object o)
        {
            StringBuilder sb = new StringBuilder();

            Type type = o.GetType();

            sb.Append(type.Assembly + "\n");
            sb.Append(type.FullName + "\n");

            var properties = type.GetProperties();
            foreach (var prop in properties)
            {
                if (prop.GetCustomAttribute<DontSaveAttribute>() != null) continue;
                sb.Append(prop.Name + "=");
                var val = prop.GetValue(o);

                if (prop.PropertyType == typeof(char[]))
                {
                    sb.Append(new string(val as char[]) + "\n");
                }
                else
                {
                    sb.Append(val + "\n");
                }
            }

            /*var fields = type.GetFields();
            foreach (var field in fields)
            {
                var attribute = field.GetCustomAttribute<CustomNameAttribute>();
                if (attribute != null)
                {
                    sb.Append(attribute.CustomName + "=");
                    var fieldVal = field.GetValue(o);
                    sb.Append(fieldVal + "\n");
                }
            }*/


            return sb.ToString();
        }

        public void MainTemp()
        {
            Task2();
        }

        public static void Task()
        {
            Type type = typeof(TestClass);
            var t1 = Activator.CreateInstance(type);

            var t2 = Activator.CreateInstance(type, [10]);

            var t3 = Activator.CreateInstance(type, [10, new[] { 'A', 'B', 'C' }, "Hello", 10.01m]);
        }

        public static void Task2()
        {
            

            Type type = typeof(TestClass);

            var t3 = Activator.CreateInstance(type, [10, new[] { 'A', 'B', 'C' }, "Hello", 10.01m]);
            // Console.WriteLine(t3);

            string objectToString = ObjectToString(t3);
            // Console.WriteLine(objectToString);

            var obj = StringToObject(objectToString);
            // Console.WriteLine(obj);

            //string objectToString2 = ObjectToString(obj);
            //var obj2 = StringToObject(objectToString2);
        }
    }
}
