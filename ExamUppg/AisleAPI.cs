using System;
using System.Collections.Generic;
using System.Text;
using DataInterface;

namespace ExamUppg
{
    public class AisleAPI
    {


        private IAisleManager aisleManager;
        private IBookManager bookManager;
        private IShelfManager shelfManager;

        public AisleAPI(IAisleManager aisleManager, IShelfManager shelfManager)
        {
            this.aisleManager = aisleManager;
            this.shelfManager = shelfManager;

        }

        public AisleAPI(IBookManager bookManager)
            {

            this.bookManager = bookManager;


        }
        
        
        public AisleAPI(IShelfManager shelfManager)
        {
            this.shelfManager = shelfManager;


        }
        public bool AddShelf(int shelfNumber)
        {
            var existingShelf = shelfManager.GetShelfByNumber(shelfNumber);
            if (existingShelf != null)
                return false;
            shelfManager.AddShelf(shelfNumber);
            return true;
        }


        public bool AddBook(int bookNumber)
        {
            var existingBook = bookManager.GetBookByNumber(bookNumber);
            if (existingBook != null)
                return false;
            bookManager.AddBook(bookNumber);
            return true;
        }




        public bool AddAisle(int aisleNumber)
        {
            var existingAisle = aisleManager.GetAisleByNumber(aisleNumber);
            if (existingAisle != null)
                return false;
            aisleManager.AddAisle(aisleNumber);
            return true;
        }



        public RemoveAisleErrorCodes RemoveAisle(int aisleNumber)
        {
            var newAisle = aisleManager.GetAisleByNumber(aisleNumber);

            if (newAisle.Shelf.Count > 0)
                return RemoveAisleErrorCodes.AisleHasShelfs;

            aisleManager.RemoveAisle(newAisle.AisleID);

            return RemoveAisleErrorCodes.OK;
        }



     /*   RemoveAisleErrorCodes ShelfCheckForAisle(int AisleNr, int ShelfNr)
        {

            var aisle = aisleManager.GetAisleByNumber(AisleNr);
            var shelf = shelfManager.GetShelfByNumber(ShelfNr);

            if (shelf.ShelfNr > 0 )
            {
                return RemoveAisleErrorCodes.AisleHasShelfs;
            }


        }*/


    }



}
