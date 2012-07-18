using System;
using System.Collections.Generic;
using System.Data;     //<-------------  NOTE added to acquire EntityState.Modified in "EditDriverOffence"
using System.Linq;
using System.Web;
using OOPenaltyPoints.Models;


namespace OOPenaltyPoints.DAL
{
   //private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

    public class DriverOffenceDAL
    {

        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        public DriverOffence DriverOffenceFindById(int id)
        {
            DriverOffence driveroffence = db.DriverOffences.Find(id);
            return (driveroffence);
        }

        public List<DriverOffence> ListOfDriverOffences()
        {
            return (db.DriverOffences.ToList());
        }

        //CC - changed return type for CreateDriverOffence.
        //public DriverOffence CreateDriverOffence(DriverOffence driveroffence)
        public int CreateDriverOffence(DriverOffence driveroffence)
        {
            db.DriverOffences.Add(driveroffence);
            db.SaveChanges();
            return driveroffence.Id;
            //return null;
        }

        public DriverOffence DeleteDriverOffenceById(int id)
        {
            DriverOffence driveroffence = db.DriverOffences.Find(id);
            db.DriverOffences.Remove(driveroffence);
            db.SaveChanges();

            return null;
        }


        public DriverOffence EditDriverOffence(DriverOffence driveroffence)
        {
            db.Entry(driveroffence).State = EntityState.Modified;
            db.SaveChanges();
            return null;
        }


    }
}


