using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ApplicationDevelopmentInCS.Lections.Lection9
{
    public class MainLec9
    {
        // Cериализация - перевод объектов в форму, пригодную для передачи или же сохранения.
        // Обратное преобразование называется десериализация.
        // Виды сериализации, поддержанные в .Net
        // ● Двоичная
        // ● XML
        // ● JSON

        // Двоичная сериализация (BinaryFormatter) - Позволяет сериализовать объекты в последовательность байт.
        // Данные можно отправить отправить по сети, сохранить на диск, в память.
        // С помощью двоичной сериализации можно обеспечить “совместный” доступ к объекту
        // из нескольких доменов приложений или приложений, работающих на разных компьютерах. 
        // 
        // Двоичная сериализация сохраняет полное состояние объекта, включая его скрытые поля,
        // что гарантирует “правильность” типа.При десериализации это может быть опасно,
        // поскольку в контексте приложения появляется десериализованный объект с внутренним состоянием,
        // созданным в другом приложении
        // Данный тип сериализации обладает рядом недостатков:
        // ● Не безопасен
        // ● Подвержен уязвимостям, связанным с десериализацией
        // ● Более не используется

        // XML сериализация
        // Является открытым стандартом. Данный стандарт широко использовался для передачи данных в интернете,
        // сохранения состояния приложения, хранения конфигураций приложения.
        // По умолчанию XML-сериализация охватывает только публичные поля объекта.
        //
        // Синтаксис XML
        // Поскольку символы “<”, “>”, “&”, “””, “‘” зарезервированы для поддержки синтаксиса языка, их следует указывать специальным образом:
        // “<“ - “&lt;”
        // “>“ - “&gt;”
        // “&” - “&amp;”
        // “‘ ” - “&apos;”
        // “”” - “&quot;”


        // JSON сериализация
        // Данный формат во многих областях приходит на смену XML. Он более компактный, нежели XML,
        // человекочитаемый и также открытый, что делает его самым популярным форматом для передачи данных
        // в интернет на сегодняшний день.
        // JSON поддерживает данные формата ключ-значение, а также массивы.

        // Cериализация похожа на парсинг, но позволяет преобразовать xml в сложный объект

        // ограничение сериал это наличие конструктрора по умолчанию




        public void Run()
        {
            //// сериализовал класс в xml
            //var serializer = new XmlSerializer(typeof(MyClass)); // передаем тип MyClass в XmlSerializer. только пубилчные поля
            //var serializer1 = new XmlSerializer(typeof(MyClass), "MyNameSpase"); //  можно указать NameSpase

            //var obj = new MyClass();
            //serializer.Serialize(Console.Out, obj);

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //// десериализация
            //var str = """ 
            //            <?xml version="1.0" encoding="Codepage - 866"?>
            //            <MyClass xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            //            <field3>90</field3>

            //            <field5>50</field5> 

            //            </MyClass> 
            //            """;  // добавили <field5>50</field5>. к ошибке не привело, но сериализатор его проигнорил.
            //var receivedObject = (MyClass?)serializer.Deserialize(new StringReader(str)); // метод Deserialize требует поток. вывел все поля,
            //                                                                              // даже приватные, хотя в файле они не показаны.
            //                                                                              // добавление тегов в файл к изменению объекта не привод,
            //                                                                              // новые теги игнорируются. в файле можно изменить значение полей.
            //                                                                              // если удалить поле из файла, десериал все равно его выведет
            //                                                                              // со значением по умолчанию.
            //                                                                              // при переименовании корневых тегов будет ошибка

            //Console.WriteLine(receivedObject);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //var obj = new Person()
            //{
            //    Name = "Василий",
            //    FirstName = "Иванов",
            //    Age = 23,
            //    //Details = new object[]
            //    //{
            //    //    new Address {Street = "Строителей", BuildingNo = 12 },
            //    //    new Phone {Home = "123098", Work = "098123" },
            //    //    new Occupatuion {Company = "Школа", Position = "Учитель"},
            //    //    "wetertert"  // даже если дописать, то она просто игнорится
            //    //}
            //};

            //var obj2 = new AnotherPerson() {Name = "Миша", FirstName = "Козлов", Age = 34};

            //var group = new Group() {People = new object[] { obj, obj2 } };



            //var serializer = new XmlSerializer(typeof(Group));
            //serializer.Serialize(Console.Out, group); // так выдаст ошибку, т.к есть массив объектов. сериал не знает, что с ним делать 

            //var str = """ 
            //            <?xml version="1.0" encoding="Codepage - 866"?>
            //            <Person xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            //              <Name>Василий</Name>
            //              <FamilyName>Иванов</FamilyName>
            //              <Age>23</Age>
            //            </Person>
            //            """;  
            //var receivedObject = (Person?)serializer.Deserialize(new StringReader(str)); 

            //Console.WriteLine(receivedObject);


            // нужно добавить типы
            // Type[] types = new Type[] { typeof(Address), typeof(Phone), typeof(Occupatuion) };
            //var serializer = new XmlSerializer(typeof(Person), types); // так работает. Такой подход не хорош, т.к массив может быть произвольным
            //serializer.Serialize(Console.Out, obj);

            //List<Type> lTypes = new List<Type>();

            //foreach (var item in obj.Details)
            //{
            //    lTypes.Add(item.GetType());
            //}

            //Type[] types = lTypes.ToArray();

            //var serializer = new XmlSerializer(typeof(Person), types); // так корректно
            //serializer.Serialize(Console.Out, obj);

            //Console.WriteLine();
            //Console.WriteLine();

            //var xmlRoot = new XmlRootAttribute();
            //xmlRoot.ElementName = "NewName";
            //xmlRoot.Namespace = "";

            //var serial = new XmlSerializer(typeof(Person), xmlRoot); // так можно заменить корневое имя. С Details одновременно не сработал
            // serial.Serialize(Console.Out, obj);

            ////////////////////////////////////////////////////////////////////
            /// методы XmlSerializer
            //var str = """ 
            //            <?xml version="1.0" encoding="Codepage - 866"?>
            //            <NewName xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            //              <Name>Василий</Name>
            //              <FirstName>Иванов</FirstName>
            //              <Age>23</Age>
            //            </NewName>
            //            """;

            // serial.CanDeserialize(); // принимает объект XmlReader, кот сконструирован из строки с xml,
            // возвращает bool, сможет ли сериал десериалить строку в объект

            // xmlReader читает xml теги
            // XmlReader xmlReader = XmlReader.Create(new StringReader(str));  // создаем xmlReader передав в него поток str
            // Console.WriteLine(serial.CanDeserialize(xmlReader)); 

            // создать объекты сериалов
            //var serializer = XmlSerializer.FromTypes(new Type[] { typeof(Person) })[0];
            //serializer.Serialize(Console.Out, obj);

            //////////////////////////////////////////////////////
            ///
            // var setting = new Settings() { setting1 = "on", setting2 = "off", setting3 = "1.25"}; // экз класса настроек

            // проверяем, есть ли сохр настройки
            //var settings = LoadSettings();

            //if (settings == null) // есть ли настройки
            //{
            //    Console.WriteLine("Новые настройки");
            //    settings = new Settings() { setting1 = "on", setting2 = "off", setting3 = "1.25" }; // создаем новые настройки
            //}
            //else 
            //{
            //    Console.WriteLine("Старые настройки");
            //}

            //Console.WriteLine(settings);

            //settings.setting1 = "off"; // меняем настройки
            //settings.setting2 = "on";
            //settings.setting3 = "0.001";

            //SaveSettings(settings); // сохраняем изменения

            /////////////////////////////
            // читаем xml
            //using (var reader = XmlReader.Create("MySettings.xml"))
            //{ 
            //    while (reader.Read()) // возвр bool, есть ли еще элем, на кот можно еще совершить переход
            //    {
            //        if (reader.IsStartElement()) // стартовый ли это элем
            //        {
            //            Console.Write("<");
            //            Console.Write(reader.Name);
            //            Console.WriteLine(">");
            //        }
            //        else 
            //        if (reader.NodeType == XmlNodeType.EndElement) // закрывающий элем
            //        {
            //            Console.Write("</");
            //            Console.Write(reader.Name);
            //            Console.WriteLine(">");
            //        }
            //        else Console.WriteLine(reader.Value); // значение между тегами
            //    }
            //}

            ///////////////////////////////////////////
            /// запишем xml
            /// 
            //int[] arr = new int[] {1, 2, 3, 4, 5};

            //var settings = new XmlWriterSettings // настройки при создании xml
            //{
            //    Indent = true,
            //    IndentChars = "     "
            //};

            //using (var writer = XmlWriter.Create("array.xml", settings))
            //{
            //    writer.WriteStartElement("arr");
            //    foreach (var item in arr) 
            //    {
            //        writer.WriteStartElement("elem");
            //        writer.WriteValue(item);
            //        writer.WriteEndElement();
            //    }
            //    writer.WriteEndElement();
            //}

            //////////////////////////////////////////////////////////////////////////////////////////////////
            /// json
            /// по умолчанию json сериалит свойства

            var pers = new Person()
            {
                Name = "Vasiliy",
                FirstName = "Ivanov",
                Age = 23,
                Details = new object[]
                {
                    new Address {Street = "Stroiteley", BuildingNo = 12 },
                    new Phone {Home = "123098", Work = "098123" },
                    new Occupatuion {Company = "Sckool", Position = "Teacher"},
                    // "wetertert"  // даже если дописать, то она просто игнорится
                }
            };

            //string json = JsonSerializer.Serialize(pers); // сериализатор
            //Console.WriteLine(json);

            //Console.WriteLine();
            //Console.WriteLine();

            //Person? newPers = JsonSerializer.Deserialize<Person>(json);
           // Console.WriteLine(newPers);

            ///////////////////
            // работа с потоками

            //using (var stream = new MemoryStream()) // сериал через поток
            //{
            //    JsonSerializer.Serialize(stream, pers, pers.GetType());
            //    var json = Encoding.UTF8.GetString(stream.ToArray());
            //    Console.WriteLine(json);
            //}

            Console.WriteLine();
            Console.WriteLine();

            var jn =  """ 
                        {"Name":"Vasiliy",
                        "FirstName":"Ivanov",
                        "Age":23,"Details":[{"Street":"Stroiteley","BuildingNo":12},
                                            {"Home":"123098","Work":"098123"},
                                            {"Company":"Sckool","Position":"Teacher"}]}
                        """;



            //using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(jn))) // десериал через поток
            //{
            //    var per = (Person?)(JsonSerializer.Deserialize(stream, typeof(Person)));
            //    Console.WriteLine(per);
            //}

            Console.WriteLine(JsonSerializer.Serialize<Person>(pers, new JsonSerializerOptions {IncludeFields = true })); // есть JsonSerializerOptions.
                                                                                                                          // сейчас видны и поля

            Console.WriteLine(JsonSerializer.Serialize<Person>(pers, new JsonSerializerOptions { IgnoreReadOnlyFields = true, IncludeFields = true })); // убирает поля с readonly




        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //static void SaveSettings(Settings settings) // сохраняет настройки
        //{
        //    var serializer = new XmlSerializer(settings.GetType());
        //    using (var stream = File.OpenWrite("MySettings.xml"))
        //    {
        //        serializer.Serialize(stream, settings);            
        //    }
        //}

        static void SaveSettings(Settings settings) // с использованием XmlWriter
        {
            var serializer = new XmlSerializer(settings.GetType());
            using (var writer = XmlWriter.Create("MySettings.xml"))
            {
                serializer.Serialize(writer, settings);
            }
        }


        //static Settings LoadSettings()  // загружает настройки
        //{
        //    string path = "MySettings.xml";
        //    var serializer = new XmlSerializer(typeof(Settings));
        //    if (Path.Exists(path))
        //    {
        //        using (var stream = File.OpenRead(path))
        //        {
        //            return (Settings)serializer.Deserialize(stream)!;
        //        }
        //    }
        //    return null!;
        //}

        static Settings LoadSettings()  // загружает настройки
        {
            string path = "MySettings.xml";
            var serializer = new XmlSerializer(typeof(Settings));
            if (Path.Exists(path))
            {
                using (var reader = XmlReader.Create(path))
                {
                    return (Settings)serializer.Deserialize(reader)!;
                }
            }
            return null!;
        }
        ////////////////////////////////////////////////////////////////////////////////







    }
}

