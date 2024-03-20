using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork8
{
    internal class HomeWork8
    {
        // Объедините две предыдущих работы (практические работы 2 и 3):
        // поиск файла и поиск текста в файле написав утилиту которая ищет файлы
        // определенного расширения с указанным текстом. Рекурсивно. Пример вызова утилиты:
        // utility.exe txt текст.

        static List<string> foundFiles = new List<string>();

        public void SearchFile(string path, string fileName)
        {
            var files = Directory.GetFiles(path);

            foundFiles.AddRange(Directory.GetFiles(path, fileName));

            foreach (var dir in Directory.GetDirectories(path))
            {
                SearchFile(dir, fileName);
            }
        }

        public bool FileWithWord(string file, string word)
        {
            using (var sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    var tempString = sr.ReadLine();
                    if (tempString!.Contains(word))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void ViewFile(string path, string extension, string word)
        {
            SearchFile(path, extension);
            foreach (var file in foundFiles)
            {
                if(FileWithWord(file, word))
                {
                    Console.WriteLine(file);
                }
            }
        }

        public void Run(string path, string extension, string word)
        {
            ViewFile(path, extension, word);
        }
    }
}
