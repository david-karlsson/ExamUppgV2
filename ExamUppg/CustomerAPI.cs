using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataInterface;

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

        public BookReturnStatus BookStatusReturnCheck(int customerNr, long bookISBN)
        {
            var customer = customerManager.GetCustomerByNumber(customerNr);
            var book = bookManager.GetBookByNumber(bookISBN);

            var fee = 50 * (customer.LoanPeriod(-30).Count % 30);


            if (customer.Condition < 2)
                return BookReturnStatus.BookDamagedByCustomer;


            if (customer.LoanPeriod > 30)
                return BookReturnStatus.OverDue;


            if (customer.LoanPeriod > 60) { 
                customer.Debts = fee;
            return BookReturnStatus.OverDueWithFee;
            }


            return BookReturnStatus.OK;


        }








        public BookReturnListStatus ListReminder(int customerNr, long bookISBN)

        {

            var customer = customerManager.GetCustomerByNumber(customerNr);
            var book = bookManager.GetBookByNumber(bookISBN);

            if (customer.Debts > 0)

                return BookReturnListStatus.CustomerHasDebts;
       

            if (customer.LoanPeriod > 30)

                return BookReturnListStatus.BoooksOverDue;


            return BookReturnListStatus.OK;




        }


        private static IEnumerable<ReminderList> ListReminder(int customerNr, ReminderList reminder, List<ReminderList> booksDue)
        {
            return booksDue.Where(t =>
                                reminder.Book
                                    .Any(r => r.BookID == t.CustomerNr)
                                );
        }


        public PopularBookStatus PopularStatus(long bookISBN, int dateOfBirth, int customerNr, int timesLoaned)
        {

            var popularBook = bookManager.GetPopularBook(timesLoaned);
            var customer = customerManager.GetCustomerByNumber(customerNr);
            var book = bookManager.GetBookByNumber(bookISBN);
            var dateInt = customer.DateOfBirth.Parse;



            if (customer.timesLoaned > popularBook.BookOnLoan)


                if (dateInt > 2010)
                    return PopularBookStatus.Ages0o9;


                if (dateInt > 2000 && dateInt < 2010)
                    return PopularBookStatus.Ages10To19;

                if (dateInt > 1990 && dateInt < 2000)
                    return PopularBookStatus.Ages20To29;


                if (dateInt > 1990 && dateInt < 2000)
                    return PopularBookStatus.Ages20To29;


                if (dateInt > 1980 && dateInt < 1990)
                    return PopularBookStatus.Ages30To39;
                 
                if (dateInt > 1970 && dateInt < 1980)
                    return PopularBookStatus.Ages40To49;

                if (dateInt > 1960 && dateInt < 1970)
                    return PopularBookStatus.Ages50To59;

                 if (dateInt > 1950 && dateInt < 1960)
                     return PopularBookStatus.Ages60To69;
                 
                 if (dateInt > 1940 && dateInt < 1950)
                     return PopularBookStatus.Ages70To79;

                 if (dateInt > 1930 && dateInt < 1940)
                     return PopularBookStatus.Ages80To89;


        }


    }
}

