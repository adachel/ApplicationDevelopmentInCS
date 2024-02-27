using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection2.Generics.GenericInterface
{
    struct GeneralizedMetric : IComparable<GeneralizedMetric>
    {
        public int Month;
        public int Temperature;
        public int Day;

        public GeneralizedMetric(int month, int temperature, int day)
        {
            Month = month;
            Temperature = temperature;
            Day = day;
        }

        public int CompareTo(GeneralizedMetric other)
        {
            int res = this.Month.CompareTo(other.Month); // сравниваем по месяцам
            if (res != 0)  // если месяц не равен 0
            {
                return res;  // то все нормально
            }
            else
            {
                return this.Temperature.CompareTo(other.Temperature); // иначе сравниваем по температуре
            }
        }
    }
}
