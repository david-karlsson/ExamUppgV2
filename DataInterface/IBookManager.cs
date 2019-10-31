using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;



namespace DataInterface
{



    public interface IBookManager
    {

        Book GetBookByNumber(long ISBN);

        public void AddBook(long ISBN);

        public void RemoveBook(long ISBN);
        public void MoveBook(long ISBN, int shelfNr);



    }


}
