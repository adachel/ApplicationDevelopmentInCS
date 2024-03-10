using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection5
{
    // События
    public class MyEvenArgs : EventArgs // EventArgs - спец класс для событий
    {
        public string? Message { get; set; }
    }
}
