using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.Write("Enter a Question Number for Answer : ");
            int choice=Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: SwapNumbers(); break;
                case 2: FourTimes();break;
                case 3: PrintingDays(); break;
                case 4: Average_Min_Max();break;
                case 5: TenMarksAndDisplay();break;
                case 6: OneArrayToAnother();break;
                case 7: LengthOfString();break;
                case 8: TwoWordsString();break;
                default: Console.WriteLine("Enter the Question Number B/W 1-8");break;
            }
            
            Console.ReadLine();
        }

        //1.This is method for Swapping Numbers

        static void SwapNumbers()
        {
            Console.WriteLine("***\n\nThis is the Swap Program***");

            int a; int b;

            Console.Write($"\nEnter a Number a : ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write($"Enter a Number b : ");
            b = Convert.ToInt32(Console.ReadLine());

            int swap = a;
            a = b;
            b = swap;

            Console.WriteLine($"The Value of 'a' is swapped as {a}");
            Console.WriteLine($"The Value of 'b' is swapped as {b}");

        } 

        //2.his is method for 4 times in a row

        static void FourTimes()
        {
            Console.WriteLine("***\n\nThis is the Four Times Program***");
            Console.Write("\nEnter a number: ");
            int num = int.Parse(Console.ReadLine());


            for (int i = 0; i < 2; i++)
            {
                //if (i % 2 == 0)
                    Console.WriteLine("{0} {0} {0} {0}", num);
                //else
                    Console.WriteLine("{0}{0}{0}{0}", num);    
            }
            

            //    int Number,line1,line2;

            //    Console.Write("\nEnter a Number : ");
            //    Number = Convert.ToInt32(Console.ReadLine());

            //    line1 = 0;
            //    line2 = 0;
            //    do
            //    {

            //        line1++;
            //        Console.WriteLine();
            //        line2 = 0;
            //        if (line1 % 2 != 0)
            //        {
            //            do
            //            {
            //                line2++;
            //                Console.Write(Number + " ");
            //            } while (line2 <= 3);
            //        }
            //        else
            //        {
            //            do
            //            {
            //                line2++;
            //                Console.Write(Number);
            //            } while (line2 <= 3);
            //        }



            //    } while (line1<=3);
        }

        //3. This is Printing Days program.

        static void PrintingDays()
        {
            Console.WriteLine("\n\n***This is the Printing Days Program***");

            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            Console.Write("\nEnter the Number to See the Day of the Week (1-7): ");
            int number = int.Parse(Console.ReadLine());

            if (number >= 1 && number <= 7)
            {
                Console.WriteLine($"The day is: {days[number - 1]}");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
            }
        }


        //4. This is Program to assign integer values to an array  and then print the following

        static void Average_Min_Max()
        {
            Console.WriteLine("\n\n*****This is Program to assign integer values to an array******");

            Console.Write("\nEnter the Size of the Array you Needed : ");
            int size = int.Parse(Console.ReadLine());
            int[] num = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter the element {i+1} : ");
                num[i]=int.Parse(Console.ReadLine());
            }

            int Maximum = num.Max(), Minimum = num.Min();
            double average = num.Average();

            Console.WriteLine("Array Elements: " + string.Join(",", num));
            Console.WriteLine($"The Maximum Value is : {Maximum} \nThe Minimum Value is : {Minimum} \nThe Average is : {average}");
        }

        //5. This is Program to accept ten marks and display the following

        static void TenMarksAndDisplay()
        {
            Console.WriteLine("\n\n*****This is Program to accept ten marks and display the following*****");
           
            int[] Marks = new int[10];
           
            for(int i = 0; i < 10; i++)
            {
                Console.Write($"\nEnter the Mark {i + 1} : ");
                Marks[i] = int.Parse(Console.ReadLine());
            }

            int Total = Marks.Sum(), Maximum = Marks.Max(), Minimum = Marks.Min(); 
            Array.Sort(Marks);
           
            double average = Marks.Average();

            Console.WriteLine($"\nThe Total Marks You Obtained : {Total} \nThe Maximum Mark You Obtained : {Maximum} \nThe Minimum Marks You Obtained : {Minimum} \nThe Average Mark of Your's is : {average} ");
            
            Console.Write("Ascending Order : ");
            foreach (int asc in Marks)
            {
                Console.Write($"{asc + " "}");
            }

            Array.Reverse(Marks);

            Console.WriteLine("\nDescending Order is : ");
            foreach (int asc in Marks)
            {
                Console.Write($"{asc + " "}");
            }
        }

        //6. One Array to Another One

        static void OneArrayToAnother()
        {
            Console.Write("\nEnter the Size of the Array you Needed : ");
            int size = int.Parse(Console.ReadLine());
            int[] num1 = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter the element {i + 1} : ");
                num1[i] = int.Parse(Console.ReadLine());
            }
            
            
            int[] num2 = new int[size];
            for (int i = 0; i < size; i++)
            {
                num2[i] = num1[i];
            }


            foreach (int item1 in num1)
            {
                Console.Write(item1 + " ");
            }

            Console.WriteLine();

            foreach (int item2 in num2)
            {
                Console.Write(item2 +" ");
            }

        }

        //7.Length Of the String

        static void LengthOfString()
        {
            Console.Write("Enter a Word : ");
            string Word = Console.ReadLine();
            int length = Word.Length;
            string word1 = new string(Word.Reverse().ToArray());

            Console.WriteLine("The length of the word is {0} \nThe reverse is {1} ",length,word1);
        }

        //8.Two Words

        static void TwoWordsString()
        {
            Console.Write("Enter the First String : ");
            string input1 = Console.ReadLine();
            Console.Write("Enter the Second String :");
            string input2 = Console.ReadLine();

            if (input1 == input2)
            {
                Console.WriteLine("Both the Inputs are Same !");
            }
            else
            {
                Console.WriteLine("Both are Not Same....");
            }
        }
    }
}
