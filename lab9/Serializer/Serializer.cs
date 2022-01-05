using System;
using Lab9_1_Domain;
using Lab9_1_Domain.Entities;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System.Linq;


namespace Serializer
{
    public class Serializer : ISerializer
    {

        void ISerializer.SerializeByLINQ(IEnumerable<Computer> Computers, string fileName)
        {
            XDocument xdoc = new();
            XElement xcomputers = new("computers");
            foreach (var i in Computers)
            {
                XElement xcomputer = new("computer",
                    new XElement("monitor",
                        new XAttribute("name", i.Monitor.Name),
                        new XElement("company", i.Monitor.Company),
                        new XElement("screensize", i.Monitor.ScreenSize),
                        new XElement("imagequality", i.Monitor.ImageQuality))
                    );
                xcomputers.Add(xcomputer);
            }
            xdoc.Add(xcomputers);
            xdoc.Save(fileName);

        }

        IEnumerable<Computer> ISerializer.DeSerializeByLINQ(string fileName)
        {
            XDocument xdoc = XDocument.Load(fileName);

            foreach (XElement monitor in xdoc.Element("computers").Elements("computer").Elements("monitor"))
            {
                XAttribute name = monitor.Attribute("name");
                XElement company = monitor.Element("company");
                XElement screensize = monitor.Element("screensize");
                XElement imagequality = monitor.Element("imagequality");
                yield return new Computer(new Monitor(name.Value, company.Value, Convert.ToDouble(screensize.Value), imagequality.Value));
            }
        }

        async void ISerializer.SerializeJSON(IEnumerable<Computer> xxx, string fileName)
        {
            List<Computer> computers = xxx.ToList();
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            using (FileStream fs = new(fileName, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, computers, options);
            }
        }

        IEnumerable<Computer> ISerializer.DeSerializeJSON(string fileName)
        {
            var computers = JsonSerializer.Deserialize<Computer[]>(File.ReadAllText(fileName));
            return computers;
        }

        void ISerializer.SerializeXML(IEnumerable<Computer> xxx, string fileName)
        {
            List<Computer> computers = xxx.ToList();
            XmlSerializer formatter = new(typeof(List<Computer>));
            using (FileStream fs = new(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, computers);
            }
        }

        IEnumerable<Computer> ISerializer.DeSerializeXML(string fileName)
        {
            XmlSerializer formatter = new(typeof(List<Computer>));
            using (FileStream fs = new(fileName, FileMode.OpenOrCreate))
            {
                IEnumerable<Computer> computers = (IEnumerable<Computer>)formatter.Deserialize(fs);
                return computers;
            }
        }

    }
}
