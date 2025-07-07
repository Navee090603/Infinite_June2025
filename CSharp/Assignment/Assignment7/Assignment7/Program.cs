using System;
using System.Collections.Generic;
using System.Linq;
using TravelLibrary;  //class library created and added 
using System.Text;
using System.Threading.Tasks;

namespace Assignment7
{
    class Q1_4
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Choose the Question Number to Display the answer (1 to 4): ");
                string Choice = Console.ReadLine();

                if (int.TryParse(Choice, out int number))
                {
                    if (number == 1)
                    {
                        Question_1 question_1 = new Question_1();
                        question_1.ReturnSquare();
                    }
                    else if (number == 2)
                    {
                        Question_2 question_2 = new Question_2();
                        question_2.ReturnString();
                    }
                    else if (number == 3)
                    {
                        Question_3 question_3 = new Question_3();
                        question_3.Employee();
                    }
                    else if (number == 4)
                    {
                        Program travelApp = new Program(); 
                        Program.control();
                    }

                    else
                    {
                        Console.Write("Invalid choice. Please choose between 1 and 4.");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid numeric question number.");
                }

                Console.WriteLine("\nPress any key to try again or close the window to exit...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

//    1.) 
//Write a query that returns list of numbers and their squares only if square is greater than 20 

//Example input[7, 2, 30]
//Expected output
//→ 7 - 49, 30 - 900
    
    class Question_1
    {
        public void ReturnSquare()
        {
            //Length of list asked from the user
            int Len;
            while (true)
            {
                Console.Write("Enter the Length of the list : ");
                string input = Console.ReadLine();
                if (int.TryParse(input,out Len) && Len > 0)//checking if only integer is enterd
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the Positive Numbers for Length....");
                }
            }
            Console.Clear();

            List<int> list = new List<int>(Len);        //creating list to store the inputs

            for (int r=0; r < Len; r++)                 //asking each element of the lsit from the user
            {
                Console.Write($"Enter the element {r+1} : ");
                int num;
                while(!int.TryParse(Console.ReadLine(),out num))
                {
                    Console.Write("Invalid Input.\nPlease enter a number : ");

                }
                list.Add(num);
            }
            Console.Clear();

            var result = from n in list                  //query expression to check the sqr is > 25
                         let square=n*n
                         where square > 20
                         select (n,square);

            Console.WriteLine("The inputs are....");
            Console.WriteLine(string.Join(",",list));   //Displaying the Inputs

            Console.WriteLine("\nSquare Numbers are");
            foreach(var num in result)                  //Displaying only the condition satisfied
            {
                Console.WriteLine();
                Console.WriteLine($"{num.n} -> {num.square}");
            }
        }
    }

//    2.)
//          Write a query that returns words starting with letter 'a' and ending with letter 'm'.
//          Expected input and output
//          "mum", "amsterdam", "bloom" → "amsterdam"

    class Question_2
    {
        public void ReturnString()
        {

            //Len of the string list
            int Len;
            while (true)
            {
                Console.Write("Enter the Length of the list : ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out Len) && Len > 0)//checking if only integer is enterd
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the Positive Numbers for Length....");
                }
            }
            Console.Clear();

            //creating the string list
            String[] list = new String[Len];

            //each element in the string list
            for(int i = 0; i < Len; i++)
            {
                Console.Write($"Enter the {i+1} word : ");
                String inputWord = Console.ReadLine();
                list[i]=inputWord;
            }
            Console.Clear();

            //Querry Start with 'a/A' and ends with 'm/M'
            var find = from n in list
                       where n.Length>0 && char.ToLower(n[0]) == 'a' && char.ToLower(n[n.Length - 1]) == 'm'
                       select n;



            //displaying the output that meets the querry
            string filter = string.Join(",", find.Select(word => $"'{word}'"));
            Console.WriteLine("\nThe Word Starts with 'a/A' and Ends with 'm/M' are below ");
            Console.WriteLine();
            Console.WriteLine($"[{string.Join(", ", list)}] ----> {filter}");
        }
    }

//    3.	Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary.Populate some data
//Write a program for following requirement
//a.To display all employees data
//b.To display all employees data whose salary is greater than 45000
//c.To display all employees data who belong to Bangalore Region
//d.To display all employees data by their names is Ascending order

    class Question_3
    {
        public long EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }

      
        public void Employee()
        {
            //Length of List from user

            Console.Write("Enter number of Employee : ");
            int n;
            while(!int.TryParse(Console.ReadLine(),out n) || n <= 0)
            {
                Console.Write("Please enter a positive integer for number of employees : ");
            }

            //creating the generic List

            List<Question_3> employees = new List<Question_3>();

            //getting each element
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter the details for Employee {i+1} : ");

                Console.Write("EmpId : ");
                int empId;
                while (!int.TryParse(Console.ReadLine(), out empId))
                    Console.Write("Enter a valid EmpId (integer): ");

                Console.Write("EmpName: ");
                string empName = Console.ReadLine();

                Console.Write("EmpCity: ");
                string empCity = Console.ReadLine();

                Console.Write("EmpSalary: ");
                double empSalary;
                while (!double.TryParse(Console.ReadLine(), out empSalary))
                    Console.Write("Enter a valid EmpSalary (double): ");

                employees.Add(new Question_3 
                { 
                EmpId=empId,
                EmpName=empName,
                EmpCity=empCity,
                EmpSalary= empSalary
                });

            }

            Console.WriteLine("\nAll Employees:");
            DisplayEmployees(employees);

            Console.WriteLine("\nEmployees with salary > 45000:");
            var highsalary = employees.Where(e => e.EmpSalary > 45000);
            DisplayEmployees(highsalary);

            Console.WriteLine("\nEmployees from Bangalore:");
            var bangalore = employees.Where(e => e.EmpCity.Trim().Equals("Bangalore", StringComparison.OrdinalIgnoreCase));
            DisplayEmployees(bangalore);

            Console.WriteLine("\nEmployees sorted by name (ascending):");
            var sortedByName = employees.OrderBy(e => e.EmpName);
            DisplayEmployees(sortedByName);
        }

        //for displaying purpose
        public static void DisplayEmployees(IEnumerable<Question_3> emps)
        {
            foreach (var e in emps)
            {
                Console.WriteLine($"ID: {e.EmpId}, Name: {e.EmpName}, City: {e.EmpCity}, Salary: {e.EmpSalary}");
            }
        }
    }

    //    4.    Create a class library with a function CalculateConcession()  that takes age as an input and calculates concession for travel as below:
    //If age <= 5 then “Little Champs - Free Ticket” should be displayed
    //If age > 60 then calculate 30% concession on the totalfare(Which is a constant Eg:500/-) and Display “ Senior Citizen” + Calculated Fare
    //Else “Print Ticket Booked” + Fare.
    //Create a Console application with a Class called Program which has TotalFare as Constant, Name, Age.Accept Name, Age from the user and call the CalculateConcession() function to test the Classlibrary functionality

    class Program      //created Program class for travelapp
    {
        const int TotalFare = 500;

        public static void control()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int age))
            {
                TravelConcession concession = new TravelConcession(); //method TravelConcession in ClassLibrary
                string result = concession.CalculateConcession(name, age, TotalFare);
                Console.WriteLine("\n" + result);
            }
            else
            {
                Console.WriteLine("Invalid age input.");
            }
        }
    }
}

