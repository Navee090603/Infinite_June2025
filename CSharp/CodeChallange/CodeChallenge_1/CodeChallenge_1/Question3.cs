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
        //Exception Handling

        //public void GetValidInput(string message)
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            Console.Write(message);
        //            string input = Console.ReadLine();

        //            if (String.IsNullOrWhiteSpace(input))
        //                throw new ArgumentNullException("Input cannot be empty. Please Enter the Valid input")
        //        }
        //    }
        //}


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


            Console.Write("The Elements are : ");
            for (int i = 0; i < Length; i++)
            {
                Console.Write(input[i]);
                if (i < Length - 1)
                {
                    Console.Write(",");
                }
            }



            int max = input[0];

            for(int i = 0; i < Length; i++)
            {
                if (input[i] > max)
                {
                    max = input[i];
                }
            }

            Console.WriteLine($"\nThe Largest Number is {max}");

        }

        
    }
}
