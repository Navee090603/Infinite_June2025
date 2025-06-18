using System;

namespace Assignment1
{
    class Multipication
    {
        public static void multiplication()
        {
            Console.Write("Enter a Number for Multiples : ");         //input from users
            int input = int.Parse(Console.ReadLine());      
            int inc = 0;                                              //assignig incrementor

            do
            {
                Console.WriteLine($"{input} * {inc} = {input*inc}");  //for example 1*0=0
                inc++;

            } while (inc <= 10);                                      //runs until 1*10=10
        }
    }
}
