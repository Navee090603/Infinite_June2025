using System;


namespace Assignment1
{
    class program
    {
        static void Main(string[] args)  
        {
          
            Console.WriteLine("Enter 1 for Equal or Not ");
            Console.WriteLine("Enter 2 for +ve or -ve ");
            Console.WriteLine("Enter 3 for Multiplication ");
            Console.WriteLine("Enter 4 for MiniCalci  ");
            Console.WriteLine("Enter 5 for Triple Of Integer  ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:program.equalornot();break;
                case 2:program.posorneg();break;
                case 3:program.multiplication();break;
                case 4:program.minicalci();break;
                case 5:program.tripleofintegers();break;
                case 0: Console.WriteLine("Exiting the program. Goodbye!"); break;
                default: Console.WriteLine("Invalid choice. Please enter 0 to 5."); break;

            }


            Console.Read();

        }

        //First Question
         static void equalornot()

        {
            Console.WriteLine("This will Check Both the integer are Equal or Not");
            Console.Write("Enter First Integer : ");
            int Input1 = int.Parse(Console.ReadLine());      //First Input
            Console.Write("Enter Second Integer : ");
            int Input2 = int.Parse(Console.ReadLine());     //Second Input
            string Result = (Input1 == Input2) ? $"{Input1} and {Input2} are Equal" : $"{Input1} and {Input2} are Not Equal"; //Checking Equal or Not
            Console.WriteLine(Result);   //Result
            
        }

        //Second Question

        static void posorneg()
        {
            Console.WriteLine("This is Check the integer is +ve or -ve");
            Console.Write("Enter a Number : ");
            int Input = int.Parse(Console.ReadLine()); //Getting input from the user
            string result = (Input > 0) ? $"Entered Number {Input} is Positive" : $"Entered Number {Input} is Negative";//checking Positive or Negative
            Console.WriteLine(result);
        }

        //Third Question

         static void minicalci()
        {
            Console.WriteLine("This is mini Calculator");
            Console.Write("Enter First Input : ");     //First Input
            int input1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the Operator : ");    //Which Operator
            char input2 = char.Parse(Console.ReadLine());

            Console.Write("Enter Second Input : ");    //Second Input
            int input3 = int.Parse(Console.ReadLine());

            switch (input2)
            {
                case '+': Console.WriteLine($"The sum is : { input1 + input3}"); break;
                case '-': Console.WriteLine($"The Difference is : {input1 - input3}"); break;
                case '*': Console.WriteLine($"The Product is :  {input1*input3}"); break;
                case '/': Console.WriteLine($"The Division is : {input1 / input3}"); break;
                default: Console.WriteLine("Enter Valid Operator"); break;
            }
        }

        //Fourth Question

         static void multiplication()
        {
            Console.WriteLine("This is show Tables for us");
            Console.Write("Enter a Number for Multiples : ");         //input from users
            int input = int.Parse(Console.ReadLine());
            int inc = 0;                                              //assignig incrementor

            do
            {
                Console.WriteLine($"{input} * {inc} = {input * inc}");  //for example 1*0=0
                inc++;

            } while (inc <= 10);                                      //runs until 1*10=10
        }

        //Fivth Question

        static void tripleofintegers()
        {
            Console.WriteLine("If Both integer are not same it will triple sum , Else sum.");
            Console.Write("First Integer : ");                                            //getting First Input
            int input1 = int.Parse(Console.ReadLine());

            Console.Write("Second Integer : ");                                           //getting second Input
            int input2 = int.Parse(Console.ReadLine());

            if (input1 != input2) Console.WriteLine($"The sum is : {input1 + input2}");    //If Not equal sum
            else Console.WriteLine($"The triplet of Integer is : {input1 * 3}");            //If equal triple of sum
        }

    }
}
