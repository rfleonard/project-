using System;
using System.Collections.Generic;
using System.Data;     //<-------------  NOTE added to acquire EntityState.Modified in "EditVehicleDetail"
using System.Linq;
using System.Web;
using OOPenaltyPoints.Models;


namespace OOPenaltyPoints.DAL
{
    public class VehicleDetailDAL
    {
        // System.Diagnostics.Debug.WriteLine("Now in VehicleDetailDal.VehicleDetailFindById");

        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        public VehicleDetail VehicleDetailFindById(int id)
        {
            VehicleDetail vehicledetail = db.VehicleDetails.Find(id);
            return (vehicledetail);           
        }

       public List<VehicleDetail> ListOfVehicleDetails(){
           return(db.VehicleDetails.ToList());
        }

       public VehicleDetail CreateVehicleDetail(VehicleDetail vehicledetail)
       {
           db.VehicleDetails.Add(vehicledetail);
           db.SaveChanges();
           //return null;
           return vehicledetail;
       }

       public VehicleDetail DeleteVehicleDetailById(int id)
       {
           VehicleDetail vehicledetail = db.VehicleDetails.Find(id);
           db.VehicleDetails.Remove(vehicledetail);
          db.SaveChanges();

           return null;
       }

       //cc - changed return to int
       //public VehicleDetail EditVehicleDetail(VehicleDetail vehicledetail)
       public int EditVehicleDetail(VehicleDetail vehicledetail)
       {       
           db.Entry(vehicledetail).State = EntityState.Modified;
           db.SaveChanges();
           return vehicledetail.Id;
           //return null;
       }

    }
}