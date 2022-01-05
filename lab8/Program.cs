using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab8.Entities;

namespace Lab8
{
    class Program
    {
        private static void Main()
        {
            var fileService = new FileService();

            var employees = GetDefaultEmployeesPack();

            string firstName = "Qwerty.txt";
            string secondName = "Ytrewq.txt";

            fileService.SaveData(employees, firstName);

            File.Move(firstName, secondName);

            var a = fileService.ReadFile(secondName).ToList();
            a.Sort(new EmployeeComparer());

            Console.WriteLine("Name: \t\tSalary: Highter education: ");
            foreach (var i in a)
            {
                Console.WriteLine(i.Name + "\t" + i.Salary + "\t" + i.HigherEducation);
            }

            File.Delete(firstName);
            File.Delete(secondName);

            Console.ReadKey();
        }

        private static IEnumerable<Employee> GetDefaultEmployeesPack() => new[]
        {
            new Employee("Tyson White", 300, true),
            new Employee("Vaughn Foster", 400, true),
            new Employee("Qadir Smith", 500, false),
            new Employee("Xan White", 450, true),
            new Employee("Quillen Lee", 700, true),
            new Employee("Paulo Jones", 200, false)
        };
    }
}