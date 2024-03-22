using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Seminars.Seminar9.Task_2
{
    public class WeatherData
    {
        public WeatherInfo? Current {  get; set; }
        public List<WeatherInfo>? History {  get; set; }

    }
}
