using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    public class Employee
    {
        public int Salary { get; set; }
        public bool HigherEducation { get; set; }
        public string Name { get; set; }
        public Employee() { }
        public Employee(string _name, bool _higherEducation, int _salary)
        {
            Salary = _salary;
            HigherEducation = _higherEducation;
            Name = _name;
        }

        public override string ToString()
        {
            string info = Name + " " + HigherEducation + " " + Salary.ToString() + "\n";
            return info;
        }
    }
}