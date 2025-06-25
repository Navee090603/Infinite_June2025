using System;


namespace CodeChallenge_1
{
    class Question1
    {
        static void Main(string[] args)
        {


            //object of 1st question
            Remove_Char remove_Char = new Remove_Char();
            remove_Char.showData();

            

            Console.Read();
        }
    }

    //1. Remove of Char 

    class Remove_Char
    {
        static int Index;
        static string Word;

        public Remove_Char()
        {
            Console.Write("Enter the Word You Like: ");
            Word = Convert.ToString(Console.ReadLine());

            Console.Write("Enter the Index of Word to remove :");
            Index = int.Parse(Console.ReadLine());
        }

        public void showData()
        {
            if(Index>Word.Length || Index < 0)
            {
                Console.WriteLine("Enter the valid index ");
            }
            else 
            {
                string result = Word.Remove(Index, 1);
                Console.WriteLine($"Result after removing : {result}");
            }
            
        }
    }
}
