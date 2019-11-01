using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using DataInterface;


namespace DataAccess

 
{
    public class ShelfManager : IShelfManager
    {
        public Shelf GetShelfByNumber(int shelfnr)
        {


            using var context = new LibraryContext();
            return (from s in context.Shelf
                    where s.ShelfNr == shelfnr
                    select s)
                    .Include(s => s.Book)
                    .FirstOrDefault();
        }

        public void AddShelf(int shelfNr)
        {
            using (var LibraryContext = new LibraryContext())
            { 

            var shelf = new Shelf();
                LibraryContext.Shelf.Add(shelf);
         
                LibraryContext.SaveChanges();

            }
            

        }



        public void RemoveShelf(int shelfNr)
        {
            using var LibraryContext = new LibraryContext();
            var shelf = (from a in LibraryContext.Shelf
                         where a.ShelfNr == shelfNr
                         select a).FirstOrDefault();
            LibraryContext.Shelf.Remove(shelf);

            LibraryContext.SaveChanges();


        }


        public void MoveShelf(int shelfNr, int aisleNr)
        {
            using var context = new LibraryContext();
            {
                var shelf = (from c in context.Shelf
                             where c.ShelfNr == shelfNr
                             select c)
                            .First();
                shelf.AisleNr = aisleNr;
                
                
                context.SaveChanges();

            }
        
        }

    }
}

