using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Televison : Item
    {
        public string Manufacturer { get; set; }
        public string Size { get; set; }

        public override string PrintInfo()
        {
            return (String.Format("{0} - {1}", Manufacturer, Size));
        }
    }
}
