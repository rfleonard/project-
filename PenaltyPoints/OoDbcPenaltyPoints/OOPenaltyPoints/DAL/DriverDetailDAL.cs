using System;
using System.Collections.Generic;
using System.Data;     //<-------------  NOTE added to acquire EntityState.Modified in "EditDriverDetail"
using System.Linq;
using System.Web;
using OOPenaltyPoints.Models;


namespace OOPenaltyPoints.DAL
{
    public class DriverDetailDAL
    {
        // System.Diagnostics.Debug.WriteLine("Now in DriverDetailDal.DriverDetailFindById");

        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        public DriverDetail DriverDetailFindById(int id)
        {
            DriverDetail driverdetail = db.DriverDetails.Find(id);
            return (driverdetail);           
        }

       public List<DriverDetail> ListOfDriverDetails(){
           return(db.DriverDetails.ToList());
        }

       public DriverDetail CreateDriverDetail(DriverDetail driverdetail)
       {
           db.DriverDetails.Add(driverdetail);
           db.SaveChanges();
           return null;
       }

       public DriverDetail DeleteDriverDetailById(int id)
       {
           DriverDetail driverdetail = db.DriverDetails.Find(id);
           db.DriverDetails.Remove(driverdetail);
           db.SaveChanges();

           return null;
       }


       public DriverDetail EditDriverDetail(DriverDetail driverdetail)
       {       
           db.Entry(driverdetail).State = EntityState.Modified;
           db.SaveChanges();
           return null;
       }

    }
}