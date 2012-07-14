using System;
using System.Collections.Generic;
using System.Data;     //<-------------  NOTE added to acquire EntityState.Modified in "EditListedOffence"
using System.Linq;
using System.Web;
using OOPenaltyPoints.Models;


namespace OOPenaltyPoints.DAL
{
    public class ListedOffenceDAL
    {
        // System.Diagnostics.Debug.WriteLine("Now in ListedOffenceDal.ListedOffenceFindById");

        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        public ListedOffence ListedOffenceFindById(int id)
        {
            ListedOffence listedoffence = db.ListedOffences.Find(id);
            return (listedoffence);           
        }

       public List<ListedOffence> ListOfListedOffences(){
           return(db.ListedOffences.ToList());
        }

       public ListedOffence CreateListedOffence(ListedOffence listedoffence)
       {
           db.ListedOffences.Add(listedoffence);
           db.SaveChanges();
           return null;
       }

       public ListedOffence DeleteListedOffenceById(int id)
       {
           ListedOffence listedoffence = db.ListedOffences.Find(id);
           db.ListedOffences.Remove(listedoffence);
           db.SaveChanges();

           return null;
       }


       public ListedOffence EditListedOffence(ListedOffence listedoffence)
       {       
           db.Entry(listedoffence).State = EntityState.Modified;
           db.SaveChanges();
           return null;
       }

    }
}