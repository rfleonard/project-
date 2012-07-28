using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OOPenaltyPoints.DAL;
using OOPenaltyPoints.Models;
using System.Web.Mvc;

/// <summary>
/// TO DO Summary description for DriverDetailBLL
/// </summary>
namespace OOPenaltyPoints.BLL
{
    public class DriverDetailBLL
    {
        private DriverDetailDAL _driverDetailDAL = null;

        protected DriverDetailDAL _DAL
        {
            get
            {
                if (_driverDetailDAL == null)
                    _driverDetailDAL = new DriverDetailDAL();

                return _driverDetailDAL;
            }
        }

        /// <method>
        /// GetDrivers() returns a list of all drivers in the database
        /// </method>
        public List<DriverDetail> GetDrivers()
        {
            //Get drivers from database.
            //Loop through all records. 
            //Store only one instance of the driver details
            //return a list of unique drivers details

            List<DriverDetail> _driversDB = new List<DriverDetail>();
            _driversDB = _DAL.ListOfDriverDetails();
            List<DriverDetail> _uniqueDrivers = new List<DriverDetail>();

            bool driverExists = false;
            foreach (DriverDetail driver in _driversDB)
            {
                foreach (DriverDetail temp in _uniqueDrivers)
                {
                    if (temp.DdLicenceNo == driver.DdLicenceNo)
                    {
                        driverExists = true;
                    }
                }
                if (driverExists == false)
                {
                    _uniqueDrivers.Add(driver);
                }
                else
                {
                    driverExists = false;
                }
            }
            return _uniqueDrivers;
        }


        public List<SelectListItem> GetDriverLicences()
        {
            //Define a driver licence list
            List<SelectListItem> driverLicences = new List<SelectListItem>();
            List<DriverDetail>  drivers = GetDrivers();

            driverLicences.Add(new SelectListItem
            {
                Text = "(None)",
                Value = "(None)",
                Selected = true
            });
            //bool selectFirst = true;
            foreach (DriverDetail driver in drivers)
            {
                //Set the first driver as default
               // if (selectFirst)
               // {
               //     driverLicences.Add(new SelectListItem
               //     {
               //         Text = driver.DdLicenceNo,
              //          Value = driver.DdLicenceNo,
              //          Selected = true
             //       });
                   // selectFirst = false;
              //  }
              //  else
              //  {
                    driverLicences.Add(new SelectListItem
                    {
                        Text = driver.DdLicenceNo,
                        Value = driver.DdLicenceNo
                    });
             //   }
            }            
            return driverLicences;
        }
    }
}