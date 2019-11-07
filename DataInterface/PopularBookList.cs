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
    public class PopularBookList
    {



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BookOnLoanID { get; set; }

        public int ISBN { get; set; }
        public int AmountOnLoan { get; set; }

        public int DateOfBirth { get; set; }
       public ICollection<Book>Book { get; set; }
        public ICollection<Customer>Customer { get; set; }
        public int TimesLoaned { get; set; }
        public PopularBook PopularBook { get; set; }
    }
}
