using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OOPenaltyPoints.Models;

namespace OOPenaltyPoints.DAL
{
    public class ListedOffenceDAL
    {
        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        public ListedOffence ListedOffenceFindById(int id)
        {
           // System.Diagnostics.Debug.WriteLine("Now in ListedOffenceDal.ListedOffenceFindById");
            ListedOffence listedoffence = db.ListedOffences.Find(id);
            return (listedoffence);
            
        }

    }
}