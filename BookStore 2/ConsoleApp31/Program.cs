using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookContainer = new BookContainer();

            do
            {
                Console.WriteLine("Prosze wybrac opcje");         //Display Menu
                Console.WriteLine("a - Dodaj książkę");
                Console.WriteLine("b - Znajdź książki po tytule");
                Console.WriteLine("c - Znajdź książki po imieniu i nazwisku autora");
              
                var option = Console.ReadKey().KeyChar; // Musi byc KeyChar bo jest char a nie string dalej.

                switch (option)
                {
                    case 'a':                       
                        AddNewBook(bookContainer);
                        break;
                    case 'b':
                        Console.WriteLine("Podaj szukany tytuł");
                        string title = Console.ReadLine();
                        bookContainer.FindBookTitle(title);                       
                        break;
                    case 'c':
                        Console.WriteLine("Podaj imie autora");
                        string authorName = Console.ReadLine();
                        Console.WriteLine("Podaj nazwisko autora");
                        string authorSurname = Console.ReadLine();
                        bookContainer.FindBookAuthor(authorName, authorSurname);
                        break;
                }
            } while (true);
        }
        
        private static void AddNewBook(BookContainer bookContainer)
        {          
            Console.WriteLine("Dodajesz książkę:");
            // pobrac dane ktore potrzeba do stworzenia zdefiniowania ksiazki i potem dane przekazac do listy
            // wartosci jak argument metody Create
            Console.WriteLine("Prosze podac tytuł książki");
            string title = Console.ReadLine();


            Console.WriteLine("Proszę podać imie autora");
            string authorName = Console.ReadLine();
     
            Console.WriteLine("Proszę podać nazwisko autora");
            string authorSurame = Console.ReadLine();


            


            Console.WriteLine("Proszę podac rok wydania książki");
            try
            {
                int year = int.Parse(Console.ReadLine()); }

            catch (FormatException)
            {
                Console.WriteLine("Proszę podac liczbę");
            }

            //DateTime publication = new DateTime(year, 0, 0, 0, 0, 0);
            //book.PublicationDate = publication;
            // czy lepiej zrobić datą tak jak u góry?


            Console.WriteLine("Proszę podać tytuł cyklu. Jeśli książka nie należy do cyklu nacisnąć Enter");
            string cycleTitle = Console.ReadLine();           

            var book = new Book(title, authorName, authorSurame, year, cycleTitle);     // tutaj nie widzi zmiennej year

            bookContainer.AddBook(book);

            if (cycleTitle != null)
            {
                bookContainer.AddCycle(book);
            }
                                          
        }       
    }
}
