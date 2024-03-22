using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDevelopmentInCS.Lections.Lection9
{
    public class Settings
    {
        public string setting1 = "";
        public string setting2 = "";
        public string setting3 = "";

        public override string? ToString()
        {
            return $"setting1: {setting1}, setting2: {setting2}, setting3: {setting3}";
        }
    }
}
