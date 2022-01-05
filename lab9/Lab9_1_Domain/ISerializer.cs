using System;
using System.Collections.Generic;
using Lab9_1_Domain.Entities;

namespace Lab9_1_Domain
{
    public interface ISerializer
    {
        IEnumerable<Computer> DeSerializeByLINQ(string fileName);
        void SerializeByLINQ(IEnumerable<Computer> xxx, string fileName);

        IEnumerable<Computer> DeSerializeJSON(string fileName);
        void SerializeJSON(IEnumerable<Computer> xxx, string fileName);

        IEnumerable<Computer> DeSerializeXML(string fileName);
        void SerializeXML(IEnumerable<Computer> xxx, string fileName);
    }
}