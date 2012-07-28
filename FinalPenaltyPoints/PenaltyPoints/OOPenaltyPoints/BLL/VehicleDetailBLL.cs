using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OOPenaltyPoints.DAL;
using OOPenaltyPoints.Models;
using System.Web.Mvc;

/// <summary>
/// TO DO Summary description for VehicleDetailBLL
/// </summary>
namespace OOPenaltyPoints.BLL
{
    public class VehicleDetailBLL
    {
        private VehicleDetailDAL _vehicleDetailDAL = null;

        protected VehicleDetailDAL _DAL
        {
            get
            {
                if (_vehicleDetailDAL == null)
                    _vehicleDetailDAL = new VehicleDetailDAL();

                return _vehicleDetailDAL;
            }
        }

        /// <method>
        /// GetVehicles() returns a list of all vehicles in the database
        /// </method>
        public List<VehicleDetail> GetVehicles()
        {
            //Get vehicles from database.
            //Loop through all records. 
            //Store only one instance of the vehicle details
            //return a list of unique vehicle details 

            List<VehicleDetail> _vehiclesDB = new List<VehicleDetail>();
            _vehiclesDB = _DAL.ListOfVehicleDetails();
            List<VehicleDetail> _uniqueVehicles = new List<VehicleDetail>();

            bool vehicleExists = false;
            foreach (VehicleDetail vehicle in _vehiclesDB)
            {
                foreach (VehicleDetail temp in _uniqueVehicles)
                {
                    if (temp.VdRegistration == vehicle.VdRegistration)
                    {
                        vehicleExists = true;
                    }
                }
                if (vehicleExists == false)
                {
                    _uniqueVehicles.Add(vehicle);
                }
                else
                {
                    vehicleExists = false;
                }
            }
            return _uniqueVehicles;
        }


        public List<SelectListItem> GetVehicleRegs()
        {
            //Define a vehicle registration list
            List<SelectListItem> vehicleRegs = new List<SelectListItem>();
            List<VehicleDetail> vehicles = GetVehicles();
            vehicleRegs.Add(new SelectListItem
            {
                Text = "(None)",
                Value = "(None)",
                Selected = true
            });
            //bool selectFirst = true;
            foreach (VehicleDetail vehicle in vehicles)
            {
                //Set the first vehicle as default
                //if (selectFirst)
                //{
                //    vehicleRegs.Add(new SelectListItem
                //    {
                //        Text = vehicle.VdRegistration,
                //        Value = vehicle.VdRegistration,
                //        Selected = true
                //    });
                //    selectFirst = false;
               // }
               // else
               // { 
                    vehicleRegs.Add(new SelectListItem
                    {
                        Text = vehicle.VdRegistration,
                        Value = vehicle.VdRegistration
                    });
               // }
            }
            return vehicleRegs;
        }
    }
}