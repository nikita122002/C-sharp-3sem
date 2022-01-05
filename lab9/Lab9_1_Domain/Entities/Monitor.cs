using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Lab9_1_Domain.Entities
{
    [Serializable]
    public class Monitor
    {
        public string Company { get; set; }
        public string Name { get; set; }
        public double ScreenSize { get; set; }
        public string ImageQuality { get; set; }

        public Monitor(string Name, string Company, double ScreenSize, string ImageQuality)
        {
            this.Name = Name;
            this.Company = Company;
            this.ScreenSize = ScreenSize;
            this.ImageQuality = ImageQuality;
        }

        public Monitor() { }

        public override string ToString()
        {
            return $"{Company} {Name} {ScreenSize} {ImageQuality}";
        }
    }
}
