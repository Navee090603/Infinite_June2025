using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{

//    2. Create a class called Scholarship which has a function Public void Merit() that takes marks and fees as an input.
//       If the given mark is >= 70 and <=80, then calculate scholarship amount as 20% of the fees
//       If the given mark is > 80 and <=90, then calculate scholarship amount as 30% of the fees
//       If the given mark is >90, then calculate scholarship amount as 50% of the fees.
//       In all the cases return the Scholarship amount, else throw an user exception

    class Question_2
    {
        public static void Main()
        {
            try
            {
                Scholarship scholarship = new Scholarship();
                scholarship.Merit(); // All input and logic inside this method
            }
            catch (UserException ex)
            {
                Console.WriteLine($"Custom Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }

    class UserException : Exception
    {
        public UserException() : base("Enter the valid input") { }
        public UserException(string message) : base(message) { }
    }

    class Scholarship
    {
        public void Merit()
        {
            float marks;
            double fees;

            // Input for marks
            while (true)
            {
                Console.Write("Enter your marks: ");
                string input = Console.ReadLine();

                if (float.TryParse(input, out marks))
                    break;

                Console.WriteLine("Marks must be a numeric value.\n");
            }

            // Input for fees
            while (true)
            {
                Console.Write("Enter your total fees: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out fees))
                    break;

                Console.WriteLine("Fees must be a numeric value.\n");
            }

            // Throwing exception for invalid eligibility
            

            // Scholarship calculation
            double scholarshipAmount;

            if (marks>=70 && marks <= 80)
                scholarshipAmount = fees * 0.20;
            else if (marks>80 && marks <= 90)
                scholarshipAmount = fees * 0.30;
            else if (marks>90)
                scholarshipAmount = fees * 0.50;
            else
                throw new UserException("Marks below 70 are not eligible for scholarship.");

            Console.WriteLine($"\nScholarship Amount: {scholarshipAmount}");
        }
    }
}
