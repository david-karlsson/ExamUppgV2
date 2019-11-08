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
    public class Minor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int MinorID { get; set; }
        public int MinorNr { get; set; }

        public string MinorName { get; set; }

        public string MinorAdress { get; set; }

        public string DateOfBirth { get; set; }

        public int AmountOfBooksLoaned { get; set; }

        public int Debts { get; set; }

        public int LoanPeriod { get; set; }

        public int Condition { get; set; }
        public bool Guardian { get; set; }
        public Customer Customer { get; set; }
        public int CustomerID {get;set;}
        public PopularBook PopularBook { get; set; }

        public int PopularBooksID { get; set; }
        public int ReminderListID {get;set;}
        public ReminderList ReminderList { get; set; }

        public BookOnLoan BookOnLoan { get; set; }
        public ICollection<Book> Book { get; set; }

    }

}
