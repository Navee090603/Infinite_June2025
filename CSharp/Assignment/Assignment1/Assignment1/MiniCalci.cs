using System;

namespace Assignment1
{
    class MiniCalci
    {
        static public void minicalci()
        {
            Console.Write("Enter First Input : ");     //First Input
            int input1 = int.Parse(Console.ReadLine());

            Console.Write("Enter the Operator : ");    //Which Operator
            char input2 = char.Parse(Console.ReadLine());

            Console.Write("Enter Second Input : ");    //Second Input
            int input3 = int.Parse(Console.ReadLine());
            
            switch (input2)
            {
                case '+': Console.WriteLine($"The sum is : { input1 + input3}");          break;
                case '-': Console.WriteLine($"The Difference is : {input1 - input3}");    break;
                case '*': Console.WriteLine($"The Product is :  {input1* input3}");       break;
                case '/': Console.WriteLine($"The Division is : {input1 / input3}");      break;
                default :  Console.WriteLine("Enter Valid Operator");                     break;
            }
        } 
    }
}
