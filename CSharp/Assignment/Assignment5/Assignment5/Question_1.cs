using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    //Exception Handling :  
    //1.You have a class which has methods for transaction for a banking system. (created earlier)
    //	Define your own methods for deposit money, withdraw money and balance in the account.
    //	Write your own new application Exception class called InsuffientBalanceException.
    //	This new Exception will be thrown in case of withdrawal of money from the account where customer doesn’t have sufficient balance.
    //	Identify and categorize all possible checked and unchecked exception.

    class Question_1
    {
        public static void Main()
        {
            try
            {
                BankingSystem bankingSystem = new BankingSystem(); //class Banking System which may occur error
                bankingSystem.Show();
            }
            catch (InsuffientBalanceException ex)                 //Custom error for withdraw
            {
                Console.WriteLine($"Custom Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument Error: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input Format Error: {ex.Message}");
            }

            Console.ReadLine();
        }
    }

    // Custom Exception class
    class InsuffientBalanceException : Exception
    {
        public InsuffientBalanceException() : base("Withdrawn amount exceeds available balance.") { } //default message in custom
        //public InsuffientBalanceException(string message) : base(message) { }//this is useful when the custom message can be alter usring throw
    }

    // Banking System Class
    class BankingSystem
    {
        public string AccountNumber;
        public string CustomerName;
        public double Balance = 1000; // default balance
        public double Amount;
        public char Mode;


        //user input via constructor
        public BankingSystem()
        {
            //Account Number
            Console.Write("Enter Your Account Number: ");
            AccountNumber = Console.ReadLine();

            //Customer Name
            Console.Write("Enter Your Name: ");
            CustomerName = Console.ReadLine();

            //Amount
            while (true)
            {
                Console.Write("Enter the Amount: ");
                if (!double.TryParse(Console.ReadLine(), out Amount))
                {
                    Console.WriteLine(" Amount must be a numeric value.\n");
                    continue;
                }

                if (Amount == 0)
                {
                    Console.WriteLine(" Amount cannot be zero. Please enter a valid amount.\n");
                    continue;
                }

                if (Amount < 0)
                {
                    Console.WriteLine(" Amount must be positive.\n");
                    continue;
                }

                break; // when the input is valid exit's the loop
            }

            //Withdraw or deposit
            while (true)
            {
                Console.Write("Enter D for Deposit or W for Withdraw: ");
                string input = Console.ReadLine().ToLower();

                if (!string.IsNullOrEmpty(input) && (input[0] == 'd' || input[0] == 'w'))
                {
                    Mode = input[0];
                    break;
                }

                Console.WriteLine("Invalid transaction mode. Please enter 'D' or 'W'.\n");
            }

        }

        //Method Deposit
        public void Deposit()
        {
            Balance += Amount;
            Console.WriteLine($"\nDeposited Amount: {Amount}\nNew Balance: {Balance}");
        }

        //Method Withdraw
        public void Withdraw()
        {
            if (Amount > Balance)
            {
                throw new InsuffientBalanceException();
                //throw new InsuffientBalanceException("Enter the Amount below Balance..");
            }

            Balance -= Amount;
            Console.WriteLine($"\nWithdrawn Amount: {Amount}\nNew Balance: {Balance}");
        }

        //Method Show to display all
        public void Show()
        {
            Console.WriteLine($"\nCustomer Name: {CustomerName}\nAccount Number: {AccountNumber}\nMode: {Mode}");

            if (Mode == 'd')
            {
                Deposit();
            }
            else if (Mode == 'w')
            {
                Withdraw();
            }
        }
    }
}
