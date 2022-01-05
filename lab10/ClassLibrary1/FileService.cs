using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


namespace ClassLibrary1
{
    public class FileService<T>
    {
        public async void SaveData(IEnumerable<T> Employees, string fileName)
        {
            var view = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            using (FileStream fs = new(fileName, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, Employees, view);
            }
        }

        public IEnumerable<T> ReadFile(string filename)
        {
            var list = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(filename).ToString());
            return list;
        }
    }
}

