using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    class Book
    {

        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        private int _publicationDate { get; set; }
        public string CycleTitle { get; set; }

        public int publicationDate
        {
            get
            {
                return _publicationDate;
            }
            set
            {                                
                    if(_publicationDate > 2018 || _publicationDate < 0)
                {
                    Console.WriteLine("Wprowadź rok z naszej ery wcześniejszy niż obecny");
                }
                    else
                {
                    _publicationDate = value;
                }                
            }
        }
     
        public Book(string title, string authorName, string authorSurname, int publicationDate, string cycleTitle)
        {
            Title = title;
            AuthorName = authorName;
            AuthorSurname = authorSurname;
            _publicationDate = publicationDate;
            CycleTitle = cycleTitle;
            
        }      
    }
}
