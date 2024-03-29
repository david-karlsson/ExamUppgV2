﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Moq;


namespace DataInterface

{
    public class PartyInvitation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PartyInvitationID { get; set; }
        public int PartyInvitationNr { get; set; }

        public int MinorID { get; set; }

        public Minor Minor { get; set; }
        public string MinorName { get; set; }

        public string MinorAdress { get; set; }

        public string DateOfBirth { get; set; }

        public int AmountOfBooksLoaned { get; set; }

        public int Debts { get; set; }

        public int LoanPeriod { get; set; }

        public int Condition { get; set; }

        public Customer Customer { get; set; }
        public int CustomerID {get;set;}
        public PopularBooks PopularBooks { get; set; }

        public int PopularBooksID { get; set; }
        public int ReminderListID {get;set;}
        public ReminderList ReminderList { get; set; }

        public BookOnLoan BookOnLoan { get; set; }
        public ICollection<Book> Book { get; set; }

    }

}
