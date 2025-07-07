using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Choose the Question Number to Display the answer (1 to 3): ");
                string Choice = Console.ReadLine();

                if (int.TryParse(Choice, out int number))
                {
                    if (number == 1)
                    {
                        Question_1 question_1 = new Question_1();
                        question_1.CallingOfClass();
                    }
                    else if (number == 2)
                    {
                        Question_2 question_2 = new Question_2();
                        question_2.FileAndArray();
                    }
                    else if (number == 3)
                    {
                        Question_3 question_3 = new Question_3();
                        question_3.CountLine();
                    }
                    else
                    {
                        Console.Write("Invalid choice. Please choose between 1 and 3.");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid numeric question number.");
                }

                Console.WriteLine("\nPress any key to try again or close the window to exit...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }



    //    1. Create a class called Books with BookName and AuthorName as members.Instantiate the class through constructor and also write a method Display() to display the details.

    //       Create an Indexer of Books Object to store 5 books in a class called BookShelf.Using the indexer method assign values to the books and display the same.

    //       Hint(use Aggregation/composition)

    public class Question_1
    {
        public void CallingOfClass()
        {
            BookShelf bookShelf = new BookShelf();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"\nEnter Book {i + 1} Name : ");
                string name = Console.ReadLine();

                Console.Write("Enter Author Name : ");
                string authorName = Console.ReadLine();

                bookShelf[i] = new Books(name, authorName);
            }

            Console.Clear();
            bookShelf.Displayall();
        }
    }

    public class Books
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public Books(string bookName, string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }

        public void Display()
        {
            Console.WriteLine($"Book Name: {BookName}\nAuthor Name: {AuthorName}");
        }
    }

    public class BookShelf
    {
        private Books[] books = new Books[5];

        public Books this[int index]
        {
            get
            {
                if (index < 0 || index >= books.Length)
                    throw new IndexOutOfRangeException("Invalid Index");
                return books[index];
            }
            set
            {
                if (index < 0 || index >= books.Length)
                    throw new IndexOutOfRangeException("Invalid Index");
                books[index] = value;
            }
        }

        public void Displayall()
        {
            Console.WriteLine("\n*******All Contents*******");
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"\nBook {i + 1}");
                if (books[i] != null)
                    books[i].Display();
                else
                    Console.WriteLine("Empty");
            }
        }
    }

    //2. Write a program in C# Sharp to create a file and write an array of strings to the file.

    class Question_2
    {
        public void FileAndArray()
        {
            //ask how many lines
            int NoOfLines;
            while (true)
            {
                Console.Write("Enter how many lines to write: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out NoOfLines) && NoOfLines > 0)
                {
                    break; // valid input, exit loop
                }
                else
                {
                    Console.WriteLine("Enter a valid numeric number greater than 0.");
                }
            }


            string[] userArray = new string[NoOfLines];

            //Loop to read from user
            for (int i = 0; i < NoOfLines; i++)
            {
                Console.Write($"Enter Line Number {i + 1} : ");
                userArray[i] = Console.ReadLine();
            }

            string filePath = "Result.text"; //creating the text file
            try
            {
                File.WriteAllLines(filePath, userArray);
                Console.WriteLine($"Your input has been written to '{filePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Writing to File : " + ex.Message);
            }

        }

    }

    //3. Write a program in C# Sharp to count the number of lines in a file.

    class Question_3
    {
        public void CountLine()
        {
            string filePath;

            while (true)
            {
                Console.Write("Enter the file path: ");
                filePath = Console.ReadLine();

                if (File.Exists(filePath))
                {
                    break; // valid file, exit loop
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }


            string[] lines = File.ReadAllLines(filePath);

            int lineCount = lines.Length;

            Console.WriteLine($"The file '{filePath}' has {lineCount} lines.");

        }
    }
}






