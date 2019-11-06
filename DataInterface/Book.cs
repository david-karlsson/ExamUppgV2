using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Moq;


namespace DataInterface
{
    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BookID { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public long ISBN { get; set; }

        public int ShelfNr { get; set; }


        public int ShelfID { get; set; }
    
        public Shelf Shelf { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public BookDiscard BookDiscard { get; set; }
        public int BookDiscardID { get; set; }

        public int Condition { get; set; }
        public ICollection<BookOnLoan> BookOnLoan { get; set; }
        public bool OnLoan { get; set; }
        public int BookDiscardListNr { get; set; }
        public bool ListDone { get; set; }
        public int AisleNr { get; set; }

        public int TimesLoaned { get; set; }
        public PopularBooks PopularBooks { get; set; }

        public int PopularBooksID { get; set; }
    public List<BookDiscardList> BookDiscardList { get; set; }
    }

}
