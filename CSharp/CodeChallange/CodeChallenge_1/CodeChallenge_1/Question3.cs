using System;


namespace CodeChallenge_1
{
    class Question3
    {
        static void Main(string[] args)
        {


            //object of 3rd question
            Largest_Number largest_Number = new Largest_Number();
            largest_Number.Finding_Large();
            
            Console.ReadLine();
        }
    }

    class Largest_Number
    {
        
        

        public void Finding_Large()
        {
            Console.Write("Enter the Lenth of the array : ");
            int Length = int.Parse(Console.ReadLine());

            int[] input = new int[Length];

            for(int i = 0; i < Length; i++)
            {
                Console.Write($"Enter the Number {i+1} : ");
                input[i] = int.Parse(Console.ReadLine());
            }

            int max = input[0];

            for(int i = 0; i < Length; i++)
            {
                if (input[i] > max)
                {
                    max = input[i];
                }
            }

            Console.WriteLine($"The Largest Number is {max}");

        }

        
    }
}
