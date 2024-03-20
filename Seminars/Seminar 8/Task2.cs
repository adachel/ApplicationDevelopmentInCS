using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_8
{
    internal class Task2
    {
        // Напишите утилиту рекурсивного поиска файлов в заданном каталоге и подкаталогах
        // Пример запуска: utility.exe c:\t file1.txt


        static List<string> strings = new List<string>();
        public void SearchFile(string path, string fileName)
        { 
            // var files = Directory.GetFiles(path); // получили все файлы директории.
                                                  // Массив полных имен (включая пути) файлов
                                                  // в указанном каталоге или пустой массив, если файлы не найдены.

            // strings.AddRange(Directory.GetFiles(path, fileName)); // сократили. Массив строк создается и передается конструктору,
                                                                  // заполняя список элементами массива.
                                                                  // Вызывается AddRange метод со списком в качестве аргумента.
                                                                  // В результате текущие элементы списка добавляются
                                                                  // в конец списка, дублируя все элементы.

            strings.AddRange(Directory.GetFiles(path, fileName, SearchOption.AllDirectories)); // ущу сократили,
                                                                                               // убрав foreach с рекурсией

            /*foreach (var item in files)
            {
                if (Path.GetFileName(item) == fileName) // Возвращает имя файла и расширение указанной строки пути.
                {
                    strings.Add(item);
                }
            }*/

            /*foreach (var dir in Directory.GetDirectories(path)) // Возвращает имена подкаталогов (включая пути) в указанном каталоге.
            {
                SearchFile(dir, fileName);
            }*/
        }

        public void ViewFile(string path, string fileName)
        {
            SearchFile(path, fileName);
            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }
        }
    }
}
