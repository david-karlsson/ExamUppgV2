using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using DataInterface;


namespace DataAccess

 
{
    public class CustomerManager : ICustomerManager
    {


        
                public Customer GetCustomerByNumber(int customerNr)
                {


            using var context = new LibraryContext();
                    return (from c in context.Customer
                            where c.CustomerNr == customerNr
                            select c)
                           // .Include(c => c.Shelf)
                            .FirstOrDefault();
                }



        public Customer GetBooksLoanedByCustomer(int booksLoaned)

        {


            using var context = new LibraryContext();
            return (from c in context.Customer
                    where c.AmountOfBooksLoaned == booksLoaned
                    select c)
                    .Include(c => c.BookOnLoan)
                    .FirstOrDefault();
        }



        public Customer GetPopularBooksList(int ISBN)

        {


            using var context = new LibraryContext();
            return (from c in context.Customer
                    where c.AmountOfBooksLoaned == booksLoaned
                    select c)
                    .Include(c => c.BookOnLoan)
                    .FirstOrDefault();
        }




        public Customer ReminderList(int customerNr)

        {

            using var context = new LibraryContext();
            return (from c in context.Customer
                    where c.CustomerNr == customerNr
                    select c)
                    
                    .Include(c => c.CustomerName)
                    .Include(c => c.CustomerAdress)
                    .Include(c => c.LoanPeriod)
                    .Include(c => c.Condition)
                    .Include(c => c.BookOnLoan)
                    .FirstOrDefault();
        }



        public void AddCustomer(int customerNr)
        {
            using (var LibraryContext = new LibraryContext())
            { 

            var customer = new Customer();
                customer.CustomerNr = customerNr;
                LibraryContext.Customer.Add(customer);                      
                LibraryContext.SaveChanges();

            }

        }



        public void RemoveCustomer(int customerNr)
        {
            using (var LibraryContext = new LibraryContext())
            {

                var customer = (from a in LibraryContext.Customer
                             where a.CustomerNr == customerNr
                             select a).FirstOrDefault();
                 LibraryContext.Customer.Remove(customer);

                LibraryContext.SaveChanges();

            }

        }


        public void MoveCustomer(int customerNr)
        {
            using (var LibraryContext = new LibraryContext())
            {

                var customer = new Customer();
             

                LibraryContext.SaveChanges();

            }

        }




    }
}

