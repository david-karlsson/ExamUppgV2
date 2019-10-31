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
        
        public void AddCustomer(int customerNr)
        {
            using (var LibraryContext = new LibraryContext())
            { 

            var customer = new Customer();
                customer.CustomerNr = customerNr;
                customer.CustomerNr++;
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

