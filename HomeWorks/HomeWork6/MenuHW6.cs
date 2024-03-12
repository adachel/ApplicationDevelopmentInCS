using ApplicationDevelopmentInCS.HomeWorks.HomeWork6.Exeption;
using ApplicationDevelopmentInCS.HomeWorks.HomeWork6.Logg;
using System;

namespace ApplicationDevelopmentInCS.HomeWorks.HomeWork6
{
    internal class MenuHW6
    {
        public void RunMenu()
        {
            var calc = new CalcHW6();
            LoggHW6 logg = new LoggHW6();
            calc.GotResult += Calc_GotResult;
            calc.GotNumber += Calc_GotNumber;

            while (true)
            {
                Console.WriteLine("1 - Ввод числа");
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
                            Console.WriteLine("Введите число");
                            break;
                        case "2":
                            calc.CancelLast();
                            continue;
                        case "3":
                            Console.WriteLine(logg.GetLogg());
                            continue;
                        case "q":
                            return;
                        default:
                            Console.WriteLine("Сделайте корректный выбор!");
                            continue;
                    }

                    double number = 0;

                    while (true)
                    {
                        var temp = Console.ReadLine();
                        try
                        {
                            if (int.TryParse(temp, out int num) == true) { number = num; }
                            else number = double.Parse(temp!);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Введите число!");
                            continue;
                        }
                    }

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
                    catch (CalculatorDivideByZeroExceptionHW6 e)
                    {
                        Console.WriteLine(e.Message + logg.GetLogg());
                    }
                    catch (CalculateOperationCauseOverflowExceptionHW6 e)
                    {
                        Console.WriteLine(e.Message + logg.GetLogg());
                    }
                }
            }

        }

        private void Calc_GotNumber(object? sender, ChangedEventArgsHW6 e)
        {
            Console.WriteLine("Число = " + e.Operand);
        }

        private void Calc_GotResult(object? sender, ChangedEventArgsHW6 e)
        {
            Console.WriteLine("Результат = " + e.Operand);
        }
    }
}
