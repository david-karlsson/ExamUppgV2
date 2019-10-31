using System;
using System.Collections.Generic;
using System.Text;
using DataInterface;

namespace ExamUppg
{
    public class BookAPI
    {


        private IBookManager bookManager;
        private IShelfManager shelfManager;

        public BookAPI(IBookManager bookManager, IShelfManager shelfManager)
        {
            this.bookManager = bookManager;
            this.shelfManager = shelfManager;

        }

        public BookAPI(IBookManager bookManager)
            {

            this.bookManager = bookManager;


        }
        
        
      
        public bool AddBook(long bookISBN)
        {
            var existingBook = bookManager.GetBookByNumber(bookISBN);

            if (existingBook != null)
                return false;
            bookManager.AddBook(bookISBN);
            return true;
        }



        public RemoveBookErrorCodes RemoveBook(long bookISBN)
        {
            var newBook = bookManager.GetBookByNumber(bookISBN);


            if (newBook.BookOnLoan.Count > 0)
                return RemoveBookErrorCodes.BookIsOnLoan;

            bookManager.RemoveBook(newBook.BookID);

            return RemoveBookErrorCodes.OK;
        }


        public MoveBookErrorCodes MoveBook (long bookISBN, long bookOnLoan)
        {
            var newBook = bookManager.GetBookByNumber(bookISBN);
            var newBookLoan = bookManager.BookOnLoan(bookOnLoan);

            if (bookISBN == newBookLoan.ISBN)
                return MoveBookErrorCodes.BookIsOnLoan;

            else
                return MoveBookErrorCodes.OK;


        }


    }



}
