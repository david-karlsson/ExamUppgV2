using System;
using System.Collections.Generic;
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


        public AddCustomerErrorCodes AddCustomer(string dateOfBirth, int customerNumber) {



             var customerNr = customerManager.GetCustomerByNumber(customerNumber);

            DateTime customerDate;


            string dateOfBirth = customer.DateOfBirth;
            try
            {
                customerDate = DateTime.Parse(dateOfBirth);

            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrext Dateformat", customerDate);
            }

            if (customerManager == false)


                    return AddCustomerErrorCodes.IncorrectDateFormat;


                else

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

        public BookLoanStatus BookStatusLoan(int customerNr, int customerLoans, bool bookOnLoan )
        {
            var customer = customerManager.GetCustomerByNumber(customerNr);
            var loans = customerManager.GetBooksLoanedByCustomer(customerLoans);
            var BookLoan = bookManager.GetBookOnLoan(bookOnLoan);


            if (loans.BookOnLoan.Count > 5)
                return BookLoanStatus.TooMany;

            if (customer.Book == loans.Book)
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


            else
                return BookReturnStatus.OK;


        }



    }


}

