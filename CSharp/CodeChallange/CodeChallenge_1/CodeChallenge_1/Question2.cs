using System;


namespace CodeChallenge_1
{
    class Question2
    {
        static void Main(string[] args)
        {


            //object of 2nd question
            Swap_Char swap_Char = new Swap_Char();
            swap_Char.Show_Data();



            Console.Read();
        }
    }

    class Swap_Char
    {
        public static string Word;

        public Swap_Char()
        {
            Console.Write("Enter the word : ");
            Word = Convert.ToString(Console.ReadLine());
        }
        public void Show_Data()
        {

            if (Word.Length < 2)
            {
                Console.WriteLine("The result is : " + Word);
                return;
            }

            char First_Letter = Word[0];
            char Last_Letter = Word[Word.Length - 1];
            string middle = "";
            for (int i = 1; i < Word.Length - 1; i++)
            {
                middle += Word[i];
            }

            

                Console.WriteLine($"The result is: {Last_Letter + middle + First_Letter}");
            }


            
        
    }
}
