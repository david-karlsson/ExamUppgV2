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




        public BookAPI(IBookManager bookManager)
        {
            this.bookManager = bookManager;


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


     





        public bool TryValidate(string isbn, long bookISBN)
        {

            isbn = bookManager.GetBookByNumber(bookISBN).ToString();


            bool result = false;

            if (!string.IsNullOrEmpty(isbn))
            {
                if (isbn.Contains("-")) isbn = isbn.Replace("-", "");

                switch (isbn.Length)
                {
                    case 13: result = IsValidIsbn13(isbn,bookISBN);
                        break;

                }
            }

            return result;
        }


        private bool IsValidIsbn13(string isbn13, long bookISBN)
        {

            isbn13 = bookManager.GetBookByNumber(bookISBN).ToString();



            bool result = false;

            if (!string.IsNullOrEmpty(isbn13))
            {
                if (isbn13.Contains("-")) isbn13 = isbn13.Replace("-", "");

                // If the length is not 13 or if it contains any non numeric chars, return false
                long temp;
                if (isbn13.Length != 13 || !long.TryParse(isbn13, out temp)) return false;

                
                int sum = 0;
                for (int i = 0; i < 12; i++)
                {
                    sum += int.Parse(isbn13[i].ToString()) * (i % 2 == 1 ? 3 : 1);
                }

                int remainder = sum % 10;
                int checkDigit = 10 - remainder;
                if (checkDigit == 10) checkDigit = 0;

                result = (checkDigit == int.Parse(isbn13[12].ToString()));
            }

            return result;
        }
    }



}




