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
        private ICustomerManager customerManager;


        public BookAPI(IBookManager bookManager, IShelfManager shelfManager)
        {
            this.bookManager = bookManager;
            this.shelfManager = shelfManager;

        }

        public BookAPI(ICustomerManager customerManager)
            {

            this.customerManager = customerManager;


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

            if (newBook.Condition < 2)
                return RemoveBookErrorCodes.PoorCondition;
                bookManager.RemoveBook(newBook.BookID);                


            return RemoveBookErrorCodes.OK;
        }


        public MoveBookErrorCodes MoveBook (long bookISBN, bool bookOnLoan)
        {
            var newBook = bookManager.GetBookByNumber(bookISBN);
            var newBookLoan = bookManager.GetBookOnLoan(bookOnLoan);

            if (bookISBN == newBookLoan.ISBN)
                return MoveBookErrorCodes.BookIsOnLoan;

            else
                return MoveBookErrorCodes.OK;


        }


     


        public DiscardBookListStatus RemoveBookList(bool bookDiscardListNr)
        {
            var bookDiscard = bookManager.GetBookDiscardList(bookDiscardListNr);


            if (bookDiscard.ListDone == false )
                return DiscardBookListStatus.ListIsNotDone;


            if (bookDiscard.ListDone == true)
                return DiscardBookListStatus.ListIsDone;
                bookManager.RemoveBook(bookDiscard.ISBN);




        }


        public PopularBookStatus PopularStatus(int bookISBN, int dateOfBirth, int customerNr)
        {

            var newBook = bookManager.GetBookByNumber(bookISBN);
            var customer = customerManager.GetCustomerByNumber(customerNr);

          
     



        }


    }



}
