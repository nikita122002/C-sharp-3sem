using System;
using System.Collections.Generic;
using System.IO;
using Lab8.Interfaces;

namespace Lab8
{
    class FileService : IFileService
    {
        public IEnumerable<Employee> ReadFile(string fileName)
        {
            using (BinaryReader reader = new(File.Open(fileName, FileMode.Open)))
                while (reader.PeekChar() > -1)
                {
                    var (name, salary, higherEducation) =
                        (reader.ReadString(), reader.ReadInt32(), reader.ReadBoolean());
                    yield return new Employee(name, salary, higherEducation);
                }
        }

        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            using (BinaryWriter writer = new(File.Open(fileName, FileMode.Create)))
                foreach (var worker in data)
                {
                    writer.Write(worker.Name);
                    writer.Write(worker.Salary);
                    writer.Write(worker.HigherEducation);
                }
        }
    }
}