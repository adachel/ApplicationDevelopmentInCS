using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_8
{
    internal class Task1
    {
        // Task 1. Напишите консольную утилиту для копирования файлов. Пример запуска: utility.exe file1.txt file2.txt.
        // Если нет указанного файла, то создаем и заполняем данными

        public void CreateFiles(string[] args)
        {
            if (args.Length < 2) 
            {
                Console.WriteLine("Нет параметров запуска");
            }
            else 
            {
                if (!File.Exists(args[0])) // если файла нет. Сравнивает с входящим аргументом
                {
                    using (var sw = new StreamWriter(args[0])) // StreamWriter - Класс-обертка, предоставляющий функционал
                                                               // для записи текстовых данных в поток. 
                    {
                        sw.WriteLine("Сгенерированная строка"); // запись строки "Сгенерированная строка" в файл args[0]
                    }
                }
                using (var sw = new StreamWriter(args[1]))
                { 
                    using(var sr = new StreamReader(args[0])) // StreamReader предоставляет удобную обертку
                                                              // для чтения текстовых данных построчно или посимвольно.
                    {
                        sw.Write(sr.ReadToEnd()); // записываю в args[1] то, что читаю в args[0]
                    }                    
                }
            }

        }
    }
}
