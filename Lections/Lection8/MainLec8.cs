using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection8
{
    internal class MainLec8
    {
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <returns></returns>
        // создадим метод
        static DirectoryInfo GetProjectRoot()
        {
            Stack<string> names = new Stack<string>(new string[] { "bin", "Debug", "net8.0" });
            var current = Directory.GetCurrentDirectory(); // сохр путь в переменную. вернул строку
            DirectoryInfo di = new DirectoryInfo(current);
            while (names.Count > 0)
            {
                var expected = names.Pop();
                if (di.Name == expected)
                {
                    di = di.Parent;
                }
                else
                {
                    return null;
                }
            }
            return di;
        }

        static void DrawDirectoryInfo(DirectoryInfo dir)
        {

            foreach (var item in dir.GetDirectories())
            {
                var dirName = $"[{item.Name}]".PadRight(50);
                Console.WriteLine(dirName + $"<{CalculateDirSize(item)}>");
            }
            foreach (var item in dir.GetFiles())
            {
                Console.WriteLine($"{item.Name.PadRight(50)} <{item.Length}>"); // PadRight(50) - для выравнивания. Всегда, когда считаете размер файла,
                                                                                // используйте тип long(считает в байтах, размер может быть больше чем может int)
            }
        }

        static bool ContainsExtention(DirectoryInfo dir, string[] extentions)  // поиск файлов по расширению
        {
            var set = new HashSet<string>(extentions);

            foreach (var item in dir.GetFiles())
            {
                // Console.WriteLine(item.Extension);
                set.Remove(item.Extension);
            }
            return set.Count == 0;
        }

        static long CalculateDirSize(DirectoryInfo dir) // считает размер дирректории
        {
            long size = 0;

            foreach (var item in dir.GetDirectories())
            {
                size += CalculateDirSize(item);
            }
            foreach (var item in dir.GetFiles())
            {
                size += item.Length;
            }
            return size;
        }


        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 

        static void ListDirectory(DirectoryInfo dir)
        {
            foreach (var item in dir.GetDirectories())
            {
                //Console.WriteLine(item.FullName);   // полный путь
                Console.WriteLine(item.Name);       // созданный каталог
            }
        }

        static void ListDirectorySTR(string dir)
        {
            /*foreach (var item in Directory.EnumerateDirectories(dir, "ob*"))    // "ob*" - маска поиска, можно без нее. ищем obj
            {
                //Console.WriteLine(item.FullName);   // полный путь
                Console.WriteLine(item);       // созданный каталог
            }*/

            foreach (var item in Directory.EnumerateFiles(dir, "*.cs"))    // можно с маской, можно без
            {
                //Console.WriteLine(item.FullName);   // полный путь
                Console.WriteLine(item);       // созданный каталог
            }
        }

        static void ListDirectoryFiles(string dir) // ищет и дирректории
        {
            foreach (var item in Directory.GetFileSystemEntries(dir))
            {
                Console.WriteLine(item);
            }
        }


        public void Run()
        {
            // Деструктор - специальный метод, выполняющийся перед уничтожением класса. Деструктор = финализатор.
            // Финализатор: особенности
            // ● Они не могут быть вызваны из кода приложения.
            // ● Доступ к ним и, следовательно, их выполнение доступно только сборщику мусора.
            // ● Финализаторы не могут иметь параметров в отличие от конструкторов.
            // ● Финализатор нельзя пометить модификатором доступа.
            // ● Вы не можете управлять моментом, когда будет вызван финализатор.
            // ● Net Core не вызывает финализаторы при завершении приложения.
            // поэтому финализатор плохо контролируется и не управляется. Есть более удоюный способ - IDisposable
            // 
            // IDisposable - преднвзнвчен для завершения работы с неуправляемыми ресурсами.
            // Всем тем, что находится в не зоны влияния сборщика мусора.
            // а также и произвольных классов.

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // DirectoryInfo
            // Все те же возможности по работе с каталогами и файлами, что и статический класс Directory.

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Path
            // Это статический класс, предназначенный для работы с путем. 

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            // File
            // Статический класс, позволяющий работать с файлами. По аналогии с Directory позволяет создавать,
            // удалять, перемещать, но только не каталоги, а файлы.Помимо создания класс предоставляет
            // возможность чтения и записи в файл. 

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            // FileInfo
            // Класс FileInfo, который мы с вами уже неоднократно применяли в коде,
            // имеет примерно все те же возможности по работе с файлами, что и статический класс File,
            // но в отличие от последнего экземпляр этого класса описывает конкретный файл,
            // к которому применяются все его методы и свойства.

            //////////////////////////////////////////////////////////////////////////////////////////////////
            // Stream / Поток
            // Поток ограждает разработчика от деталей внутреннего устройства операционной системы или же оборудования.
            // Спец структура данных, абстракция, оборачивающая последовательность байт в единый интерфейс,
            // позволяющий упростить работу с источником данных, путем унифицированного интерфейса чтения и записи.
            // Потоки включают в себя такие операции как:
            // ● Чтение - вы можете читать данные из потока, например помещая их в массив байт.
            // ● Запись - вы можете писать данные в поток.Например из массива.
            // ● Установка позиции - с потоком можно работать с определенной позиции,
            // для этого ее нужно установить.Не все типы потоков умеют это делать.
            // потоки реализуют IDisposable и поддерживают асинхронную работу.
            // потоки поддерживают буферизацию.
            // базовый класс для всех потоков Stream, он абстрактный
            // для потоков придумали классы обертки, позволяющие обращаться к данным в разных форматах.

            // FileStream
            // FileStream — это поток для работы с файловым вводом-выводом.
            // Поддерживает как синхронные, так и асинхронные операции. 
            // 1. FileMode - параметр потока. Режим открытия файла.
            //  ○ Append - открывает файл, если таковой существует, и устанавливает позицию указателя в конец файла.Файл,
            //      открытый в этом режиме, нельзя читать, а также устанавливать указатель в произвольную позицию.
            //      Если файла не существует, он создается.

            //  ○ Create - указывает на то. что операционная система должна создать новый файл.
            //      Если файл уже существует, он будет перезаписан.

            //  ○ CreateNew - аналогичен Create, но в случае, если файл уже существует,
            //      будет выброшено исключение IOException.

            //  ○ Open - открывает уже существующий файл.Если файл не существует,
            //      выбросится исключение FileNotFoundException.FileAccess.Write, FileAccess.Read или же FileAccess.
            //      ReadWrite задает режим чтения.

            //  ○ OpenOrCreate - открывает файл.Если файл не существует, создается новый.FileAccess.Write,
            //      FileAccess.Read или же FileAccess.ReadWrite задает режим чтения.

            //  ○ Truncate - открывает существующий файл и “усекает” его до 0 байт.
            // 2. FileAccess (Flags) - - параметр потока. Режим чтения и записи.
            //  ○ Read - чтение
            //  ○ ReadWrite - чтение и запись
            //  ○ Write - запись


            /////////////////////////////////////////////////////////////////////////////////////
            /// MemoryStream
            // Поток MemoryStream позволяет обернуть в поток массив байт, находящийся в памяти приложения.

            /////////////////////////////////////////////////////////////////////////////////////
            /// BufferedStream
            // Буфер помогает сократить количество операций ввода-вывода на уровне операционной системы.

            ////////////////////////////////////////////////////////////////////////////////////////
            /// StreamReader и StreamWriter
            // Тогда как потоки предназначены для чтения и записи байт, StreamReader предоставляет
            // удобную обертку для чтения текстовых данных построчно или посимвольно. О
            // бъект StreamReader создается на основе потока. 

            // StreamWriter - Класс-обертка, предоставляющий функционал для записи текстовых данных в поток. 

            ///////////////////////////////////////////////////////////////////////////////////////
            /// StringReader, StringWriter
            // Классы предоставляют функционал, аналогичный StreamReader/ Writer, но в отличие от последних классы
            // оборачивают не потоки, а строки.

            ///////////////////////////////////////////////////////////////////////////////////////
            /// BinaryReader и BinaryWriter
            /// В пространстве имен System.IO существует два класса: BinaryReader и BinaryWriter, 
            /// позволяющие записать в поток некоторые типы данных, такие как int, long, bool.







            // пеpвый вариант
            /*ClassWithIDisposble obj = null; // создали объект
            try
            {
                obj = new ClassWithIDisposble();
            }
            finally
            {
                obj?.Dispose(); // ультимативно уничтожили объект
            }*/

            // второй вариант
            /*using (var obj = new ClassWithIDisposble())  // здесь using гарантирует автоматическое удаление.
                                                         // применим только к объектам, поддерживающим IDisposble
            { 
                obj.DoSomeWork();
            }*/
            ///////////////////////////////////////////////////////////////////
            /// напишем приложение, кот выводит инфо о каталоге в кот находится проект этого приложения, 
            /// при условии что программа запушена из одного из подкаталога проекта.
            /// 
            // Console.WriteLine(Directory.GetCurrentDirectory());

            // идем вверх
            /*var res = GetProjectRoot();
            if (res == null)
            {
                Console.WriteLine("Не удалось найти каталог проекта");
                return;  // если не нашли, то выходим из приложения
            }
*/

            /*foreach (var item in res.EnumerateFiles())  // возвращает тип IEnumirable
            {
                Console.WriteLine(item);  // получили список файлов в корневом каталоге
            }
            // c IEnumirable проходимся по списку, кот еще не создан. в каждую итерацию получаем по одному элементу,
            // когда найдем нужный файл, можем остановить поиск*/



            /*if(ContainsExtention(res, new string[] {".csproj", ".cs"}))
            { 
                Console.WriteLine("Нашли!");
                DrawDirectoryInfo(res);
            }*/

            //////////////////////////////////////////////////////////////////////////////
            /// создадим каталог
            // string current = Directory.GetCurrentDirectory();
            // Directory.CreateDirectory(current + "/1111"); // CreateDirectory - создает подкаталог в указанном каталоге
            // Directory.CreateDirectory(current + "/1/2/3/4/5"); // создает сразу кучу вложенных директорий



            // Console.WriteLine(Path.DirectorySeparatorChar); // показывает символ разделителя каталогов

            // ListDirectory(new DirectoryInfo(current + "")); // показываем подкаталог 
            // ListDirectorySTR(current + "/1/2/3/4"); // показываем подкаталог 
            // ListDirectorySTR(current + "/../../../"); // показывает выше

            // Directory.Delete(current + "/1/2"); // удаляет только самый последний номер
            // Directory.Delete(current + "/1", true); // удаляет все этого каталога

            //Console.WriteLine(Directory.Exists("1"));  // есть или нет дирректория
            //Console.WriteLine(Directory.GetCreationTime("1")); // время создания
            //Console.WriteLine(Directory.GetDirectoryRoot(current)); // корень

            // ListDirectoryFiles(Directory.GetCurrentDirectory());

            /*Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Directory.GetParent(Directory.GetCurrentDirectory()));

            Directory.Move("1", "1111/1");  // перенес каталог 1 с подкаталогами в 1111. указывать 1111/1 обязательно*/

            /*var d = Directory.GetLastAccessTime("1111/1"); // время последнего доступа к каталогу
            Console.WriteLine(d);

            Directory.SetLastAccessTime("1111/1", d.AddDays(-10));
            d = Directory.GetLastAccessTime("1111/1"); // поменяли время последнего доступа к каталогу
            Console.WriteLine(d);*/

            //////////////////////////////////////////////////////////////////////////////////////
            /// DirectoryInfo
            /*var d = new DirectoryInfo("1111/1").LastAccessTime; // время последнего доступа к каталогу
            Console.WriteLine(d);

            Directory.SetLastAccessTime("1111/1", d.AddDays(-10));
            d = Directory.GetLastAccessTime("1111/1"); // поменяли время последнего доступа к каталогу
            Console.WriteLine(d);*/

            ///////////////////////////////////////////////////////////////////////////////////////
            /// Класс Path
            /// 
            /*var newName = Path.ChangeExtension("ls.dll", "bak"); // меняет расширение в имени файла
            Console.WriteLine(newName);*/
            // File.Copy("ls.dll", newName);

            // var pathOld = Directory.GetCurrentDirectory() + "qweqweqwe.txt";

            // var path = Path.Combine(Directory.GetCurrentDirectory() + "/" + "qweqweqwe.txt");

            // Console.WriteLine(pathOld);
            /*Console.WriteLine(path);
            Console.WriteLine(Path.Exists(path)); // проверяет наличие
            Console.WriteLine(Path.GetExtension(path)); // расширение файла
            Console.WriteLine(Path.GetFileName(path)); // имя файла
            Console.WriteLine(Path.GetFileNameWithoutExtension(path)); // имя файла без расширения
            Console.WriteLine(Path.GetFullPath("qweqweqwe.txt")); // полный путь

            string ppp = Path.GetRandomFileName();  // случайное имя файла
            if (Path.Exists(ppp))
                Console.WriteLine("попробуйте снова");  // получение имени с проверкой*/

            /*string rt = null;
            try
            {
                rt = Path.GetTempFileName(); // создает произвольный файл
                Console.WriteLine(rt);
            }
            finally
            {
                if (rt != null && Path.Exists(rt))  // обязательно потом удалить
                    File.Delete(rt);
            }

            Console.WriteLine(Path.GetTempPath()); // узнать где хранятся временные файлы*/

            //////////////////////////////////////////////////////////////////////////////////////
            /// File
            /// 


            /*File.AppendAllLines("demo.txt", new string[] { "1", "2", "3" });  // открывает или создает файл
                                                                              // и добавляет в него массив строк

            File.AppendAllText("demo.txt", "Text\nText");  // открывает или создает файл*/

            // File.Create("qwe.txt"); // создается файл и возвращается объект файлСтрим, позволяет писать в файл байты

            // File.CreateText("asd.txt"); // создается файл и возвращается объект файлСтрим, позволяет писать в файл текст

            // File.Delete("qwe.txt");  // удаляет файл

            //var fff = File.ReadAllText("demo.txt", Encoding.UTF8); // читаем текст
            // Console.WriteLine(fff);

            // File.ReadAllBytes(fff); // читает байты

            /*var rt = File.ReadLines("demo.txt");  // возвр объект IEnumerable, кот можно перебрать в цикле
            foreach (var item in rt)
            {
                Console.WriteLine(item);
            }

            var df = File.ReadAllLines("demo.txt"); // возвр массив - все строки файла*/

            ////////////////////////////////////////////////////////////////////////////////////
            /// FileInfo

            /////////////////////////////////////////////////////////////////////////////
            /// Stream / Поток
            /// 
            /*DirectoryInfo prjRoot = GetProjectRoot();
            Console.WriteLine(prjRoot);

            var filePath = Path.Combine(prjRoot.FullName, "Program.cs");
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"файл {filePath} не найден");
            }

            var pathNew = Path.ChangeExtension(filePath, ".bak"); // меняем на расширение bak

            using (var fStream = new FileStream(filePath, FileMode.Open)) // открываем поток
            {
                // Метод Seek()
                byte[] bytes = new byte[fStream.Length];
                fStream.Seek(5000, SeekOrigin.Begin); // читаем, пропустив первые 5000 байт с начала
                fStream.Read(bytes, 0, bytes.Length);
                Console.WriteLine(Encoding.Default.GetString(bytes));*/

            /*// нужно скопировать
            // есть два файла filePath и pathNew
            using (var fOut = new FileStream(pathNew, FileMode.Create, FileAccess.Write))
            { 
                // вариант 1
                *//*int b = 0;
                while ((b = fStream.ReadByte()) >= 0)
                {
                    fOut.WriteByte((byte)b);  // появился Program.bak c содержимым Program.cs
                }*//*

                // вариант 2
                fStream.CopyTo(fOut);
                fOut.Flush(); // сбрасывает буферы на диск
            }*/

            // fStream.CanRead = true; // поток можем читать
            // fStream.Seek(); // позиционируем, указываем с какого места читаем поток
            // fStream.CanTimeout  // указывает на то, что при работе с потоком может возникнуть таймаут
            // fStream.IsAsync // поток открыт в асинхронном режиме
            // fStream.Length // длина потока
            // fStream.Position // позволяет установить позицию в файле, с кот можно начать чтение и запись
            // fStream.SafeFileHandle // ссылается на дискриптор файла, откр в файловой системе

            // методы потоков
            // fStream.Close();  // закр поток. тк работа с using, то поток и так будет закрыт
            // fStream.Read(); // позволяет прочитать поток в заранее созданный массив байт
            /*byte[] bytes = new byte[fStream.Length]; // создали массив байт
            int cnt = fStream.Read(bytes, 0, bytes.Length); // массив, позиция начала, позиция конца. возвл int
            if (cnt == bytes.Length)
            {
                var str = Encoding.Default.GetString(bytes);  // конверт в стринг
                Console.WriteLine(str);
            }*/

            // fStream.ReadByte(); // читает из потока один байт, но в форме int
            //byte[] bytes = new byte[fStream.Length];
            //for (int i = 0; i < bytes.Length; i++)
            //{
            //    int x = fStream.ReadByte(); // когда из потока больше нельзя прочесть, возвр -1
            //    if (x <= 0)
            //    {
            //        Console.WriteLine("поток вернул -1");
            //        return;
            //    }
            //    bytes[i] = (byte)x;
            //}
            //var str = Encoding.Default.GetString(bytes);  // конверт в стринг
            //Console.WriteLine(str);


            //Console.WriteLine("Открыт поток, размер = " + fStream.Length);

            //}

            ////////////////////////////////////////////////////////////////////////////////////////////
            /// поток MemoryStream
            /*var bytes = new byte[10]; // создали массив байт
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)i; // заполнили массив
            }

            using (var ms = new MemoryStream(bytes))
            {
                // вариант 1
                *//*int b = 0;
                while ((b = ms.ReadByte()) >= 0)
                {
                    Console.Write((byte)b + " ");
                *//*

                // вариант 2
                using (var strm = new MemoryStream())
                {
                    int bb = 0;
                    while ((bb = ms.ReadByte()) >= 0)
                    {
                        strm.WriteByte((byte)bb);
                    }
                    var byt = strm.ToArray();

                    foreach (var item in byt)
                    {
                        Console.Write(item + " ");
                    }
                }
            }*/

            ////////////////////////////////////////////////////////////////////
            /// BufferedStream
            /// 

            ///////////////////////////////////////////////////////////////////
            // StreamReader
            /*var path = "D:\\Works\\IT\\RepositoryCS\\ApplicationDevelopmentInCS\\Program.cs";
            var path1 = "D:\\Works\\IT\\RepositoryCS\\ApplicationDevelopmentInCS\\Program.bak";
            using(var f = new FileStream(path, FileMode.Open)) 
            {
                using (var sr = new StreamReader(f)) // предназначен для чтения байтов из потока в виде символов из строк
                {
                    using (var sw = new StreamWriter(new FileStream(path1, FileMode.Create)))
                    {
                        while (sr.Peek() >= 0)
                        {
                            sw.WriteLine(sr.ReadLine());  // писать в файл будем то, что прочли
                        }
                    }
                        *//*while (sr.Peek() >= 0)
                        {
                            var s = sr.ReadLine(); //  читаем построчно
                        }*//*
                }
            
            }*/

            ///////////////////////////////////////////////////////////////////////////////////////////
            /// StringReader, StringWriter
            /// 
            /*string input = """
                Line 0,
                Line 1,
                Line 2,
                Line 3,
                Line 4
                """;
            using (var sout = new StringWriter())
            {
                using (var sin = new StringReader(input))
                {
                    while (sin.Peek() >= 0)
                    {
                        sout.WriteLine(sin.ReadLine());
                    }
                }
                Console.WriteLine(sout.ToString());
            }*/

            ///////////////////////////////////////////////////////////////////////////////////////
            /// BinaryReader и BinaryWriter


            string fname = "test.bin";

            using (var bw = new BinaryWriter(new FileStream(fname, FileMode.Append))) // записываем
            {
                long l = 100l;
                int i = -99;
                byte b = 1;
                bool flag = false;

                bw.Write(l);
                bw.Write(i);
                bw.Write(b);
                bw.Write(flag);
            }
            using (var br = new BinaryReader(new FileStream(fname, FileMode.Open))) // читаем
            {
                Console.WriteLine(br.ReadInt64());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadSByte());
                Console.WriteLine(br.ReadBoolean());
                // порядок чтения должен соответствовать порядку записи
            }
        }




    }
}
