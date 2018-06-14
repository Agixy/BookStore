using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class BookContainer
    {
        public List<Book> BookList { get; }
        public List<Book> CycleList { get; }

        public BookContainer()          
        {
            BookList = new List<Book>();
            CycleList = new List<Book>();
        }

        public void AddBook(Book book)
        {
            BookList.Add(book); 
        }      

        public void FindBookTitle(string title) 
        {
            bool check = false, cycle = false;
            int i = 1;
            title.ToLower();
            foreach (Book book in BookList)
            {               
                book.Title.ToLower();
                if (book.Title == title)
                {
                    check = true;
                    Console.WriteLine($"{i}. {book.Title} - {book.AuthorName} {book.AuthorSurname} ({book.PublicationDate.Year})");         

                    if (book.CycleTitle != "")
                    {
                        foreach (Book cycleBook in CycleList)
                        {
                            if (cycleBook.CycleTitle == book.CycleTitle && cycleBook.Title != book.Title)
                            {
                                if (cycle == false)
                                {
                                    Console.WriteLine($"Inne książki z cyklu {book.CycleTitle}: ");
                                    cycle = true;
                                }
                                Console.WriteLine($"\t .{cycleBook.Title}");
                                Console.WriteLine();
                            }
                        }
                    }
                    i++;
                }             
            }
            if(check == false)
            {
                Console.WriteLine($"Nie znaleziono książki o tytule {title} ");
            }
            Console.ReadKey();
        }

        public void FindBookAuthor(string authorName, string authorSurname)
        {
            bool check = false;
            int i = 1;
            //title.ToLower();
            foreach (Book book in BookList)
            {
                //book.Title.ToLower();
                if (book.AuthorName == authorName && book.AuthorSurname == authorSurname)
                {
                    Console.WriteLine($"{i}. {book.Title} - {book.AuthorName} {book.AuthorSurname} ({book.PublicationDate})");
                    check = true;
                    i++;
                }
            }
            if (check == false)
            {
                Console.WriteLine($"Nie znaleziono książki autora {authorName} {authorSurname} ");
            }
            Console.ReadKey();
        }

        public void AddCycle(Book book)
        {
            CycleList.Add(book);
        }      
    }
}
