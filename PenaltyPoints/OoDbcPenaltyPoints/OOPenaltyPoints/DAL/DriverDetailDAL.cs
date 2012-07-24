<<<<<<< HEAD
﻿using System;
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

       //CC - changed CreateDriverDetail to retrun driverdetail object
       public DriverDetail CreateDriverDetail(DriverDetail driverdetail)
       {
           db.DriverDetails.Add(driverdetail);
           db.SaveChanges();
           //return null;
           return driverdetail;
       }

       public DriverDetail DeleteDriverDetailById(int id)
       {
           DriverDetail driverdetail = db.DriverDetails.Find(id);
           db.DriverDetails.Remove(driverdetail);
           db.SaveChanges();

           return null;
       }

       //cc - changed return to int
       //public DriverDetail EditDriverDetail(DriverDetail driverdetail)
        public int EditDriverDetail(DriverDetail driverdetail)
       {       
           db.Entry(driverdetail).State = EntityState.Modified;
           db.SaveChanges();
           //return null;
           return driverdetail.Id;
       }

    }
=======
﻿using System;
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

       //CC - changed CreateDriverDetail to retrun driverdetail object
       public DriverDetail CreateDriverDetail(DriverDetail driverdetail)
       {
           db.DriverDetails.Add(driverdetail);
           db.SaveChanges();
           //return null;
           return driverdetail;
       }

       public DriverDetail DeleteDriverDetailById(int id)
       {
           DriverDetail driverdetail = db.DriverDetails.Find(id);
           db.DriverDetails.Remove(driverdetail);
           db.SaveChanges();

           return null;
       }

       //cc - changed return to int
       //public DriverDetail EditDriverDetail(DriverDetail driverdetail)
        public int EditDriverDetail(DriverDetail driverdetail)
       {       
           db.Entry(driverdetail).State = EntityState.Modified;
           db.SaveChanges();
           //return null;
           return driverdetail.Id;
       }

    }
>>>>>>> Added Unit Test & soa
}