using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_8
{
    // Напишите утилиту читающую тестовый файл и выводящую на экран строки содержащие искомое слово.
    // Пример запуска: utility.exe c:\file1.txt слово
    internal class Task3
    {
        public void GetWord(string file, string word)
        {
            using (var sr = new StreamReader(file))
            { 
                while (!sr.EndOfStream) // До тех пор пока поток не закончен. Получает значение,
                                        // указывающее, находится ли текущая позиция потока в конце потока.
                {
                    var tempString = sr.ReadLine();
                    if (tempString.Contains(word)) 
                    {
                        Console.WriteLine(tempString);
                    }
                }
            }
        }
    }
}
