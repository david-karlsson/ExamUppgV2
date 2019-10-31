using System;
using System.Collections.Generic;
using System.Text;
using DataInterface;

namespace ExamUppg
{
    public class CustomerAPI
    {
        private ICustomerManager customerManager;

        public CustomerAPI(ICustomerManager customerManager)
        {

            this.customerManager = customerManager;


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



    }


}

