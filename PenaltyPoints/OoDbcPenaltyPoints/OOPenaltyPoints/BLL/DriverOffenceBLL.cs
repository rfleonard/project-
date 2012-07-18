using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OOPenaltyPoints.DAL;
using OOPenaltyPoints.Models;
using OOPenaltyPoints.Models.ViewModel;

namespace OOPenaltyPoints.BLL
{
    /// <summary>
    /// TO DO Summary description for DriverOffenceBLL
    /// </summary>
    public class DriverOffenceBLL
    {
        private DriverOffenceDAL _driverOffenceDAL = null;

        protected DriverOffenceDAL _DAL
        {
            get
            {
                if (_driverOffenceDAL == null)
                    _driverOffenceDAL = new DriverOffenceDAL();

                return _driverOffenceDAL;
            }
        }
        /// <method>
        /// GetOffences() returns a list of all active driver offences types in the database
        /// </method>
        public List<GetDriverOffenceUI> GetOffences()
        {
            //Get driver offences from database
            //Iterate through the list 
            //For all offences with status=delete add to _activeOffences
            //return _activeOffences

            List<DriverOffence> _offencesDB = _DAL.ListOfDriverOffences();
            List<GetDriverOffenceUI> _activeOffences = new List<GetDriverOffenceUI>();
            GetDriverOffenceUI _offenceUI = new GetDriverOffenceUI();

            foreach (DriverOffence driverOffence in _offencesDB)
            {
                if (driverOffence.doStatus != "Deleted")
                {
                    //driver offence info.
                    _offenceUI.id = driverOffence.Id;
                    _offenceUI.status = driverOffence.doStatus.ToString();
                    _offenceUI.location = driverOffence.doLocation.ToString();
                    _offenceUI.offenceDate = driverOffence.doOffenceDate;

                    //offence details
                    _offenceUI.description = driverOffence.ListedOffence.LoDesc.ToString();
                   
                    //driver details info.
                    _offenceUI.LicenceNo = driverOffence.DriverDetail.DdLicenceNo.ToString();
                    _offenceUI.FName = driverOffence.DriverDetail.DdFName.ToString();
                    _offenceUI.SName = driverOffence.DriverDetail.DdSName.ToString();
                    _offenceUI.LicenceStatus = driverOffence.DriverDetail.DdLicenceStatus.ToString();
                    
                    //vehicle details
                    _offenceUI.Registration = driverOffence.VehicleDetails.VdRegistration.ToString();
                    
                    _activeOffences.Add(_offenceUI);
                }      
            }
            return _activeOffences;
        }

        /// <method>
        /// Insert offenceUI object into database
        /// </method>
        public void CreateOffence(DriverOffenceUI driverOffenceUI)
        {
            // declare a new driver offence object.
            // if driver does not exist declare a new driver.
            // if vehicle does not exists declare a new vehicle.
            // if driver exists, use existing driver object
            // if vehicle exists, use existing vehicle object
            // retrieve existing offence object from list of offences
            // update driver offence object
            // insert the new driver offence object into the database.


            DriverOffence _driverOffenceDB = new DriverOffence();

            //assign driver offence information to new driver offence
            _driverOffenceDB.doStatus = driverOffenceUI.status.ToString();
            _driverOffenceDB.doLocation = driverOffenceUI.location.ToString();
            _driverOffenceDB.doGardaId= driverOffenceUI.gardaId.ToString();
            _driverOffenceDB.doOffenceDate = driverOffenceUI.offenceDate ;



            //Check to see if driver exists in database
            DriverDetailDAL driverDAL = new DriverDetailDAL();
            List<DriverDetail> driversDB = driverDAL.ListOfDriverDetails();

            int driverExists = 0;
            foreach (DriverDetail driver in driversDB)
            {
                if (driver.DdLicenceNo == driverOffenceUI.LicenceNo)         
                    driverExists = driver.Id;
            }

            //If driver does not exist declare a new driver object
            if (driverExists == 0)
            {
                _driverOffenceDB.DriverDetail = new DriverDetail();
                //update driver attributes
                _driverOffenceDB.DriverDetail.DdLicenceNo = driverOffenceUI.LicenceNo.ToString();
                _driverOffenceDB.DriverDetail.DdFName = driverOffenceUI.FName.ToString();
                _driverOffenceDB.DriverDetail.DdSName = driverOffenceUI.SName.ToString();
                _driverOffenceDB.DriverDetail.DdAddress1 = driverOffenceUI.Address1.ToString();
                _driverOffenceDB.DriverDetail.DdAddress2 = driverOffenceUI.Address2.ToString();
                _driverOffenceDB.DriverDetail.DdAddress3 = driverOffenceUI.Address3.ToString();
                _driverOffenceDB.DriverDetail.DdLicenceStatus = driverOffenceUI.LicenceStatus.ToString();
                //_driverOffenceDB.DriverDetail = driverDAL.CreateDriverDetail(_driverOffenceDB.DriverDetail);
            }

            

            //Check to see if vehicle exists in database
            VehicleDetailDAL vehicleDAL = new VehicleDetailDAL();
            List<VehicleDetail> vehiclesDB = vehicleDAL.ListOfVehicleDetails();

            int vehicleExists = 0;
            foreach (VehicleDetail vehicle in vehiclesDB)
            {
                if (vehicle.VdRegistration == driverOffenceUI.Registration)
                    vehicleExists = vehicle.Id;
            }

            //If vehicle does not exist declare a new driver object
            if (vehicleExists == 0)
            {
                _driverOffenceDB.VehicleDetails = new VehicleDetail();
                //update vechile attributes
                _driverOffenceDB.VehicleDetails.VdRegistration = driverOffenceUI.Registration.ToString();
                _driverOffenceDB.VehicleDetails.VdMake = driverOffenceUI.Make.ToString();
                _driverOffenceDB.VehicleDetails.VdType = driverOffenceUI.Type.ToString();
                _driverOffenceDB.VehicleDetails.VdCubicCapacity = driverOffenceUI.Capacity;
                //_driverOffenceDB.VehicleDetails = vehicleDAL.CreateVehicleDetail(_driverOffenceDB.VehicleDetails);
            }

            //Create a new driver offence
            int driverOffenceID = _DAL.CreateDriverOffence(_driverOffenceDB);
            _driverOffenceDB = _DAL.DriverOffenceFindById(driverOffenceID);

            //if driver existed assign driver details to the new driver offence object;
            if (driverExists > 0)
            {
                _driverOffenceDB.DriverDetail = driverDAL.DriverDetailFindById(driverExists);
                //update driver attributes
                _driverOffenceDB.DriverDetail.DdLicenceNo = driverOffenceUI.LicenceNo.ToString();
                _driverOffenceDB.DriverDetail.DdFName = driverOffenceUI.FName.ToString();
                _driverOffenceDB.DriverDetail.DdSName = driverOffenceUI.SName.ToString();
                _driverOffenceDB.DriverDetail.DdAddress1 = driverOffenceUI.Address1.ToString();
                _driverOffenceDB.DriverDetail.DdAddress2 = driverOffenceUI.Address2.ToString();
                _driverOffenceDB.DriverDetail.DdAddress3 = driverOffenceUI.Address3.ToString();
                _driverOffenceDB.DriverDetail.DdLicenceStatus = driverOffenceUI.LicenceStatus.ToString();
                _driverOffenceDB.DriverDetail = driverDAL.DriverDetailFindById(driverDAL.EditDriverDetail(_driverOffenceDB.DriverDetail));
            }

            //if vehicle existed assign driver details to the driver offence object;
            if (vehicleExists > 0)
            {
                _driverOffenceDB.VehicleDetails = vehicleDAL.VehicleDetailFindById(vehicleExists);
                //update vechile attributes
                _driverOffenceDB.VehicleDetails.VdRegistration = driverOffenceUI.Registration.ToString();
                _driverOffenceDB.VehicleDetails.VdMake = driverOffenceUI.Make.ToString();
                _driverOffenceDB.VehicleDetails.VdType = driverOffenceUI.Type.ToString();
                _driverOffenceDB.VehicleDetails.VdCubicCapacity = driverOffenceUI.Capacity;
                _driverOffenceDB.VehicleDetails = vehicleDAL.VehicleDetailFindById( vehicleDAL.EditVehicleDetail(_driverOffenceDB.VehicleDetails));
            }


            //assign offence details to the new driver offence object
            ListedOffenceDAL offenceDAL = new ListedOffenceDAL();
            List<ListedOffence> offencesDB = offenceDAL.ListOfListedOffences();

            foreach (ListedOffence offence in offencesDB)
            {
                if (offence.LoDesc == driverOffenceUI.description)
                {
                    _driverOffenceDB.ListedOffence = offenceDAL.ListedOffenceFindById(offence.Id);   
                }

            }
            
            //Update driver offence object in database
            _DAL.EditDriverOffence(_driverOffenceDB);
        }


        /// <method>
        /// return the driver offence based on the specified id from database
        /// </method>
        public DriverOffenceUI GetDriverOffence(int id)
        {
            DriverOffence driverOffenceDB = _DAL.DriverOffenceFindById(id);
            DriverOffenceUI _offenceUI = new DriverOffenceUI();

            //driver offence info.
            _offenceUI.id = driverOffenceDB.Id;
            _offenceUI.status = driverOffenceDB.doStatus.ToString();
            _offenceUI.location = driverOffenceDB.doLocation.ToString();
            _offenceUI.gardaId = driverOffenceDB.doGardaId.ToString();
            _offenceUI.offenceDate = driverOffenceDB.doOffenceDate;

            //offence details
            _offenceUI.offenceId = driverOffenceDB.ListedOffence.Id;
            _offenceUI.description = driverOffenceDB.ListedOffence.LoDesc.ToString();

            //driver details info.
            _offenceUI.driverId = driverOffenceDB.DriverDetail.Id;
            _offenceUI.LicenceNo = driverOffenceDB.DriverDetail.DdLicenceNo.ToString();
            _offenceUI.FName = driverOffenceDB.DriverDetail.DdFName.ToString();
            _offenceUI.SName = driverOffenceDB.DriverDetail.DdSName.ToString();
            _offenceUI.Address1 = driverOffenceDB.DriverDetail.DdAddress1.ToString();
            _offenceUI.Address2 = driverOffenceDB.DriverDetail.DdAddress2.ToString();
            _offenceUI.Address3 = driverOffenceDB.DriverDetail.DdAddress3.ToString();
            _offenceUI.LicenceStatus = driverOffenceDB.DriverDetail.DdLicenceStatus.ToString();

            //vehicle details
            _offenceUI.vehicleId = driverOffenceDB.VehicleDetails.Id;
            _offenceUI.Registration = driverOffenceDB.VehicleDetails.VdRegistration.ToString();
            _offenceUI.Make = driverOffenceDB.VehicleDetails.VdMake.ToString();
            _offenceUI.Type = driverOffenceDB.VehicleDetails.VdType.ToString();
            _offenceUI.Capacity = driverOffenceDB.VehicleDetails.VdCubicCapacity;

            return _offenceUI;
        }

        // POST: /ListedOffence/Edit/5
        public void EditDriverOffence(DriverOffenceUI driverOffenceUI)
        {
             DriverOffence _driverOffenceDB = new DriverOffence();

             _driverOffenceDB.Id = driverOffenceUI.id;
             _driverOffenceDB.doStatus = driverOffenceUI.status.ToString();
             _driverOffenceDB.doLocation = driverOffenceUI.location.ToString();
             _driverOffenceDB.doGardaId = driverOffenceUI.gardaId.ToString();
             _driverOffenceDB.doOffenceDate = driverOffenceUI.offenceDate;


             //Check to see if driver exists in database            
             DriverDetailDAL driverDAL = new DriverDetailDAL();
             List<DriverDetail> driversDB = driverDAL.ListOfDriverDetails();

             int driverExists = 0;
             foreach (DriverDetail driver in driversDB)
             {
                 if (driver.DdLicenceNo == driverOffenceUI.LicenceNo)
                     driverExists = driver.Id;
             }

             //If driver does not exist declare a new driver object
             if (driverExists == 0)
             {
                 _driverOffenceDB.DriverDetail = new DriverDetail();
                 //update driver attributes
                 _driverOffenceDB.DriverDetail.DdLicenceNo = driverOffenceUI.LicenceNo.ToString();
                 _driverOffenceDB.DriverDetail.DdFName = driverOffenceUI.FName.ToString();
                 _driverOffenceDB.DriverDetail.DdSName = driverOffenceUI.SName.ToString();
                 _driverOffenceDB.DriverDetail.DdAddress1 = driverOffenceUI.Address1.ToString();
                 _driverOffenceDB.DriverDetail.DdAddress2 = driverOffenceUI.Address2.ToString();
                 _driverOffenceDB.DriverDetail.DdAddress3 = driverOffenceUI.Address3.ToString();
                 _driverOffenceDB.DriverDetail.DdLicenceStatus = driverOffenceUI.LicenceStatus.ToString();
                 _driverOffenceDB.DriverDetail = driverDAL.CreateDriverDetail(_driverOffenceDB.DriverDetail);
             }
             //if driver existed assign driver details to the new driver offence object;
             if (driverExists > 0)
             {
                 _driverOffenceDB.DriverDetail = driverDAL.DriverDetailFindById(driverExists);
                 //update driver attributes
                 _driverOffenceDB.DriverDetail.DdLicenceNo = driverOffenceUI.LicenceNo.ToString();
                 _driverOffenceDB.DriverDetail.DdFName = driverOffenceUI.FName.ToString();
                 _driverOffenceDB.DriverDetail.DdSName = driverOffenceUI.SName.ToString();
                 _driverOffenceDB.DriverDetail.DdAddress1 = driverOffenceUI.Address1.ToString();
                 _driverOffenceDB.DriverDetail.DdAddress2 = driverOffenceUI.Address2.ToString();
                 _driverOffenceDB.DriverDetail.DdAddress3 = driverOffenceUI.Address3.ToString();
                 _driverOffenceDB.DriverDetail.DdLicenceStatus = driverOffenceUI.LicenceStatus.ToString();
                 _driverOffenceDB.DriverDetail = driverDAL.DriverDetailFindById(driverDAL.EditDriverDetail(_driverOffenceDB.DriverDetail));
             }



             //Check to see if vehicle exists in database
             VehicleDetailDAL vehicleDAL = new VehicleDetailDAL();
             List<VehicleDetail> vehiclesDB = vehicleDAL.ListOfVehicleDetails();

             int vehicleExists = 0;
             foreach (VehicleDetail vehicle in vehiclesDB)
             {
                 if (vehicle.VdRegistration == driverOffenceUI.Registration)
                     vehicleExists = vehicle.Id;
             }

             //If vehicle does not exist declare a new driver object
             if (vehicleExists == 0)
             {
                 _driverOffenceDB.VehicleDetails = new VehicleDetail();
                 //update vechile attributes
                 _driverOffenceDB.VehicleDetails.VdRegistration = driverOffenceUI.Registration.ToString();
                 _driverOffenceDB.VehicleDetails.VdMake = driverOffenceUI.Make.ToString();
                 _driverOffenceDB.VehicleDetails.VdType = driverOffenceUI.Type.ToString();
                 _driverOffenceDB.VehicleDetails.VdCubicCapacity = driverOffenceUI.Capacity;
                 _driverOffenceDB.VehicleDetails = vehicleDAL.CreateVehicleDetail(_driverOffenceDB.VehicleDetails);
             }

             //if vehicle existed assign driver details to the driver offence object;
             if (vehicleExists > 0)
             {
                 _driverOffenceDB.VehicleDetails = vehicleDAL.VehicleDetailFindById(vehicleExists);
                 //update vechile attributes
                 _driverOffenceDB.VehicleDetails.VdRegistration = driverOffenceUI.Registration.ToString();
                 _driverOffenceDB.VehicleDetails.VdMake = driverOffenceUI.Make.ToString();
                 _driverOffenceDB.VehicleDetails.VdType = driverOffenceUI.Type.ToString();
                 _driverOffenceDB.VehicleDetails.VdCubicCapacity = driverOffenceUI.Capacity;
                 _driverOffenceDB.VehicleDetails = vehicleDAL.VehicleDetailFindById(vehicleDAL.EditVehicleDetail(_driverOffenceDB.VehicleDetails));
             }


             //assign offence details to the new driver offence object
             ListedOffenceDAL offenceDAL = new ListedOffenceDAL();
             List<ListedOffence> offencesDB = offenceDAL.ListOfListedOffences();

             foreach (ListedOffence offence in offencesDB)
             {
                 if (offence.LoDesc == driverOffenceUI.description)
                     _driverOffenceDB.ListedOffence = offenceDAL.ListedOffenceFindById(offence.Id);
             }

            _DAL.EditDriverOffence(_driverOffenceDB);
        }

        /// <method>
        /// SetOffenceStatus() sets status of offence to false
        /// So it cannot be used for new offences.
        /// </method>
        public void SetDriverOffenceDeleteStatus(int id)
        {
            //offences cannot be deleted from the database
            //as they are referenced in the drivingoffence table.
            //Instead an offence will have its status=false
            //so it cannot be used in new driving offences.
            //This ensures integrity within existing driving offences. 
            DriverOffence _driverOffence = _DAL.DriverOffenceFindById(id);
            _driverOffence.doStatus = "Deleted";
            //CC - future update might be to add a deletion data field.
            _DAL.EditDriverOffence(_driverOffence);
        }


    }
}