using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ParamsOfIntegration
    {
        public double From { get; set; }
        public double To { get; set; }
        public int n { get; set; }

        public ParamsOfIntegration(double From_, double To_, int n_)
        {
            From = From_;
            To = To_;
            n = n_;
        }
    }
}
