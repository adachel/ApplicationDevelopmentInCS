using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ApplicationDevelopmentInCS.Seminars.Seminar7
{
    internal class MainSem7
    {
        // Рефлексия позволяет:
        // Изучать произвольный объект.
        // Создавать произвольный объект.
        // Вызывать произвольные методы.

        // Рефлексия Не позволяет Создавать собственные типы
        // Тип данных, описываемый конструктором - ConstructorInfo

        // [Flags] атрибут применяется вместе с Enum.
        // Атрибуты могут помечать интерфейсы.
        // Рефлексия не позволяет помечать атрибуты класса.
        // Можно создавать собственный атрибут.

        public static void Task1()
        {
            // Task1. Дан класс (ниже), создать методы создающий этот класс вызывая один из его конструкторов
            // (по одному конструктору на метод). Задача не очень сложна и служит больше для разогрева перед следующей задачей.
            // Создали класс с полями и конструкторами TestClass.
            // Создать тип классов. Должны инициализировать класс при помощи рефлексии

            Type type = typeof(TestClass);

            var t1 = Activator.CreateInstance(type);  // вызвался пустой конструктор
            var t2 = Activator.CreateInstance(type, [10]);  // вызвался конструктор c int. Выдаст ошибку, т.к конструктор private, заменил на public
            var t3 = Activator.CreateInstance(type, [10, "Hello", 10.05m, new char[] { 'A', 'B', 'C' }]);  // вызвался полный конструктор. 10.05m - с 'm' т.к. децимал
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public static void Task2()
        {
            // Напишите 2 метода использующие рефлексию:
            // 1 - сохраняет информацию о классе в строку.
            // 2 - позволяет восстановить класс из строки с информацией о методе.
            // В качестве примере класса используйте класс TestClass.
            // Шаблоны методов для реализации:
            // static object StringToObject(string s) { };
            // static string ObjectToString(object o) { }.

            // Коментарий:
            // Строка должна содержать название класса, полей и значений.
            // Ограничьтесь диапазоном значений представленном в классе.
            // Если класс находится в той же сборке (наш вариант) то можно не указывать имя сборки в паремтрах активатора.
            // Activator.CreateInstance(null, “TestClass”) - сработает; Для простоты представьте что есть только свойства.
            // Не анализируйте поля класса. Пример того как мог быть выглядеть сохраненный в строку объект:
            // “TestClass, test2, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null:TestClass | I:1 | S:STR | D:2.0 |”.
            // Ключ - значения разделяются двоеточием а сами пары - вертикальной чертой.
        }
        static string ObjectToStringForTask2(object o)
        {
            StringBuilder sb = new StringBuilder();
            Type type = o.GetType(); // получили тип объекта
            sb.Append(type.Assembly + "\n"); // Название cборки
            sb.Append(type.FullName + "\n"); // Наименование

            // добавляем свойства класса
            var properties = type.GetProperties(); // создали переменную со свойствами
            foreach (var item in properties)  // перебираем свойства и записываем в sb
            {
                if (item.GetCustomAttribute<DontSaveForTask3Attribute>() != null) continue;
                sb.Append(item.Name + "="); // Название свойства
                var val = item.GetValue(o);   // Значение свойства

                if (item.PropertyType == typeof(char[])) // если свойство массив char
                {
                    sb.Append(new string(val as char[]) + "\n"); // записываем массив в sb, конвертирую сначала в строку
                }
                else sb.Append(val + "\n"); // просто добавляем значение
            }
            return sb.ToString();
        }


        static object StringToObjectForTask2(string s)
        {
            string[] arr = s.Split("\n"); // сплит строки по переносам

            var typeClass = Activator.CreateInstance(null!, arr[1])?.Unwrap(); // Создает экземпляр типа с заданным именем,
                                                                                  // используя для этого именованную сборку
                                                                                  // и конструктор без параметров.
                                                                                  // Значений нет у свойств и полей нет.

            // Первый параметр - assemblyName, тип String. Имя сборки, в которой выполняется поиск типа,
            // заданного параметром typeName. Если параметр assemblyName имеет значение null(здесь),
            // поиск осуществляется в выполняющейся сборке.

            // Второй параметр - typeName, тип String. Полное имя типа, экземпляр которого нужно создать.

            // Возвращаемое значение тип ObjectHandle. Поставили Unwrap(), для того, чтобы переменная typeAssembly была Object


            if (typeClass != null && arr.Length > 2) // проверяем, если переменная не пустая и длина больше 2,
                                                        // т.е кроме названия есть поля, свойства и др.
            {
                Type type = typeClass.GetType(); // создал переменную type, записав в нее все из typeAssembly
                for (int i = 2; i < arr.Length; i++) // пробегаю циклом по остальной части arr, [0] и [1] уже задействовали.
                                                     // Дальше идут свойства. 
                {
                    string[] tempArr = arr[i].Split("="); // сплит каждого элемента по '='
                    var prop = type.GetProperty(tempArr[0]);
                    if (prop == null) continue;

                    if (prop.PropertyType == typeof(int))       // наполняю значениями поля
                        prop.SetValue(typeClass, int.Parse(tempArr[1]));

                    if (prop.PropertyType == typeof(string))
                        prop.SetValue(typeClass, tempArr[1]);

                    if (prop.PropertyType == typeof(decimal))
                        prop.SetValue(typeClass, decimal.Parse(tempArr[1]));

                    if (prop.PropertyType == typeof(char[]))
                        prop.SetValue(typeClass, tempArr[1].ToCharArray());
                }
            }
            return typeClass!; // вернули класс со значениями
        }

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public static void Task3()
        {
            // Реализуйте атрибут работающий совместно с предыдущим методом сохранения в строку.
            // Помеченное этим атрибутом свойство не должно подлежать сохранению(пропускается).
            // Для проверки пометить атрибутом любой свойство класса и убедитесь что оно не сохраняется.
        }
        static string ObjectToStringForTask3(object o)
        {
            StringBuilder sb = new StringBuilder();
            Type type = o.GetType(); // получили тип объекта
            sb.Append(type.Assembly + "\n"); // Название cборки
            sb.Append(type.FullName + "\n"); // Наименование

            // добавляем свойства класса
            var properties = type.GetProperties(); // создали переменную со свойствами
            foreach (var item in properties)  // перебираем свойства и записываем в sb имя и значение свойства через =
            {
                if (item.GetCustomAttribute<DontSaveForTask3Attribute>() != null) continue;  // для task3.
                                                                                            // Eсли есть помеченый атрибут, его не трогаем
                sb.Append(item.Name + "="); // Название свойства
                var val = item.GetValue(o);   // Значение свойства

                if (item.PropertyType == typeof(char[])) // если свойство массив char
                {
                    sb.Append(new string(val as char[]) + "\n"); // записываем массив в sb, конвертирую сначала в строку
                }
                else sb.Append(val + "\n"); // просто добавляем значение
            }
            return sb.ToString();
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>



        public void Run()
        {
            // Task1();

            
            // TestClass testClass = new TestClass();
            Type typeTask2 = typeof(TestClass);
            var t3 = Activator.CreateInstance(typeTask2, [10, "Hello", 10.05m, new char[] { 'A', 'B', 'C' }]);
            // Console.WriteLine(t3);

            string task2 = ObjectToStringForTask2(t3!);
            Console.WriteLine(task2);

            var task21 = StringToObjectForTask2(task2);
            // Console.WriteLine(task21);
        }
    }
}
