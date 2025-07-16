using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_CC
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>() 
            {
                
            };

            Console.WriteLine("Select option:");
            Console.WriteLine("a - Display all employees");
            Console.WriteLine("b - Employees not in Mumbai");
            Console.WriteLine("c - Employees with title 'AsstManager'");
            Console.WriteLine("d - Employees whose Last Name starts with 'S'");
            Console.Write("Enter your choice (a/b/c/d): ");
            string choice = Console.ReadLine();

            IEnumerable<Employee> result = null;

            switch (choice.ToLower()) 
            {
                
            }

            Console.WriteLine("\nResults:");
            foreach (var emp in result)
            {
                Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB:dd-MM-yyyy}, DOJ: {emp.DOJ:dd-MM-yyyy}, City: {emp.City}");
            }

        }


    }

    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string DOB { get; set; }
        public string DOJ { get; set; }
        public string City { get; set; }
    }
}
