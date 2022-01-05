using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    class ClientsOfBank
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public override string ToString()
        {
            return ID.ToString() + " " + Name + " " + Year + " ";
        }
        
        public static bool IfTrue(ClientsOfBank client) => client.Year ==2020;
    }
}
