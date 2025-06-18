using System;


namespace Assignment1
{
    class EqualorNot
    {
        static void Main(string[] args)  //One Main in Entire Project
        {
            //equalornot();            //---------------> Equal or Not 
            //PosOrNeg.posorneg();     //---------------> +ve or -ve
            //MiniCalci.minicalci();     //----------------->Operation
            //Multipication.multiplication(); //------------>Tables
            TripleOfIntegers.tripleofintegers();  //--------->Triple of Number

            Console.Read();

        }

        static void equalornot()
        {
            Console.Write("Enter First Integer : ");
            int Input1 = int.Parse(Console.ReadLine());      //First Input
            Console.Write("Enter Second Integer : ");
            int Input2 = int.Parse(Console.ReadLine());     //Second Input
            string Result = (Input1 == Input2) ? $"{Input1} and {Input2} are Equal" : $"{Input1} and {Input2} are Not Equal"; //Checking Equal or Not
            Console.WriteLine(Result);   //Result
            
        }

    }
}
