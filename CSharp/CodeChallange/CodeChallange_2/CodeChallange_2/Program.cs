using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallange_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            new StudentTest().RunTest();

            //Question 2
            //ProductCreation productCreation = new ProductCreation();
            //productCreation.ManageProducts();

            //Question 3
            //new NegativeChecker().Validate();

            Console.ReadLine();
        }
    }

    //1.Create an Abstract class Student with Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.  

    //Create 2 Sub classes Undergraduate and Graduate that inherits all members of the student and overrides Ispassed(grade) method

    //For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.

    //Test the above by creating appropriate objects

    abstract class Student
    {
        public string Name { get; set; }
        public double StudentId { get; set; }
        public double Grade { get; set; }

        //method need to be done by subclasses
        public abstract bool IsPassed(double grade);
    }

    //ug class
    class UnderGraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    //graduate class
    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class StudentTest
    {
        public void RunTest()
        {
            Student student = null;

            // until valid type is entered
            while (student == null)
            {
                Console.Write("Enter student type (UnderGrad/Graduate): ");
                string type = Console.ReadLine().ToLower(); 

                if (type == "undergrad")
                    student = new UnderGraduate();
                else if (type == "graduate")
                    student = new Graduate();
                else
                    Console.WriteLine("Invalid student type. Please enter 'UnderGrad' or 'Graduate'.");
            }

            // until valid ID is entered
            while (true)
            {
                Console.Write("Enter Student ID: ");
                if (double.TryParse(Console.ReadLine(), out double id) && id > 0)
                {
                    student.StudentId = id;
                    break;
                }
                Console.WriteLine("Invalid input. Enter a positive numeric Student ID.");
            }

            // Name input
            while (true)
            {
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    student.Name = name;
                    break;
                }
                Console.WriteLine("Name cannot be empty.");
            }

            // Keep asking until valid grade is entered
            while (true)
            {
                Console.Write("Enter Grade (mark): ");
                if (double.TryParse(Console.ReadLine(), out double grade) && grade >= 0)
                {
                    student.Grade = grade;
                    break;
                }
                Console.WriteLine("Invalid input. Enter a non-negative numeric grade.");
            }

            // Display all the result
            bool passed = student.IsPassed(student.Grade);
            Console.WriteLine($"\nStudent: {student.Name} (ID: {student.StudentId})");
            Console.WriteLine($"Grade: {student.Grade}");
            Console.WriteLine($"Status: {(passed ? "Passed" : "Failed")}");
        }
    }


    //2. Create a Class called Products with Productid, Product Name, Price. Accept 10 Products, sort them based on the price, and display the sorted Products

    class Product
    {
        public string ProductId;
        public string ProductName;
        public double Price;

        public void Display()
        {
            Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Price: {Price}");
        }
    }


    class ProductCreation
    {
        public void ManageProducts()
        {
            //for storing values
            List<Product> products = new List<Product>();

            // for user Input 
            for (int i = 0; i < 10; i++)
            {
                Product p = new Product();

                Console.Write($"Enter Product ID {i + 1} : ");
                p.ProductId = Console.ReadLine();

                Console.Write("Enter Product Name : ");
                p.ProductName = Console.ReadLine();

                Console.Write("Enter Product Price : ");
                while (!double.TryParse(Console.ReadLine(), out p.Price))
                {
                    Console.Write("Invalid input. Please enter a valid number: ");
                }

                products.Add(p); // this will add to the list 
                Console.WriteLine();
            }

            // Sorting by price
            var sortedProducts = products.OrderBy(p => p.Price).ToList();

            // Displaying
            Console.WriteLine("\nSorted Products by Price:");
            foreach (var prod in sortedProducts)
            {
                prod.Display();
            }
        }
    }

    //3. Write a C# program to implement a method that takes an integer as input and throws an exception if the number is negative. Handle the exception in the calling code.

    class NegativeChecker
    {
        public void Validate()
        {
            try
            {
                Console.Write("Enter a Number : ");
                int input = int.Parse(Console.ReadLine());

                if (input < 0)
                {
                    throw new ArgumentException("You entered the Neagative number.");
                }

                Console.WriteLine($"Valid input : {input}");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error : Enter the Integer.");
            }
            finally
            {
                Console.WriteLine("completed");
            }
            
        }
        
    }

    ////

}






