using System;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookContainer = new BookContainer();
            bool exit = false;
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
                        FindBookTitle(bookContainer);                       
                        break;
                    case 'c':
                        FindBookAuthor(bookContainer);
                        break;
                    case 'd':
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Proszę podać prawidłowa literę (a/b/c/d");
                        break;
                }
            } while (!exit);
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
        }

        private static void FindBookTitle(BookContainer bookContainer)
        {
            Console.WriteLine("Podaj szukany tytuł");
            string title = Console.ReadLine();
            int i = 1;
            var foundedBooks = bookContainer.FindBookTitle(title);
            foreach(Book book in foundedBooks)
            {
                Console.WriteLine($"{i}. {book.GetDescription()}");

                if (book.CycleTitle != "")
                {                                    
                        Console.WriteLine($"Inne książki z cyklu {book.CycleTitle}: ");  
                    
                        foreach (Book bookC in bookContainer.FindOthersBookInCycle(book))
                        {                          
                            Console.WriteLine($"\t .{bookC.Title}");
                            Console.WriteLine();
                        }                                                                                
                }
                i++;
            }       
            if(foundedBooks.Count == 0)
            {
                Console.WriteLine("Nie znaleziono ksiazek o takim tytule");
            }

            Console.ReadKey();
        }

        private static void FindBookAuthor(BookContainer bookContainer) 
        {
            Console.WriteLine("Podaj imie autora");
            string authorName = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko autora");
            string authorSurname = Console.ReadLine();

            int i = 1;
            var foundedBooks = bookContainer.FindBookAuthor(authorName, authorSurname);
            foreach (Book book in foundedBooks)
            {
                if (book.CycleTitle != "")
                {
                    Console.WriteLine($"{i}. {book.GetDescription()}");
                    i++;
                }

                if (foundedBooks.Count == 0)
                {
                    Console.WriteLine("Nie znaleziono ksiazek takiego autora");
                }
            }
        }                                                         
    }
}
