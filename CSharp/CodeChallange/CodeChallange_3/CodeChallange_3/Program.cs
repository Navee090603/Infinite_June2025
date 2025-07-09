using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallange_3
{
    class Program
    {
        //All the questions Object where created Here.If you enter the question Number you'll see the answer.
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Choose the Question Number to Display the answer (1 to 4): ");
                string Choice = Console.ReadLine();

                if (int.TryParse(Choice, out int number))
                {
                    if (number == 1)   //For Question 1
                    {
                        CricketTeam cricketTeam = new CricketTeam();
                        cricketTeam.Calculate();
                    }
                    else if (number == 2)  //For Question 2
                    {
                        Box box = new Box();
                        box.Question_2();
                    }
                    else if (number == 3)  //For Question 3
                    {
                        AddText addText = new AddText();
                        addText.Question_3();
                    }
                    else if (number == 4) //For Question 4
                    {
                        Calculator calculator = new Calculator();
                        calculator.Question_4();
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

    //1.1.Write a program to find the Sum and the Average points scored by the teams in the IPL. Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) that takes no.of matches as input and accepts that many scores from the user. The function should then return the Count of Matches, Average and Sum of the scores.
    class CricketTeam
    {
        public void Pointscalculation(int no_of_matches)
        {
            int[] scores = new int[no_of_matches];
            int sum = 0;

            Console.WriteLine("\nEnter the points scored in the each match ");

            for (int i = 0; i < no_of_matches; i++)
            {
                int s;
                bool valid = false;

                // Repeat until a valid number is entered
                while (!valid)
                {
                    Console.Write($"Match {i + 1}: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out s) && s > 0)
                    {
                        scores[i] = s;
                        sum += s;
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number.");
                    }
                }
            }


            double average = (double)sum / no_of_matches;

            Console.WriteLine("\n*** Points Summary ***");
            Console.WriteLine("\nTotal Matches Played : " + no_of_matches);
            Console.WriteLine("Sum of Points : " + sum);
            Console.WriteLine("Average Points : " + average);

        }

        
        public void Calculate()
        {
            Console.WriteLine("\n*******Question 1******");
            Console.Write("\nEnter the number of matches played : ");
            int matches = Convert.ToInt32(Console.ReadLine());

            CricketTeam team = new CricketTeam();
            team.Pointscalculation(matches);
        }
    }

    //2. Write a class Box that has Length and breadth as its members. Write a function that adds 2 box objects and stores in the 3rd. Display the 3rd object details. Create a Test class to execute the above.
    class Box
    {
        //memebers
        public double Length { get; set; }
        public double Breadth { get; set; }

        //Default Constructor
        public Box() { }

        //Parameterized Constructir
        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        //Method to add two Box objects
        public static Box Add(Box b1, Box b2)
        {
            double nLength = b1.Length + b2.Length;
            double nBreadth = b1.Breadth + b2.Breadth;
            return new Box(nLength, nBreadth);
        }

        //Display the detils
        public void Display()
        {
            Console.WriteLine($"Box Dimension \nLength : {Length} \nBreadth : {Breadth}");
        }

        public void Question_2()
        {

            Console.WriteLine("\n*******Question 2******");
            int length1 = 0, breadth1 = 0;
            bool validLength1 = false;
            bool validBreadth1 = false;

            while (!validLength1)
            {
                Console.Write("Enter the Box 1 Length: ");
                if (int.TryParse(Console.ReadLine(), out length1) && length1 > 0)
                    validLength1 = true;
                else
                    Console.WriteLine("Please enter a positive number.");
            }

            while (!validBreadth1)
            {
                Console.Write("Enter the Box 1 Breadth: ");
                if (int.TryParse(Console.ReadLine(), out breadth1) && breadth1 > 0)
                    validBreadth1 = true;
                else
                    Console.WriteLine("Please enter a positive number.");
            }

            int length2 = 0, breadth2 = 0;
            bool validLength2 = false;
            bool validBreadth2 = false;

            while (!validLength2)
            {
                Console.Write("Enter the Box 2 Length: ");
                if (int.TryParse(Console.ReadLine(), out length2) && length2 > 0)
                    validLength2 = true;
                else
                    Console.WriteLine("Please enter a positive number.");
            }

            while (!validBreadth2)
            {
                Console.Write("Enter the Box 2 Breadth: ");
                if (int.TryParse(Console.ReadLine(), out breadth2) && breadth2 > 0)
                    validBreadth2 = true;
                else
                    Console.WriteLine("Please enter a positive number.");
            }

            // Create two box objects
            Box box1 = new Box(length1, breadth1);
            Box box2 = new Box(length2, breadth2);

            // Add them and store the result in box3
            Box box3 = Box.Add(box1, box2);

            // Display box3 dimensions
            Console.WriteLine("\nResulting Box");
            box3.Display();
        }

    }

    //3. Write a program in C# Sharp to append some text to an existing file. If file is not available, then create one in the same workspace.

    class AddText
    {
        public void Question_3()
        {
            Console.WriteLine("\n*******Question 3******");

            Console.Write("Enter the file name : ");
            string fileName = Console.ReadLine();

            Console.Write("Enter text to append: ");
            var text = Console.ReadLine();

            // Append text and create file if it doesn't exist
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(text);
            }

            Console.WriteLine($"Text successfully added to '{fileName}'.");
        }
    }


    //4.Write a console program that uses delegate object as an argument to call Calculator Functionalities like 1. Addition, 2. Subtraction and 3. Multiplication by taking 2 integers and returning the output to the user. You should display all the return values accordingly.
    delegate int CalcDelegates(int n1, int n2);
    class Calculator
    {
        public int AddNumbers(int n1, int n2)
        {
            return n1 + n2;
        }
        public int SubtractNumbers(int n1, int n2)
        {
            return n1 - n2;
        }

        public int MultiplyNumbers(int n1, int n2)
        {
            return n1 * n2;
        }

        public void Question_4()
        {
            Console.WriteLine("\n*******Question 4******");

            int number1 = Integer("\nNumber 1 Input: ");
            int number2 = Integer("Number 2 Input: ");

            Calculator calculator = new Calculator();

            CalcDelegates calcDelegates = new CalcDelegates(calculator.AddNumbers);
            int SumOfNumbers = calcDelegates(number1, number2);

            calcDelegates += calculator.SubtractNumbers;
            int SubOfNumbers = calcDelegates(number1, number2);

            calcDelegates += calculator.MultiplyNumbers;
            int MulOfNumbers = calcDelegates(number1, number2);

            Console.WriteLine("\nSum of Numbers: {0} \nSubtraction of Numbers: {1} \nMultiplication of Numbers: {2}", SumOfNumbers, SubOfNumbers, MulOfNumbers);
        }
        private int Integer(string s)
        {
            int number;
            bool isValid;
            do
            {
                Console.Write(s);
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out number);
                if (!isValid)
                {
                    Console.WriteLine("Invalid input! \nPlease enter a valid number : ");
                }
            } while (!isValid);

            return number;
        }
    }
}
//




//
//Hint: (Use the appropriate mode of operation. Use stream writer class)

