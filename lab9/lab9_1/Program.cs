using System;
using System.Collections.Generic;
using Serializer;
using Lab9_1_Domain;
using Serialize = Serializer.Serializer;
using Computer = Lab9_1_Domain.Entities.Computer;

namespace Lab9
{
    class Program
    {
        static void Main()
        {
            string filenamelinq = "Computerslinq.xml";
            string filenamejson = "Computersjson.json";
            string filenamexml = "Computersxml.xml";

            ISerializer serializer = new Serialize();
            IEnumerable<Computer> computers = GetComputers();

            serializer.SerializeByLINQ(computers, filenamelinq);
            Console.WriteLine("Serialize by LINQ");
            foreach (var i in serializer.DeSerializeByLINQ(filenamelinq))
                Console.WriteLine(i);

            serializer.SerializeJSON(computers, filenamejson);
            Console.WriteLine("Serialize JSON");
            foreach (var i in serializer.DeSerializeJSON(filenamejson))
                Console.WriteLine(i);

            serializer.SerializeXML(computers, filenamexml);
            Console.WriteLine("Serialize XML");
            foreach (var i in serializer.DeSerializeXML(filenamexml))
                Console.WriteLine(i);
        }

        private static IEnumerable<Computer> GetComputers() => new[]
        {
            new Computer(Computer.AddMonitor("27GL83A-B", "LG",  27, "2560x1440")),
            new Computer(Computer.AddMonitor("27UL500-W", "LG", 27, "3840x2160")),
            new Computer(Computer.AddMonitor("C24RG50FQI", "Samsung", 23, "1920x1080")),
            new Computer(Computer.AddMonitor("Ultra gear", "LG", 23, "1920x1080"))
        };

    }
}
