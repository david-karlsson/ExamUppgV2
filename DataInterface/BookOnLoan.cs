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
    public class BookOnLoan
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int BookOnLoanID { get; set; }

        public int ISBN { get; set; }
        public bool OnLoan { get; set; }

        public int BookID { get; set; }
        
        public Book Book { get; set; }

    }
}
