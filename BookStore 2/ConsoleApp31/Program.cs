using System;
using JetBrains.Annotations;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookContainer = new BookContainer();
            char exit = 'e';
            do
            {
                Console.WriteLine("Prosze wybrac opcje");     
                Console.WriteLine("a - Dodaj książkę");
                Console.WriteLine("b - Znajdź książki po tytule");
                Console.WriteLine("c - Znajdź książki po imieniu i nazwisku autora");
                Console.WriteLine("d - Wyjście z programu");

               

                var option = Console.ReadKey().KeyChar; 

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
                    case 'd':
                        exit = 'd';
                        break;
                    default:
                        Console.WriteLine("Proszę podać prawidłowa literę (a/b/c/d");
                        break;
                }
            } while (exit != 'd');
        }
        
        private static void AddNewBook(BookContainer bookContainer)
        {          
            Console.WriteLine("Dodajesz książkę:");
            
            Console.WriteLine("Prosze podac tytuł książki");
            string title = Console.ReadLine();

            Console.WriteLine("Proszę podać imie autora");
            string authorName = Console.ReadLine();
     
            Console.WriteLine("Proszę podać nazwisko autora");
            string authorSurame = Console.ReadLine();           
            
            bool check, range;
            Console.WriteLine("Proszę podac rok wydania książki");
            int year = -1;
            do
            {
                check = true;
                range = true;
                try
                {
                    // ReSharper disable once AssignNullToNotNullAttribute
                    year = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Proszę podac liczbę");
                    check = false;
                }
                if (year < 0 || year > 2018)
                {
                    Console.WriteLine("Możliwy zakres: 0 - 2018");
                    range = false;
                }

            } while (check == false || range == false);
            DateTime publicationDate = new DateTime(year, 1, 1, 1, 1, 1);

            
            Console.WriteLine("Proszę podać tytuł cyklu. Jeśli książka nie należy do cyklu nacisnąć Enter");  
            string cycleTitle = Console.ReadLine();           

            var book = new Book(title, authorName, authorSurame, publicationDate, cycleTitle);

            bookContainer.AddBook(book);

            if (cycleTitle != "")            
            {
                bookContainer.AddCycle(book);
            }
                                                    
        }       
    }
}
