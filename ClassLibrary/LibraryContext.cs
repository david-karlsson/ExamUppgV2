using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataInterface;


namespace DataAccess
{

    public class LibraryContext : DbContext
    {
        private const string connectionString = "Server=LAPTOP-46CRI5GH;Database=ExaminationsUppgiftsDatabas;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(connectionString);

        }
        public DbSet<Aisle> Aisle { get; set; }

        public DbSet<Shelf> Shelf { get; set; }

        public DbSet<Book> Book { get; set; }

        public DbSet<BookOnLoan> BookOnLoans { get; set; }

        public DbSet<Customer> Customer { get; set; }

        //public DbSet<StudentandCourseKeys> StudentandCourseKeys { get; set; }




    }
}
