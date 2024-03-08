using ApplicationDevelopmentInCS.Seminars.Seminar_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar4
{
    internal class Sem5
    {
        public void Run()
        {
            //var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var result = nums.MyWhere(x => x % 2 == 0);

            //result.ToList().ForEach(x => Console.Write(x + " "));

            // спроектировать интерфейс калькулятора, поддерживающий простые арифметические действия, хранящий результат,
            // также вывод инфо при помощи события информацию. 

            ICalculator calc = new Calculator();
            calc.GotResult += Calc_GotResult; // подписываем 
            calc.Sum(12);
            calc.Subtraction(5);
            calc.Multiply(16);
            calc.Divide(121);
            calc.CancelLast();
            calc.CancelLast();
            calc.CancelLast();
            calc.CancelLast();
            calc.CancelLast();

            
            
        }

        private void Calc_GotResult(object? sender, OperandChangedEventArgs e) // 
        {
            Console.WriteLine(e.Operand);
        }
    }
}
