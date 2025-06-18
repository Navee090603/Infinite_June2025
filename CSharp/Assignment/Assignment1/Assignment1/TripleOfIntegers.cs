using System;


namespace Assignment1
{
    class TripleOfIntegers
    {
        public static void tripleofintegers()
        {
            Console.Write("First Integer : ");                                            //getting First Input
            int input1 = int.Parse(Console.ReadLine()); 

            Console.Write("Second Integer : ");                                           //getting second Input
            int input2 = int.Parse(Console.ReadLine());

            if (input1 != input2)  Console.WriteLine($"The sum is : {input1+input2}");    //If Not equal sum
            else Console.WriteLine($"The triplet of Integer is : {input1*3}");            //If equal triple of sum
        }
    }
}
