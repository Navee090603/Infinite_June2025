using System;


namespace Assignment1
{
    class PosOrNeg
    {
        public static void posorneg()
        {
            Console.Write("Enter a Number : "); 
            int Input = int.Parse(Console.ReadLine()); //Getting input from the user
            string result = (Input > 0) ? $"Entered Number {Input} is Positive" : $"Entered Number {Input} is Negative";//checking Positive or Negative
            Console.WriteLine(result);
        }
    }
}
