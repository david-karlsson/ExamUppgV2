using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataInterface;
using DocumentFormat.OpenXml.Drawing;

namespace ExamUppg
{
    public class CustomerAPI
    {
        private ICustomerManager customerManager;
        private IBookManager bookManager;

        public CustomerAPI(ICustomerManager customerManager)
        {

            this.customerManager = customerManager;

        }
        public CustomerAPI(IBookManager bookManager)
        {

            this.bookManager = bookManager;

        }


        public AddCustomerErrorCodes AddCustomer(string dateOfBirth, int customerNumber)
        {



            var customerNr = customerManager.GetCustomerByNumber(customerNumber);

            DateTime customerDate;

            try
            {

                customerDate = DateTime.Parse(dateOfBirth);

            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrext Dateformat", customerDate);
                return AddCustomerErrorCodes.IncorrectDateFormat;

            }

            return AddCustomerErrorCodes.OK;
        }

        //DateTime dateOnly = DateOfBirth->Date;



        public RemoveCustomerErrorCodes RemoveCustomer(int customerNumber)
        {
            var newCustomer = customerManager.GetCustomerByNumber(customerNumber);


            if (newCustomer.Debts > 0)
                return RemoveCustomerErrorCodes.CustomerHasDebts;


            if (newCustomer.Book.Count > 0)
                return RemoveCustomerErrorCodes.CustomerHasBooks;


            customerManager.RemoveCustomer(newCustomer.CustomerNr);

            return RemoveCustomerErrorCodes.OK;
        }

        public BookLoanStatus BookStatusLoan(int customerNr, int customerLoans, bool bookOnLoan)
        {
            var customer = customerManager.GetCustomerByNumber(customerNr);
            var loans = customerManager.GetBooksLoanedByCustomer(customerLoans);
            var BookLoan = bookManager.GetBookOnLoan(bookOnLoan);


            if (loans.BookOnLoan.Count > 5)
                return BookLoanStatus.TooMany;

            if (customer.Book == loans)
                return BookLoanStatus.ExtendPeriod;

            if (BookLoan.OnLoan == true)
                return BookLoanStatus.BookIsOnLoan;



            else
                return BookLoanStatus.OK;


        }

        public BookReturnStatus BookStatusReturn(int customerNr, long bookISBN)
        {
            var customer = customerManager.GetCustomerByNumber(customerNr);
            var book = bookManager.GetBookByNumber(bookISBN);



            if (customer.Condition < 2)
                return BookReturnStatus.BookDamagedByCustomer;


            if (customer.LoanPeriod > 30)
                return BookReturnStatus.OverDue;


            if (customer.LoanPeriod > 60)

                return BookReturnStatus.OverDueWithFee;


            else
                return BookReturnStatus.OK;


        }








        public ReminderList ListReminder(int customerNr, long bookISBN)

        {

            var customer = customerManager.GetCustomerByNumber(customerNr);
            var book = bookManager.GetBookByNumber(bookISBN);






        }


        private static IEnumerable<ReminderList> ListReminder(int customerNr, ReminderList reminder, List<ReminderList> booksDue)
        {
            return booksDue.Where(t =>
                                reminder.Book
                                    .Any(r => r.BookID == t.CustomerNr)
                                && t.Chairs.Count >= numberOfSeats);
        }


    }
}

