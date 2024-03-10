using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork5
{
    internal class Menu
    {
        public double CheckNumber()
        {
            while (true) 
            {
                var num = Console.ReadLine();
                if (double.TryParse(num, out double result))  
                    return result;
                
                Console.WriteLine("Введите число!");
            }
        }

        public char CheckSymbol() 
        {
            while (true)
            {
                var ch = Console.ReadLine();
                if (char.TryParse(ch, out char result))
                    return result;

                Console.WriteLine("Введите знак!");
            }
        }

        public void CalcRun(Calc calc) 
        {
            Console.WriteLine("Второе число");
            double number = CheckNumber();

            while (true) { 
            Console.WriteLine("Действие");
                switch (CheckSymbol())
                {
                    case '+':
                        calc.Sum(number);
                        return;
                    case '-':
                        calc.Subtract(number);
                        return;
                    case '*':
                        calc.Multiply(number);
                        return;
                    case '/':
                        calc.Divide(number);
                        return;
                    default:
                        Console.WriteLine("Выбрите: '+', '-', '*' или '/'!");
                        continue;
                }
            }
        }

        public void RunMenu()
        {
            var calc = new Calc();
            calc.GotResult += Calc_GotResult;
            calc.GotNumber += Calc_GotNumber;

            while (true)
            {
                Console.WriteLine("1 - Ввод чисел");
                Console.WriteLine("2 - Отмена последнего действия");
                Console.WriteLine("q - Отмена");

                string str = Console.ReadLine()!;
                if (str == "")
                {
                    return;
                }
                else
                {
                    char ch = char.Parse(str);
                    switch (ch)
                    {
                        case '1': break;
                        case '2':
                            calc.CancelLast();
                            CalcRun(calc);
                            continue;
                        case 'q':
                            return;                           
                        default:
                            Console.WriteLine("Сделайте корректный выбор!");
                            continue;
                    }
                }

                Console.WriteLine("Первое число");
                calc.FirstNumber(CheckNumber());

                CalcRun(calc);
            }

        }

        private void Calc_GotNumber(object? sender, ChangedEventArgs e)
        {
            Console.WriteLine("Первое число = " + e.Operand);
        }

        private void Calc_GotResult(object? sender, ChangedEventArgs e)
        {
            Console.WriteLine("Результат = " + e.Operand);
        }
    }
}
