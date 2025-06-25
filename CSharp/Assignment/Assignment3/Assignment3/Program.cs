using System;
using System.Linq;

namespace Assignment3
{
    class Program
    {
        //this is the Main in the Entire Program
        static void Main(string[] args)
        {

            Console.Write("Enter a Question Number for Answer : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Account acc = new Account(); //creating object for 1st Question
                    acc.ShowData();
                    Console.Read();
                    break;

                case 2:
                    Student student = new Student(); //object for 2nd Question
                    student.GetMarks();
                    student.DisplayData();
                    Console.Read();
                    break;

                case 3:
                    new SalesDetails();  //constructor for 3rd question created
                    SalesDetails.Sales();
                    SalesDetails.ShowData(); //object was not Created by using Static keyword for 3rd question
                    Console.Read();
                    break;

            }
        }
    }
    //1. Create a class called Accounts which has data members/fields like Account no, Customer name, Account type, Transaction type (d/w), amount, balance
    class Account
    {

        // fields

        public int Amount;
        public int Balance = 1000;  //-----> Minimum Balance
        public double Account_Number;
        public string Customer_Name;
        public string Account_Type;
        public string Transaction_Type;


        //Constructor
        public Account()
        {
            Console.Write("\nEnter Account Number: ");
            Account_Number = double.Parse(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            Customer_Name = Console.ReadLine();

            Console.Write("Enter Account Type (Savings/Current): ");
            Account_Type = Console.ReadLine();

            Console.Write("Enter Transaction Type (D for Deposit, W for Withdrawal): ");
            Transaction_Type = Console.ReadLine().ToLower();

            Console.Write("Enter Amount: ");
            Amount = int.Parse(Console.ReadLine());

            if (Transaction_Type == "d") credit(Amount);
            else if (Transaction_Type == "w") debit(Amount);
            else { Console.WriteLine("Enter D for Deposit or W for Withdraw"); }
        }


        //credit method
        public void credit(int Amount)
        {
            Balance += Amount;
            Console.WriteLine($"Amount Deposited: {Amount}");
        }

        //debit method
        public void debit(int Amount)
        {
            if (Amount <= Balance)
            {
                Balance -= Amount;
                Console.WriteLine($"Amount Withdrawn : {Amount}");
            }
            else
            {
                Console.WriteLine("The amount exceeds the balance.");
            }
        }


        //showdata method
        public void ShowData()
        {
            Console.WriteLine("\n----- Account Summary -----");
            Console.WriteLine($"\nAccount Number: {Account_Number}");
            Console.WriteLine($"Customer Name : {Customer_Name}");
            Console.WriteLine($"Account Type  : {Account_Type}");
            Console.WriteLine($"Transaction   : {(Transaction_Type == "d" ? "Deposit" : "Withdrawal")}");
            Console.WriteLine($"Amount        : {Amount}");
            Console.WriteLine($"Final Balance : {Balance}");
        }

    }

    // 2. Create a class called student which has data members like rollno, name, class, Semester, branch, int [] marks=new int marks [5](marks of 5 subjects )
    class Student
    {

        //data members

        public double RollNo;
        public string Name;
        public string Class;
        public int Semester;
        public string Branch;
        int[] Marks = new int[5];

        //Constructor

        public Student()
        {
            Console.Write("\nEnter the Roll Number : ");
            RollNo = double.Parse(Console.ReadLine());

            Console.Write("Enter Your Name : ");
            Name = Convert.ToString(Console.ReadLine());

            Console.Write("Enter Your Class (A, B or C) : ");
            Class = Convert.ToString(Console.ReadLine());

            Console.Write("Which Semester Are you now 1-8 : ");
            Semester = int.Parse(Console.ReadLine());

            Console.Write("Which Branch are you from : ");
            Branch = Convert.ToString(Console.ReadLine());
        }

        //GetMarks Method for getting 5 Subject Mark
        public void GetMarks()
        {
            Console.WriteLine("\n*******Enter Your mark's on 5 subject*******");
            Console.WriteLine();
            for (int i = 0; i < Marks.Length; i++)
            {
                Console.Write($"Enter the {i + 1} subject Mark : ");
                Marks[i] = int.Parse(Console.ReadLine());
            }
        }

        //DisplayResult Method for checking the condition
        public void DisplayResult()
        {
            double Average = Marks.Average();

            bool pass = true;
            foreach (int i in Marks)
            {
                if (i < 35)
                {
                    pass = false;
                }
            }

            if (!pass || Average < 50)
            {
                Console.WriteLine("You Failed....");
            }
            else { Console.WriteLine("You Passed...."); }
        }

        //Display Method for displaying all object member values

        public void DisplayData()
        {
            Console.WriteLine();
            Console.WriteLine($"********* Semester Mark Detail's *********");
            Console.WriteLine("\nRoll Number : {0} ", RollNo);
            Console.WriteLine("Name          : {0} ", Name);
            Console.WriteLine("Class         : {0} ", Class);
            Console.WriteLine("Semester      : {0}", Semester);
            Console.WriteLine("Branch        : {0}", Branch);

            Console.Write("Your result  :  "); DisplayResult(); //Whether pass or fail will be shown here

        }
    }

    //3. Create a class called Saledetails which has data members like Salesno,  Productno,  Price, dateofsale, Qty, TotalAmount

    class SalesDetails
    {
        //Data Members
        public static int SalesNumber;
        public static int ProductNumber;
        public static float Price;
        public static string DateOfSale;
        public static double Quantity;
        public static double TotalAmount = 0;


        //Method Sales for Total Amount
        public static void Sales()
        {
            TotalAmount = Quantity * Price;
        }

        //constructor

        public SalesDetails()
        {
            Console.Write("\nEnter the Sales Number : ");
            SalesNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the Product Number : ");
            ProductNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the Quantity of Product : ");
            Quantity = double.Parse(Console.ReadLine());

            Console.Write("Enter the Price of the Object : ");
            Price = float.Parse(Console.ReadLine());

            Console.Write("ENter the Date of Sale : ");
            DateOfSale = Convert.ToString(Console.ReadLine());
        }

        //showMethod

        public static void ShowData()
        {
            Console.WriteLine("******\nSales Details Are******");
            Console.WriteLine($"\nSales Number     : {SalesNumber}");
            Console.WriteLine($"Product Number   : {ProductNumber}");
            Console.WriteLine($"Price of Product : {Price}");
            Console.WriteLine($"Quantity         : {Quantity}");
            Console.WriteLine($"Date Of Sale     : {DateOfSale}");
            Console.WriteLine($"Total Amount     : {TotalAmount}");
        }
    }
}
