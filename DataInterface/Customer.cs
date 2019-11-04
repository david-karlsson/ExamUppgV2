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
       public class Customer
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int CustomerID { get; set; }
        public int CustomerNr { get; set; }

        public string DateOfBirth { get; set; }

        public int AmountOfBooksLoaned { get; set; }

        public int Debts { get; set; }

        public int LoanPeriod { get; set; }

        public int Condition { get; set; }

        public BookOnLoan BookOnLoan { get; set; }
        public ICollection<Book> Book { get; set; }

    }

}
