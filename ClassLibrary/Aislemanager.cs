using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using DataInterface;


namespace DataAccess

 
{
    public class AisleManager : IAisleManager
    {


        
                public Aisle GetAisleByNumber(int aislenr)
                {


            using var context = new LibraryContext();
                    return (from a in context.Aisle
                            where a.AisleNr == aislenr
                            select a)
                            .Include(a => a.Shelf)
                            .FirstOrDefault();
                }
        
        public void AddAisle(int aisleNr)
        {
            using (var LibraryContext = new LibraryContext())
            { 

            var aisle = new Aisle();
                aisle.AisleNr = aisleNr;
                LibraryContext.Aisle.Add(aisle);                      
                LibraryContext.SaveChanges();

            }

        }



        public void RemoveAisle(int aisleNr)
        {
            using (var LibraryContext = new LibraryContext())
            {

                var aisle = (from a in LibraryContext.Aisle
                             where a.AisleID == aisleNr
                             select a).FirstOrDefault();
                 LibraryContext.Aisle.Remove(aisle);

                LibraryContext.SaveChanges();

            }

        }


       

    }
}

