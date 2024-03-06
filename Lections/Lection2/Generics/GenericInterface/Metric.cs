using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Generics.GenericInterface
{
    struct Metric : IComparable  // показывает, сколько дней в месяце держалась температура. Добавляем интерфейс
    {
        public int Month;
        public int Temperature;
        public int Day;

        public Metric(int month, int temperature, int day)
        {
            Month = month;
            Temperature = temperature;
            Day = day;
        }

        public int CompareTo(object? obj)
        {
            var metric = (Metric)obj!; // приводим к одному типу

            int res = this.Month.CompareTo(metric.Month); // сравниваем по месяцам
            if (res != 0)  // если месяц не равен 0
            {
                return res;  // то все нормально
            }
            else
            { 
                return this.Temperature.CompareTo(metric.Temperature); // иначе сравниваем по температуре
            }
        }

        public override string? ToString()
        {
            return $"{Month}, {Temperature}, {Day}" ;
        }
    }
}
