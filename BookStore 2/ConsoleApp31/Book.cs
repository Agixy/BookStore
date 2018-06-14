using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    internal class Book
    {
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public DateTime PublicationDate { get; set; }
        public string CycleTitle { get; set; }
     
        public Book(string title, string authorName, string authorSurname, DateTime publicationDate, string cycleTitle)
        {
            Title = title;
            AuthorName = authorName;
            AuthorSurname = authorSurname;
            PublicationDate = publicationDate;
            CycleTitle = cycleTitle;            
        }      
    }
}
