using System;
using System.Collections.Generic;
using System.Text;
using DataInterface;

namespace ExamUppg
{
    public class ShelfAPI
    {


        private IAisleManager aisleManager;
        private IBookManager bookManager;
        private IShelfManager shelfManager;
        private IAisleManager object1;
        private IShelfManager object2;

        public ShelfAPI(IShelfManager shelfManager, IBookManager bookManager)
        {
            this.shelfManager = shelfManager;
            this.bookManager = bookManager;

        }

        public ShelfAPI(IBookManager bookManager)
            {

            this.bookManager = bookManager;


        }

        public ShelfAPI(IAisleManager object1, IShelfManager object2)
        {
            this.object1 = object1;
            this.object2 = object2;
        }

        public bool AddShelf(int shelfNumber)
        {
            var existingShelf = shelfManager.GetShelfByNumber(shelfNumber);
            if (existingShelf != null)
                return false;
            shelfManager.AddShelf(shelfNumber);
            return true;
        }


       
        public RemoveShelfErrorCodes RemoveShelf(int shelfNumber)
        {
            var newShelf = shelfManager.GetShelfByNumber(shelfNumber);

            if (newShelf.Book.Count > 0)
                return RemoveShelfErrorCodes.ShelfHasBooks;

            shelfManager.RemoveShelf(newShelf.ShelfID);

            return RemoveShelfErrorCodes.OK;
        }


        public ChangeShelfStatus ChangeShelf(int shelfNumber, int aisleNumber)
        {
            var shelf = shelfManager.GetShelfByNumber(shelfNumber);
            var aisle = aisleManager.GetAisleByNumber(aisleNumber);


            
            
            if(shelf != null)
           
                return ChangeShelfStatus.ChangeShelfNumber;



            if (shelf.Aisle.AisleNr != aisleNumber)
                shelfmanager.MoveShelf(shelf.ShelfNr, aisle.AisleNr);

                return ChangeShelfStatus.MoveShelf;


        }





    }







}
