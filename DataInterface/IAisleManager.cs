using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;



namespace DataInterface
{



    public interface IAisleManager
    {

       Aisle GetAisleByNumber(int AisleNr);

        public void AddAisle(int AisleNr);

        public void RemoveAisle(int AisleNr);

    }


}
