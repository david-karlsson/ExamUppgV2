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

        public BookLoanStatus AmountStatus(int customerNr, int customerLoans, bool bookOnLoan )
        {
            var newCustomer = customerManager.GetCustomerByNumber(customerNr);
            var newLoans = customerManager.GetBooksLoanedByCustomer(customerLoans);
            var BookLoan = bookManager.GetBookOnLoan(bookOnLoan);


            if (newLoans.BookOnLoan.Count > 5)
                return BookLoanStatus.TooMany;

            if (newCustomer.Book == newLoans.Book)
                return BookLoanStatus.ExtendPeriod;

            if (BookLoan.OnLoan == true)
                return BookLoanStatus.BookIsOnLoan;

            else
                return BookLoanStatus.OK;


        }

    }


}

