using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;



namespace DataInterface
{



    public interface IShelfManager
    {
        Shelf GetShelfByNumber(int shelfNr);


        public void AddShelf(int shelfNr);

        public void RemoveShelf(int shelfNr);
        public void MoveShelf(int shelfNr, int aisleNr);


    }


}
