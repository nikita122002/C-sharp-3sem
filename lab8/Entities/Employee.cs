using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Employee
    {
        public string Name { get; set; }

        public int Salary { get; set; }
        public bool HigherEducation { get; set; }


        public Employee(string name, int salary, bool higherEducation = false)
        {
            Name = name;
            Salary = salary;
            HigherEducation = higherEducation;
        }

        public override string ToString() => $"{Name} {Salary} {HigherEducation}";
    }
}
