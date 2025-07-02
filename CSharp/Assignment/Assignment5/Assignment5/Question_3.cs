using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
//    3. Create a class called Books with BookName and AuthorName as members.Instantiate the class through constructor and also write a method Display() to display the details.

//       Create an Indexer of Books Object to store 5 books in a class called BookShelf.Using the indexer method assign values to the books and display the same.

//       Hint(use Aggregation/composition)
    class Question_3
    {
        static void Main()
        {
            BookShelf bookShelf = new BookShelf();

            for (int i = 0; i < 5; i++) 
            {
                Console.Write($"\nEnter Book {i + 1} Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Author Name: ");
                string author = Console.ReadLine();

                bookShelf[i] = new Books(name, author);
            }
            //Dispalying All
            bookShelf.DisplayAll();

            Console.ReadLine();
        }
        
    }

    class Books
    {

        //Data members
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        //constructor
        public Books(string bookName,string authorName)
        {
            BookName = bookName;
            AuthorName = authorName;
        }
        
        //Display Method
        public void Display()
        {
            Console.WriteLine($"Book : {BookName} \nAuthor Name : {AuthorName}");
        }

    }

    //creating bookShelf to store composition
    class BookShelf
    {
        private Books[] books = new Books[5];

        // Indexer to access or assign books via index
        public Books this[int index]
        {
            get
            {
                if (index < 0 || index >= books.Length)
                    throw new IndexOutOfRangeException("Invalid Index...");
                return books[index];
            }
            set
            {
                if (index < 0 || index >= books.Length)
                    throw new IndexOutOfRangeException("Invalid index...");
                books[index] = value;
            }
        }

        //Displaying all in the bookshelf

        public void DisplayAll()
        {
            Console.WriteLine("\nBookShelf Contents");
            for(int i = 0; i < books.Length; i++)
            {
                Console.WriteLine($"Slot {i + 1} :");

                if (books[i] != null)
                    books[i].Display();
                else
                    Console.WriteLine("Empty");
            }
        }
    }


}
