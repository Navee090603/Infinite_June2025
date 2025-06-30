using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    class Program
    {
        static void Main()
        {
            Employee emp1 = new Employee();
            emp1.Menu();
        }
    }

    class Employee
    {

        //declaring the data members

        public double ID { get; set; }
        public string Name { get; set; }
        public string Departmnet { get; set; }
        public double Salary { get; set; }



        // For Menu Purpose
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\n---------Employement Management Menu---------");
                Console.WriteLine("\n1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("\nChoose an option: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: AddEmployee(); break;
                        case 2: ShowData(); break;
                        case 3: SearchId(); break;
                        case 4: Update(); break;
                        case 5: Delete(); break;
                        case 6: Console.WriteLine("Thank you!..."); Environment.Exit(0); break;
                        default: Console.WriteLine("Invaid Choice...Try Again"); break;
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 6.");
                    continue;
                }


            }
        }

        //creating the List Name Employees

        List<Employee> employee = new List<Employee>();

        //-------creating Methods---------




        // Add New Employees
        public void AddEmployee()
        {
            Employee emp = new Employee(); // object has been created for doing...

            try
            {
                Console.Write("\nEnter the ID : ");
                emp.ID = double.Parse(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("\nInvalid input format. Please enter numbers where expected.");
                return;
            }


            Console.Write("\nEnter the Name : ");
            emp.Name = Console.ReadLine();

            Console.Write("\nEnter the Department : ");
            emp.Departmnet = Console.ReadLine();

            try
            {
                Console.Write("\nEnter the Salary : ");
                emp.Salary = double.Parse(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("\nInvalid input format. Please enter numbers where expected.");
                return;
            }

            //adding

            employee.Add(emp);

            Console.WriteLine("\nEmployee Added Successfully....");

        }

        // For Showing Details
        public void ShowData()
        {

            if (employee.Count == 0) { Console.WriteLine("\nNo one to display..."); }

            else
            {
                foreach (Employee i in employee)
                {
                    Console.WriteLine("\n******The Employee Details*******");
                    Console.WriteLine($"\nID         : {i.ID}");
                    Console.WriteLine($"Name       : {i.Name}");
                    Console.WriteLine($"Department : {i.Departmnet}");
                    Console.WriteLine($"Salary     : {i.Salary}");
                }
            }
        }

        //For Search Id

        public void SearchId()
        {
            try
            {
                Console.Write("\nEnter the Id to be Searched : ");
                double search = double.Parse(Console.ReadLine());

                foreach (Employee e in employee)
                {
                    if (e.ID == search)
                    {
                        Console.WriteLine($"\nID : {e.ID} \nName : {e.Name} \nDepartment : {e.Departmnet} \nSalary : {e.Salary}");
                    }

                    else { Console.WriteLine("\nThere is no employee with that ID..."); }
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid numerical ID.");
            }
        }


        //For Update

        public void Update()
        {
            try
            {
                Console.Write("\nEnter the Id to be Updated : ");
                double updateId = double.Parse(Console.ReadLine());

                Employee match = employee.FirstOrDefault(e => e.ID == updateId);

                if (match != null)
                {
                    Console.Write("\nEnter new Name: ");
                    match.Name = Console.ReadLine();

                    Console.Write("Enter new Department: ");
                    match.Departmnet = Console.ReadLine();

                    Console.Write("Enter new Salary: ");
                    match.Salary = double.Parse(Console.ReadLine());

                    Console.WriteLine("\nEmployee updated successfully.");
                }

                else { Console.WriteLine("\nThere is no employee with that ID."); }

            }

            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid numerical ID.");
            }
        }

        //For Deletion

        public void Delete()
        {
            try
            {
                Console.Write("\nEnter the Employee ID to delete : ");
                double search = double.Parse(Console.ReadLine());

                Employee delete = employee.FirstOrDefault(e => e.ID == search);
                if (delete != null)
                {
                    employee.Remove(delete);
                    Console.WriteLine("\nEmployee removed successfully.");
                }

                else
                {
                    Console.WriteLine("\nThere is no employee with that ID...");
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("\nPlease enter a valid numerical ID.");
            }

        }

    }
}