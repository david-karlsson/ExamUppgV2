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
    public class BookDiscardList
    {
        public List<BookDiscardList> BookList;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BookDiscardListID { get; set; }

        public int BookDiscardListNr { get; set; }

        public int ListDone { get; set; }
        public long ISBN { get; set; }

        public int Condition { get;set; }

        public int ShelfNr { get; set; }


        public int ShelfID { get; set; }
    
        public Shelf Shelf { get; set; }
        public string Title { get; set; }

        public int Booknr { get; set; }

        public Book Book { get; set; }
        public int BookID { get; set; }
        

        public ICollection<BookOnLoan> BookOnLoan { get; set; }
        public bool OnLoan { get; set; }
        public int AisleNr { get; set; }
    }

}
