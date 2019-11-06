using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;



namespace DataInterface
{



    public interface ICustomerManager
    {

       Customer GetCustomerByNumber(int CustomerNr);

        Customer GetBooksLoanedByCustomer(int AmountOfBooksLoaned);

        ReminderList ReminderList(int CustomerNr);

        
        public void AddCustomer(int CustomerNr);

        public void RemoveCustomer(int CustomerNr);
        public void MoveCustomer(int CustomerNr);

    }


}
