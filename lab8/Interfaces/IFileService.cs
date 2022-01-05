using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8.Interfaces
{
    interface IFileService
    {
        public IEnumerable<Employee> ReadFile(string fileName);
        public void SaveData(IEnumerable<Employee> data, string fileName);
    }
}
