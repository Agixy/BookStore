using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class BookContainer
    {
        public List<Book> bookList { get; }
        public List<Book> cycleList { get; }

        public BookContainer()              // konstruktor
        {
            bookList = new List<Book>();
            cycleList = new List<Book>();
        }

        public void AddBook(Book book)
        {
            bookList.Add(book); // dodanie ksiazki do listy
        }      

        public void FindBookTitle(string title)
        {
            bool check = false, cycle = false;
            int i = 1;
            //title.ToLower();
            foreach (Book book in bookList)
            {               
                //book.Title.ToLower();
                if (book.Title == title)
                {
                    check = true;
                    Console.WriteLine($"{i}. {book.Title} - {book.AuthorName} {book.AuthorSurname} ({book.publicationDate})");
                    // <nr_porządkowy>. <tytuł> - <imie_autora> <nazwisko_autora> (<rok wydania> r.)           

                    if (book.CycleTitle != null)
                    {
                        foreach (Book cycleBook in cycleList)
                        {
                            if (cycle == false)
                            {
                                Console.WriteLine($"Inne książki z cyklu {book.CycleTitle}: ");
                                cycle = true;
                            }

                            if (cycleBook.CycleTitle == book.CycleTitle && cycleBook.Title != book.Title)
                            {
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
            foreach (Book book in bookList)
            {
                //book.Title.ToLower();
                if (book.AuthorName == authorName && book.AuthorSurname == authorSurname)
                {
                    Console.WriteLine($"{i}. {book.Title} - {book.AuthorName} {book.AuthorSurname} ({book.publicationDate})");
                    // <nr_porządkowy>. <tytuł> - <imie_autora> <nazwisko_autora> (<rok wydania> r.)
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
            cycleList.Add(book);
        }

       

    }
}
