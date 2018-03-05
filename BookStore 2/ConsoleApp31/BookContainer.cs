using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class BookContainer
    {
        public List<Book> BookList { get; }
        
        public BookContainer()
        {
            BookList = new List<Book>();        
        }

        public void AddBook(Book book)
        {
            BookList.Add(book);
        }      

        public List<Book> FindBookTitle(string title)    
        {
            List<Book> result = new List<Book>();          

            foreach (Book book in BookList)
            {               
                if (book.Title == title)
                {
                    result.Add(book);
                }             
            }

            return result;         
        }

        public List<Book> FindBookAuthor(string authorName, string authorSurname)
        {
            List<Book> result = new List<Book>();
            
            foreach (Book book in BookList)
            {
                bool authorNameMatch = string.Equals(book.AuthorName, authorName, StringComparison.CurrentCultureIgnoreCase);
                bool authorSurnameMatch = string.Equals(book.AuthorSurname, authorSurname, StringComparison.CurrentCultureIgnoreCase);

                if (authorNameMatch && authorSurnameMatch)
                {
                    result.Add(book);
                }     
            }
            return result;
        }

        public List<Book> FindOthersBookInCycle(Book baseBook)
        {     
            List<Book> result = new List<Book>();

            foreach (Book book in BookList)
            {
                if (book.CycleTitle == baseBook.CycleTitle && book.Title != baseBook.Title)
                {
                    result.Add(book);
                }
            }
            return result;
        }      
    }
}
