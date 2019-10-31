using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using DataInterface;


namespace DataAccess

 
{
    public class BookManager : IBookManager
    {

        public Book GetBookByNumber(long booknr)
        {


            using var context = new LibraryContext();
            return (from t in context.Book
                    where t.ISBN == booknr
                    select t)
                    .Include(t => t.BookOnLoan)
                    .FirstOrDefault();
        }



        public Book GetBookOnLoan(bool booknr)
        {


            using var context = new LibraryContext();
            return (from b in context.Book
                    where b.OnLoan == booknr
                    select b)
                    .Include(b => b.BookOnLoan)
                    .FirstOrDefault();
        }




        public Book BookOnLoan(long booknr)
        {
            using var context = new LibraryContext();
            return (from t in context.Book
                    where t.ISBN == booknr
                    select t)
                   
                    .FirstOrDefault();

        }




        public void AddBook(long ISBN)
        {
            using (var LibraryContext = new LibraryContext())
            { 


            var book = new Book();

                book.ISBN = ISBN;
                book.ISBN = 9780132911221;
                book.Price = 200;
                LibraryContext.Book.Add(book);
         
                LibraryContext.SaveChanges();

            }
            

        }



        public void RemoveBook(long bookNumber)
        {
            using (var LibraryContext = new LibraryContext())
            {

                var book = (from a in LibraryContext.Book
                            where a.ISBN == bookNumber
                            select a).FirstOrDefault();
                LibraryContext.Book.Remove(book);

                LibraryContext.SaveChanges();


          

            }


        }


        public void MoveBook(long bookNr, int shelfNr)
        {
            
                using var context = new LibraryContext();
                {
                    var book = (from c in context.Book
                                 where c.ISBN == bookNr
                                 select c)
                                .First();
                    book.ShelfNr = shelfNr;


                    context.SaveChanges();

                }


                


        }

    }
}

