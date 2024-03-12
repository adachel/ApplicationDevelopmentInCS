using ApplicationDevelopmentInCS.Seminars.Seminar_6.Exeption;
using ApplicationDevelopmentInCS.Seminars.Seminar_6.Logger;
using System;

namespace ApplicationDevelopmentInCS.Seminars.Seminar_6
{
    internal class MenuSem6
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


        public void RunMenu()
        {
            var calc = new CalcSem6();
            Logg logg = new Logg();
            calc.GotResult += Calc_GotResult;
            calc.GotNumber += Calc_GotNumber;

            while (true)
            {
                Console.WriteLine("1 - Ввод чисел");
                Console.WriteLine("2 - Отмена последнего действия");
                Console.WriteLine("3 - Просмотр StackTrace");
                Console.WriteLine("q - Отмена");

                string str = Console.ReadLine()!;
                if (str == "") { return; }
                else
                {
                    switch (str)
                    {
                        case "1":
                            Console.WriteLine("Первое число.");
                            calc.FirstNumber(CheckNumber());
                            break;
                        case "2":
                            calc.CancelLast();
                            break;
                        case "3":
                            Console.WriteLine(logg.GetLogg());
                            continue;
                        case "q":
                            return;
                        default:
                            Console.WriteLine("Сделайте корректный выбор!");
                            continue;
                    }

                    Console.WriteLine("Второе число");
                    double number = CheckNumber();

                    Console.WriteLine("Действие");

                    try
                    {
                        while (true)
                        {
                            var symbol = Console.ReadLine();
                            logg.AddLogg(calc.Result, symbol!, number);
                            switch (symbol)
                            {
                                case "+":
                                    calc.Sum(number);
                                    break;
                                case "-":
                                    calc.Subtract(number);
                                    break;
                                case "*":
                                    calc.Multiply(number);
                                    break;
                                case "/":
                                    calc.Divide(number);
                                    break;
                                default:
                                    Console.WriteLine("Выбрите: '+', '-', '*' или '/'!");
                                    continue;
                            }
                            break;
                        }
                    }
                    catch (CalculatorDivideByZeroException e)
                    {
                        Console.WriteLine(e.Message + logg.GetLogg());
                    }
                    catch (CalculateOperationCauseOverflowException e)
                    {
                        Console.WriteLine(e.Message + logg.GetLogg());
                    }
                }
            }

        }

        private void Calc_GotNumber(object? sender, ChangedEventArgsSem6 e)
        {
            Console.WriteLine("Первое число = " + e.Operand);
        }

        private void Calc_GotResult(object? sender, ChangedEventArgsSem6 e)
        {
            Console.WriteLine("Результат = " + e.Operand);
        }
    }
}
