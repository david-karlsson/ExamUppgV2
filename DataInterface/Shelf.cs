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
    public class Shelf
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShelfID { get; set; }

        public int ShelfNr { get; set; }
        public int AisleNr { get; set; }

        /*public int BookID { get; set; }

        public Book Book { get; set; }*/

        public ICollection<Book> Book { get; set; }

        public ICollection<Aisle> Aisle { get; set; }

    }

}
