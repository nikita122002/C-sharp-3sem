using System;
using System.Reflection;
using System.Collections.Generic;


namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assembly lib = Assembly.LoadFrom("ClassLibrary1.dll");
                Type[] types = lib.GetTypes();
                var path = "employees.json";
                foreach (Type typ in types)
                {
                    Console.WriteLine(typ.Name);  //метод SaveData т.к. он асинхронный 
                }
                var collection = EmployeeCollection();
                Type t = lib.GetType("ClassLibrary1.FileService`1", true, true).MakeGenericType(typeof(Employee));
                dynamic obj = Activator.CreateInstance(t);
                MethodInfo save = t.GetMethod("SaveData");
                MethodInfo read = t.GetMethod("ReadFile");

                save.Invoke(obj, new object[] { collection, path });

                Console.WriteLine("считанные объекты: \n");
                foreach (var a in read.Invoke(obj, new object[] { path }))
                {
                    Console.WriteLine(a);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static IEnumerable<Employee> EmployeeCollection() => new[]
        {
            new Employee("Angel", true, 5000),
            new Employee("Max", false, 1000),
            new Employee("Vlad", true, 2000),
            new Employee("Violett", false, 100),
            new Employee("Alex", false, 10),
            new Employee("July", true, 800)
        };
    }
}
