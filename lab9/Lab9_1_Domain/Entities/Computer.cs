using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_1_Domain.Entities
{
    [Serializable]
    public class Computer
    {
        public Monitor Monitor { get; set; }

        public Computer(Monitor Monitor)
        {
            this.Monitor = Monitor;
        }

        public Computer() { }

        public static Monitor AddMonitor(string Company, string Name, double ScreenSize, string ImageQuality)
        {
            return new(Company, Name, ScreenSize, ImageQuality);
        }

        public override string ToString()
        {
            return $"{Monitor}";
        }
    }
}

