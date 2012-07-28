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
                {
                    driverExists = driver.Id;
                    break;
                }
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
                //_driverOffenceDB.DriverDetail = driverDAL.DriverDetailFindById(driverDAL.EditDriverDetail(_driverOffenceDB.DriverDetail));
                driverDAL.EditDriverDetail(_driverOffenceDB.DriverDetail);
            } 

            //Check to see if vehicle exists in database
            VehicleDetailDAL vehicleDAL = new VehicleDetailDAL();
            List<VehicleDetail> vehiclesDB = vehicleDAL.ListOfVehicleDetails();

            int vehicleExists = 0;
            foreach (VehicleDetail vehicle in vehiclesDB)
            {
                if (vehicle.VdRegistration == driverOffenceUI.Registration)
                {
                    vehicleExists = vehicle.Id;
                    break;
                }
            }

            //If vehicle does not exist declare a new vehicle object
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



            //if vehicle existed assign vehicle details to the vehicle offence object;
            if (vehicleExists > 0)
            {
                _driverOffenceDB.VehicleDetails = vehicleDAL.VehicleDetailFindById(vehicleExists);
                //update vechile attributes
                _driverOffenceDB.VehicleDetails.VdRegistration = driverOffenceUI.Registration.ToString();
                _driverOffenceDB.VehicleDetails.VdMake = driverOffenceUI.Make.ToString();
                _driverOffenceDB.VehicleDetails.VdType = driverOffenceUI.Type.ToString();
                _driverOffenceDB.VehicleDetails.VdCubicCapacity = driverOffenceUI.Capacity;
                //_driverOffenceDB.VehicleDetails = vehicleDAL.VehicleDetailFindById( vehicleDAL.EditVehicleDetail(_driverOffenceDB.VehicleDetails));
                vehicleDAL.EditVehicleDetail(_driverOffenceDB.VehicleDetails);
            }


            //assign offence details to the new driver offence object
            ListedOffenceDAL offenceDAL = new ListedOffenceDAL();
            List<ListedOffence> offencesDB = offenceDAL.ListOfListedOffences();

            foreach (ListedOffence offence in offencesDB)
            {
                if ((offence.LoDesc == driverOffenceUI.description) && (offence.LoStatus))
                {
                    _driverOffenceDB.ListedOffence = offenceDAL.ListedOffenceFindById(offence.Id);
                    break;
                }

            }

            //Create a new driver offence
            int driverOffenceID = _DAL.CreateDriverOffence(_driverOffenceDB);
            //_driverOffenceDB = _DAL.DriverOffenceFindById(driverOffenceID);
            //Update driver offence object in database
            //_DAL.EditDriverOffence(_driverOffenceDB);
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
            DriverOffence _driverOffenceDB = _DAL.DriverOffenceFindById(driverOffenceUI.id);

            //Update offence details
             _driverOffenceDB.doStatus = driverOffenceUI.status.ToString();
             _driverOffenceDB.doLocation = driverOffenceUI.location.ToString();
             _driverOffenceDB.doGardaId = driverOffenceUI.gardaId.ToString();
             _driverOffenceDB.doOffenceDate = driverOffenceUI.offenceDate;


             //Update driver details            
             DriverDetailDAL driverDAL = new DriverDetailDAL();
                                    
             //_driverOffenceDB.DriverDetail.DdLicenceNo = driverOffenceUI.LicenceNo.ToString();
             _driverOffenceDB.DriverDetail.DdFName = driverOffenceUI.FName.ToString();
             _driverOffenceDB.DriverDetail.DdSName = driverOffenceUI.SName.ToString();
             _driverOffenceDB.DriverDetail.DdAddress1 = driverOffenceUI.Address1.ToString();
             _driverOffenceDB.DriverDetail.DdAddress2 = driverOffenceUI.Address2.ToString();
             _driverOffenceDB.DriverDetail.DdAddress3 = driverOffenceUI.Address3.ToString();
             _driverOffenceDB.DriverDetail.DdLicenceStatus = driverOffenceUI.LicenceStatus.ToString();
            //store updated driver details in database
            driverDAL.EditDriverDetail(_driverOffenceDB.DriverDetail);
            
            //update vehicle details
             VehicleDetailDAL vehicleDAL = new VehicleDetailDAL();

           _driverOffenceDB.VehicleDetails.VdRegistration = driverOffenceUI.Registration.ToString();
            _driverOffenceDB.VehicleDetails.VdMake = driverOffenceUI.Make.ToString();
           _driverOffenceDB.VehicleDetails.VdType = driverOffenceUI.Type.ToString();
            _driverOffenceDB.VehicleDetails.VdCubicCapacity = driverOffenceUI.Capacity;
            vehicleDAL.EditVehicleDetail(_driverOffenceDB.VehicleDetails);
             

            _DAL.EditDriverOffence(_driverOffenceDB);
        }

        /// <method>
        /// SetDriverOffenceSummonsStatus() sets status of driver Offence to summons status
        /// So it cannot be used for new offences.
        /// </method>
        public void SetDriverOffenceSummonsStatus(int id)
        {
            //offences cannot be deleted from the database
            //as they are referenced in the drivingoffence table.
            //Instead an offence will have its status=false
            //so it cannot be used in new driving offences.
            //This ensures integrity within existing driving offences. 
            DriverOffence _driverOffence = _DAL.DriverOffenceFindById(id);
            _driverOffence.doStatus = "Court Summons";
            //CC - future update might be to add a deletion data field.
            _DAL.EditDriverOffence(_driverOffence);
        }

        /// <method>
        /// SetDriverOffenceSummonsStatus() sets status of driver Offence to summons status
        /// So it cannot be used for new offences.
        /// </method>
        public void SetDriver28dayNotificationStatus(int id)
        {
            //offences cannot be deleted from the database
            //as they are referenced in the drivingoffence table.
            //Instead an offence will have its status=false
            //so it cannot be used in new driving offences.
            //This ensures integrity within existing driving offences. 
            DriverOffence _driverOffence = _DAL.DriverOffenceFindById(id);
            _driverOffence.doStatus = "28 Days Notification";
            //CC - future update might be to add a deletion data field.
            _DAL.EditDriverOffence(_driverOffence);
        }

        /// <method>
        /// SetDriverOffenceSummonsStatus() sets status of driver Offence to summons status
        /// So it cannot be used for new offences.
        /// </method>
        public void SetDriverPenaltyNotificationStatus(int id)
        {
            //offences cannot be deleted from the database
            //as they are referenced in the drivingoffence table.
            //Instead an offence will have its status=false
            //so it cannot be used in new driving offences.
            //This ensures integrity within existing driving offences. 
            DriverOffence _driverOffence = _DAL.DriverOffenceFindById(id);
            _driverOffence.doStatus = "Penalty Notification";
            //CC - future update might be to add a deletion data field.
            _DAL.EditDriverOffence(_driverOffence);
        }

        /// <method>
        /// SetDriverOffenceDeleteStatus() sets status of driver to false
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

        /// <method>
        /// SetDriverDisqualifyStatus() sets status of drivers licence to disqualified
        /// </method>
        public void SetDriverDisqualifyStatus(int id)
        {
            //offences cannot be deleted from the database
            //as they are referenced in the drivingoffence table.
            //Instead an offence will have its status=false
            //so it cannot be used in new driving offences.
            //This ensures integrity within existing driving offences. 
            DriverDetailDAL driverDAL = new DriverDetailDAL();
            DriverDetail _driver = driverDAL.DriverDetailFindById(id);

            _driver.DdLicenceStatus= "Disqualified";
            driverDAL.EditDriverDetail(_driver);
        }

        /// <method>
        /// SearchByDriver() returns all driving offences
        /// belonging to the specified driver id.
        /// </method>
        public List<GetDriverOffenceUI> SearchByDriver(string licenceNo)
        {
            List<DriverOffence> driverOffencesDB = _DAL.ListOfDriverOffences();
            List<GetDriverOffenceUI> driverOffencesUI = new List<GetDriverOffenceUI>();
            GetDriverOffenceUI _offenceUI = new GetDriverOffenceUI();

            //loop through all driving offences.
            //if driving offence matches driver licence
            //search criteria then store the driving offence.
            foreach (DriverOffence driverOffence in driverOffencesDB)
            {
                if (driverOffence.DriverDetail.DdLicenceNo == licenceNo)
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

                    driverOffencesUI.Add(_offenceUI);
                }
            }

            return driverOffencesUI;
        }

        /// <method>
        /// SearchByRegistration() returns all driving offences
        /// belonging to a specific vehicle registration.
        /// </method>
        public List<GetDriverOffenceUI> SearchByRegistration(string registration)
        {
            List<DriverOffence> driverOffencesDB = _DAL.ListOfDriverOffences();
            List<GetDriverOffenceUI> driverOffencesUI = new List<GetDriverOffenceUI>();
            GetDriverOffenceUI _offenceUI = new GetDriverOffenceUI();

            //loop through all driving offences.
            //if driving offence matches vehicle registration
            //search criteria then store the driving offence.
            foreach (DriverOffence driverOffence in driverOffencesDB)
            {
                if (driverOffence.VehicleDetails.VdRegistration == registration)
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

                    driverOffencesUI.Add(_offenceUI);
                }
            }

            return driverOffencesUI;
        }
        /// <method>
        /// SearchByOffenceType() returns all driving offences
        /// belonging to a specific offence type.
        /// </method>
        public List<GetDriverOffenceUI> SearchByOffenceType(string description)
        {
            List<DriverOffence> driverOffencesDB = _DAL.ListOfDriverOffences();
            List<GetDriverOffenceUI> driverOffencesUI = new List<GetDriverOffenceUI>();
            GetDriverOffenceUI _offenceUI = new GetDriverOffenceUI();

            //loop through all driving offences.
            //if driving offence matches offence type
            //search criteria then store the driving offence.
            foreach (DriverOffence driverOffence in driverOffencesDB)
            {
                if (driverOffence.ListedOffence.LoDesc == description)
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

                    driverOffencesUI.Add(_offenceUI);
                }
            }

            return driverOffencesUI;
        }


        /// <method>
        /// SearchByDVO() returns all driving offences
        /// belonging to the specified search criteria
        /// of driver, vehicle and offence type.
        /// </method>
        public List<GetDriverOffenceUI> SearchByDVO(string licenceNo, string registration, string description)
        {
            List<DriverOffence> driverOffencesDB = _DAL.ListOfDriverOffences();
            List<GetDriverOffenceUI> driverOffencesUI = new List<GetDriverOffenceUI>();
            GetDriverOffenceUI _offenceUI = new GetDriverOffenceUI();

            //loop through all driving offences.
            //if driving offence matches driver licence, vehicle registration and
            //offence type search criteria then store the driving offence.
            foreach (DriverOffence driverOffence in driverOffencesDB)
            {
                if (driverOffence.DriverDetail.DdLicenceNo == licenceNo && 
                    driverOffence.VehicleDetails.VdRegistration == registration &&
                    driverOffence.ListedOffence.LoDesc == description )
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

                    driverOffencesUI.Add(_offenceUI);
                }
            }

            return driverOffencesUI;
        }

        /// <method>
        /// SearchByOffenceType() returns all driving offences
        /// belonging to a specified search criteria of 
        /// driver and vehicle.
        /// </method>
        public List<GetDriverOffenceUI> SearchByDV(string licenceNo, string registration)
        {
            List<DriverOffence> driverOffencesDB = _DAL.ListOfDriverOffences();
            List<GetDriverOffenceUI> driverOffencesUI = new List<GetDriverOffenceUI>();
            GetDriverOffenceUI _offenceUI = new GetDriverOffenceUI();

            //loop through all driving offences.
            //if driving offence matches driver licence and vehicle registration 
            //search criteria then store the driving offence.
            foreach (DriverOffence driverOffence in driverOffencesDB)
            {
                if (driverOffence.DriverDetail.DdLicenceNo == licenceNo && 
                    driverOffence.VehicleDetails.VdRegistration == registration)
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

                    driverOffencesUI.Add(_offenceUI);
                }
            }

            return driverOffencesUI;
        }

        /// <method>
        /// SearchByDO() returns all driving offences
        /// belonging to a specified search criteria of
        /// driver and offence type
        /// </method>
        public List<GetDriverOffenceUI> SearchByDO(string licenceNo, string description)
        {
            List<DriverOffence> driverOffencesDB = _DAL.ListOfDriverOffences();
            List<GetDriverOffenceUI> driverOffencesUI = new List<GetDriverOffenceUI>();
            GetDriverOffenceUI _offenceUI = new GetDriverOffenceUI();

            //loop through all driving offences.
            //if driving offence matches driver licence, and offence type
            //search criteria then store the driving offence.
            foreach (DriverOffence driverOffence in driverOffencesDB)
            {
                if (driverOffence.DriverDetail.DdLicenceNo == licenceNo &&
                    driverOffence.ListedOffence.LoDesc == description)
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

                    driverOffencesUI.Add(_offenceUI);
                }
            }

            return driverOffencesUI;
        }

        /// <method>
        /// SearchByOffenceType() returns all driving offences
        /// belonging to a specified search criteria of 
        /// vehicle and offence type.
        /// </method>
        public List<GetDriverOffenceUI> SearchByVO(string registration, string description)
        {
            List<DriverOffence> driverOffencesDB = _DAL.ListOfDriverOffences();
            List<GetDriverOffenceUI> driverOffencesUI = new List<GetDriverOffenceUI>();
            GetDriverOffenceUI _offenceUI = new GetDriverOffenceUI();

            //loop through all driving offences.
            //if driving offence matches vehicle and offence type
            //search criteria then store the driving offence.
            foreach (DriverOffence driverOffence in driverOffencesDB)
            {
                if (driverOffence.VehicleDetails.VdRegistration == registration &&
                    driverOffence.ListedOffence.LoDesc == description)
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

                    driverOffencesUI.Add(_offenceUI);
                }
            }

            return driverOffencesUI;
        }

        /// <method>
        /// StatisticsOffence() returns 'Penalty Points by Offence Type' statistics.
        /// </method>
        public string StatisticsOffence()
        {
            List<DriverOffence> _driverOffenceDB = _DAL.ListOfDriverOffences();
            List<PointsByOffenceTypeUI> pointsByOffenceType = new List<PointsByOffenceTypeUI>();
            PointsByOffenceTypeUI newPointsByOffenceType = new PointsByOffenceTypeUI();
            List<string> listedOffences = new List<string>();

            //get the offence types that are being used.
            bool offenceExists = false;
            foreach (DriverOffence driverOffence in _driverOffenceDB)
            {
                foreach (string offenceType in listedOffences)
                {
                    if (offenceType == driverOffence.ListedOffence.LoDesc)
                    {
                        offenceExists = true;
                        break;
                    }
                }
                if (offenceExists == false)
                    listedOffences.Add(driverOffence.ListedOffence.LoDesc.ToString());
                if (offenceExists == true)
                    offenceExists = false;
            }

            //loop through each listed offence type.
            //For each offence type find the corresponding driving offences.
            //Add to the offence type totals
            foreach (string offence in listedOffences)
            {
                newPointsByOffenceType.name = ""; //set for next offence type
                newPointsByOffenceType.totalDrivers = 0; //set for next offence type
                newPointsByOffenceType.totalPoints = 0; //set for next offence type

                //loop through driver offence to find drivers of this driving offence type
                //Tally up driver numbers and penalty point totals
                //Store this information
                //return results
                foreach (DriverOffence driverOffence in _driverOffenceDB)
                {
                    if (driverOffence.ListedOffence.LoDesc == offence)
                    {
                        newPointsByOffenceType.totalDrivers = newPointsByOffenceType.totalDrivers + 1;
                        newPointsByOffenceType.name = offence;
                        if (driverOffence.doStatus == "New Offence")
                            //penalty points not applied yet.
                            newPointsByOffenceType.totalPoints = newPointsByOffenceType.totalPoints + 0;
                        else if ((driverOffence.doStatus == "Penalty Notification") ||
                            (driverOffence.doStatus == "28 Days Notification") ||
                            (driverOffence.doStatus == "Court Summons"))
                            //apply penalty points on conviction
                            newPointsByOffenceType.totalPoints = newPointsByOffenceType.totalPoints + driverOffence.ListedOffence.Lo56days;
                        else if (driverOffence.doStatus == "Fine Paid")
                            //apply penalty points on payment
                            newPointsByOffenceType.totalPoints = newPointsByOffenceType.totalPoints + driverOffence.ListedOffence.Lo28Days;
                    } //end if offenceType
                }//end foreach driver offence

                pointsByOffenceType.Add(newPointsByOffenceType);             
            }

            //loop through offence types and build message
            string message = "";
            foreach (PointsByOffenceTypeUI offence in pointsByOffenceType)
            {
                message = message + "A '" + offence.name +
                    "' was committed by " + offence.totalDrivers +
                    " drivers accumulating " + offence.totalPoints +
                    " penalty points in total. \r\n";
            }
            return message;
            
        }

         /// <method>
        /// StatisticsDriver() returns 'Penalty Points Incurred Per Driver Per County' statistics.
        /// </method>
        public string StatisticsDriver()
        {
            //Get list of drivers
            //Get list of driving offences.
            //For each driver store total penalty points and county of residence.
            //For each county store total drivers per penalty points
            //Return results.
            DriverDetailDAL driverDAL = new DriverDetailDAL();
            List<DriverDetail> allDrivers = driverDAL.ListOfDriverDetails();
            List<DriverOffence> _drivingOffenceDB = _DAL.ListOfDriverOffences();
            DriverPointsUI newDriver = new DriverPointsUI();
            List<DriverPointsUI> _uniqueDrivers = new List<DriverPointsUI>();
            List<string> countyNames = new List<string>();
            List<DriverPointsByCountyUI> _totalPointsByCounty = new List<DriverPointsByCountyUI>();
            DriverPointsByCountyUI pointsByCounty = new DriverPointsByCountyUI();

            bool driverExists = false;
            foreach (DriverDetail driver in allDrivers)
            {
               foreach (DriverOffence offence in _drivingOffenceDB) //  for each file
                {
                    if (offence.DriverDetail.DdLicenceNo == driver.DdLicenceNo)
                    {
                        //This is another driving offence belonging to this driver.
                        //Store the drivers county of residence.
                        //Store the drivers licence Number.
                        //Check penalty points belonging to offence
                        //Add the penalty points to the drivers total
                        //Store the driver information
                        newDriver.County = offence.DriverDetail.DdAddress3.ToString();
                        if (offence.doStatus == "New Offence")
                            //penalty points not applied yet.
                            newDriver.AccumulatedPoints = newDriver.AccumulatedPoints + 0;
                        else if ((offence.doStatus == "Penalty Notification") ||
                            (offence.doStatus == "28 Days Notification") ||
                            (offence.doStatus == "Court Summons"))
                        {
                            //apply penalty points on conviction
                            newDriver.AccumulatedPoints = newDriver.AccumulatedPoints + offence.ListedOffence.Lo56days;
                            driverExists = true;
                        }
                        else if (offence.doStatus == "Fine Paid")
                        {
                            //apply penalty points on payment
                            newDriver.AccumulatedPoints = newDriver.AccumulatedPoints + offence.ListedOffence.Lo28Days;
                            driverExists = true;
                        }
                        
                    }//end if
                }//end for _drivingOffenceDB

               if (driverExists == true)
               {
                   //store driver information
                   _uniqueDrivers.Add(newDriver);
                   //Reset for next driver
                   driverExists = false;
                   newDriver.County ="";
                   newDriver.AccumulatedPoints = 0;
               }
            } //end foreach allDrivers

            //Create a list of countys with offenders.
            bool countyExists = false;
            foreach (DriverPointsUI driver in _uniqueDrivers)
            {
                foreach (string county in countyNames)
                {
                    if (driver.County == county)
                    {
                        countyExists = true;
                        break;
                    }
                }
                if (countyExists == false)
                    countyNames.Add(driver.County.ToString());
                else if (countyExists == true)
                    countyExists = false;

            }
            //calculate penalty points per driver per county.
            int driverPoints = 0;
            foreach (string county in countyNames)
            {
                pointsByCounty.name = county;
                foreach (DriverPointsUI driver in _uniqueDrivers)
                {
                    if (driver.County == county)
                    {
                        //Driver resides in this county
                        //Add driver to driver total
                        //Add the driver to penalty point total.
                        pointsByCounty.TotalDrivers = pointsByCounty.TotalDrivers + 1;
                        if (driver.AccumulatedPoints > 12)
                            driverPoints = 12;
                        else
                            driverPoints = driver.AccumulatedPoints;

                        switch (driverPoints)
                        {
                            case 1:
                                pointsByCounty.TotalP1 = pointsByCounty.TotalP1 + 1;
                                break;
                            case 2:
                                pointsByCounty.TotalP2 = pointsByCounty.TotalP2 + 1;
                                break;
                            case 3:
                                pointsByCounty.TotalP3 = pointsByCounty.TotalP3 + 1;
                                break;
                            case 4:
                                pointsByCounty.TotalP4 = pointsByCounty.TotalP4 + 1;
                                break;
                            case 5:
                                pointsByCounty.TotalP5 = pointsByCounty.TotalP5 + 1;
                                break;
                            case 6:
                                pointsByCounty.TotalP6 = pointsByCounty.TotalP6 + 1;
                                break;
                            case 7:
                                pointsByCounty.TotalP7 = pointsByCounty.TotalP7 + 1;
                                break;
                            case 8:
                                pointsByCounty.TotalP8 = pointsByCounty.TotalP8 + 1;
                                break;
                            case 9:
                                pointsByCounty.TotalP8 = pointsByCounty.TotalP9 + 1;
                                break;
                            case 10:
                                pointsByCounty.TotalP10 = pointsByCounty.TotalP10 + 1;
                                break;
                            case 11:
                                pointsByCounty.TotalP11 = pointsByCounty.TotalP11 + 1;
                                break;
                            case 12:
                                pointsByCounty.TotalP12 = pointsByCounty.TotalP12 + 1;
                                break;
                            default:
                                break;
                        }//end switch
                        driverPoints = 0;  //reset for next driver
                    } //end if
                }// end for _uniqueDrivers
                                
                _totalPointsByCounty.Add(pointsByCounty);//store county points by driver
                pointsByCounty.name = "";
                pointsByCounty.TotalDrivers = 0;
                pointsByCounty.TotalP1 = 0;
                pointsByCounty.TotalP2 = 0;
                pointsByCounty.TotalP3 = 0;
                pointsByCounty.TotalP4 = 0;
                pointsByCounty.TotalP5 = 0;
                pointsByCounty.TotalP6 = 0;
                pointsByCounty.TotalP7 = 0;
                pointsByCounty.TotalP8 = 0;
                pointsByCounty.TotalP9 = 0;
                pointsByCounty.TotalP10 = 0;
                pointsByCounty.TotalP11 = 0;
                pointsByCounty.TotalP12 = 0;
            }

           
            //loop through county and build message
            string message = "";
            foreach (DriverPointsByCountyUI county in _totalPointsByCounty)
            {
                message = message + "County " + county.name + ": " +
                   "1 point - " + county.TotalP1 + " drivers; " +
                   "2 point - " + county.TotalP2 + " drivers; " +
                   "3 point - " + county.TotalP3 + " drivers; " +
                   "4 point - " + county.TotalP4 + " drivers; " +
                   "5 point - " + county.TotalP5 + " drivers; " +
                   "6 point - " + county.TotalP6 + " drivers; " +
                   "7 point - " + county.TotalP7 + " drivers; " +
                   "8 point - " + county.TotalP8 + " drivers; " +
                  "9 point - " + county.TotalP9 + " drivers; " +
                   "10 point - " + county.TotalP10 + " drivers; " +
                   "11 point - " + county.TotalP11 + " drivers; " +
                   "12 point - " + county.TotalP12 + " drivers; " +
                   "Total Drivers - " + county.TotalDrivers + ".\r\n";
            }
            return message;
        }

         /// <method>
        /// StatisticsLicence()  returns 'Number of Drivers by Licence Type' statistics.
        /// </method>
        public string StatisticsLicence()
        {
            //Get driving offences.
            //for each unique driver store licence type.
            //Calculate total of each licence type.
            //return results.
            List<DriverOffence> _drivingOffenceDB = _DAL.ListOfDriverOffences();
            List<DriverLicenceUI> _uniqueDrivers = new List<DriverLicenceUI>();
            DriverLicenceUI licence = new DriverLicenceUI();
            LicenceTypeUI licenceTypeStats = new LicenceTypeUI();

            bool driverExists = false;
            foreach (DriverOffence offence in _drivingOffenceDB)
            {
                foreach (DriverLicenceUI driver in _uniqueDrivers)
                {
                    if (offence.DriverDetail.DdLicenceNo == driver.licenceNo)
                    {
                        //This is a duplicate record of driver.
                        //Driver is already stored in _uniqueDrivers.
                        //Stop looping.
                        driverExists = true;
                        break;
                    }
                }
                if (driverExists == false)
                {
                    //This is a unique record of a driver.
                    //Store driver licence details.
                    licence.licenceNo = offence.DriverDetail.DdLicenceNo;
                    licence.licenceType = offence.DriverDetail.DdLicenceStatus;
                    _uniqueDrivers.Add(licence);
                    //Add driver to the corresponding licence type total.
                    if (offence.DriverDetail.DdLicenceStatus == "Full Licence")
                        licenceTypeStats.FullLicence = licenceTypeStats.FullLicence + 1;
                    if (offence.DriverDetail.DdLicenceStatus == "Provisional Licence")
                        licenceTypeStats.Provisional = licenceTypeStats.Provisional + 1;
                    if (offence.DriverDetail.DdLicenceStatus == "Disqualified")
                        licenceTypeStats.Disqualified = licenceTypeStats.Disqualified + 1;
                    if (offence.DriverDetail.DdLicenceStatus == "No Valid Licence")
                        licenceTypeStats.NoLicence = licenceTypeStats.NoLicence + 1;
                    if (offence.DriverDetail.DdLicenceStatus == "Other")
                        licenceTypeStats.Other = licenceTypeStats.Other + 1;
                }
                if (driverExists == true)
                    driverExists = false;  //Reset for next driver
            }
            string message = licenceTypeStats.FullLicence + " Full Licence Holders. " + "\r\n" +
                licenceTypeStats.Provisional + " Provisional Licence Holders. " + "\r\n" +
                licenceTypeStats.Disqualified + " Disqualified Licence Holders. " + "\r\n" +
                licenceTypeStats.NoLicence + " Non Licence drivers. " + "\r\n" +
                licenceTypeStats.Other + " Other. \r\n";

            return message;
        }

        /// <method>
        /// NewOffenceNotification()  runs 'Penalty Point New Offence Notification' Daily Task.
        /// </method>
        public string NewOffenceNotification()
        {
            List<DriverOffence> _driverOffenceDB = _DAL.ListOfDriverOffences();

            //loop through existing driver offences.
            //check if driver offence is a new offence.
            //Mark driver offence as penalty notification 
            //return results
           
            //int currentYear = System.DateTime.;
            string message = "Drivers marked as 'Penalty Point Notification':\r\n";

            foreach (DriverOffence offence in _driverOffenceDB)
            {
                if (offence.doStatus == "New Offence") 
                {
                        message = message + offence.DriverDetail.DdFName +
                            " " + offence.DriverDetail.DdSName + " (" +
                            offence.DriverDetail.DdLicenceNo + ").\r\n";
                        //mark driver offence as court summons.
                        SetDriverPenaltyNotificationStatus(offence.Id);

                    } //end if 
                }//end for _driverOffenceDB
            return message;
        }

        /// <method>
        /// 28DaysNotification()  runs 'Penalty Points 28 Days Notification' Daily Task.
        /// </method>
        public string A28DaysNotification()
        {
            List<DriverOffence> _driverOffenceDB = _DAL.ListOfDriverOffences();

            //loop through existing driver offences.
            //compare driver offence committed date against current date.
            //If 28 days has passed mark driver offence as 28 day penalty notification 
            //return results
            int currentDay = System.DateTime.Now.Day;
            //int currentYear = System.DateTime.;
            string message = "Drivers marked with a '28 days Year Penalty Point Deletion Notification': \r\n";

            foreach (DriverOffence offence in _driverOffenceDB)
            {
                //IMPORTANT TO EXCLUDE DELETED
                if ((offence.doStatus != "Deleted") && (offence.doStatus != "28 Days Notification")
                    && (offence.doStatus != "Court Summons") && (offence.doStatus != "Fine Paid"))
                {

                    if (offence.doOffenceDate.AddDays(28) <= (System.DateTime.Now))

                    {
                        message = message + offence.DriverDetail.DdFName +
                            " " + offence.DriverDetail.DdSName + " (" +
                            offence.DriverDetail.DdLicenceNo + ").\r\n";
                        //mark driver offence as court summons.
                        SetDriver28dayNotificationStatus(offence.Id);

                    } //end if 
                }//end for _driverOffenceDB
            }//!Deleted
            return message;
       
        }
        

        /// <method>
        /// DisqualificationNotification()  runs '12 Point Licence Disqualification Notification' Daily Task.
        /// </method>
        public string DisqualificationNotification()
        {
            //Get list of drivers
            //Get list of driver offences
            //For each driver calculate total penalty points accumulated
            //if penalty points are 12 or more then mark driver status as disqualified
            //Return results.

            DriverDetailDAL driverDAL = new DriverDetailDAL();
            List<DriverDetail> allDrivers = driverDAL.ListOfDriverDetails();
            List<DriverOffence> _drivingOffenceDB = _DAL.ListOfDriverOffences();

            int driverPointsAccumulated = 0;
            bool offencesExists = false;
            string message = "Drivers who've accumulated 12 or more penalty points and now have their drivers licence disqualified: \r\n";
            foreach (DriverDetail driver in allDrivers)
            {
                //if driver is not already disqualified
                if (driver.DdLicenceStatus != "Disqualified")
                {
                    foreach (DriverOffence offence in _drivingOffenceDB) //  for each file
                    {
                        if (offence.doStatus != "Deleted")
                        {
                            if (offence.DriverDetail.DdLicenceNo == driver.DdLicenceNo)
                            {
                                offencesExists = true;
                                //This is another driving offence belonging to this driver.
                                //Check penalty points belonging to offence
                                //Add the penalty points to the drivers total
                                //IF 12 or more points accumulated then disqualify driver	

                                if (offence.doStatus == "New Offence")
                                    //penalty points not applied yet.
                                    driverPointsAccumulated = driverPointsAccumulated + 0;
                                else if ((offence.doStatus == "Penalty Notification") ||
                                    (offence.doStatus == "28 Days Notification") ||
                                    (offence.doStatus == "Court Summons"))
                                {
                                    //apply penalty points on conviction
                                    driverPointsAccumulated = driverPointsAccumulated + offence.ListedOffence.Lo56days;
                                }
                                else if (offence.doStatus == "Fine Paid")
                                {
                                    //apply penalty points on payment
                                    driverPointsAccumulated = driverPointsAccumulated + offence.ListedOffence.Lo28Days;
                                }
                            }//end if
                        }//end if
                    }//end for _drivingOffenceDB

                    if (offencesExists == true)
                    {
                        //build up results.
                        if (driverPointsAccumulated >= 12)
                        {
                            message = message + driver.DdFName +
                                     " " + driver.DdSName + " (" +
                                     driver.DdLicenceNo + ") residing at " +
                                     driver.DdAddress1 + ", " +
                                     driver.DdAddress2 + ", " +
                                     driver.DdAddress3 + " has accumulated " +
                                     driverPointsAccumulated + " penalty points.\r\n";

                            //Update driver licence status to 'disqualified'
                            SetDriverDisqualifyStatus(driver.Id);
                        }//end if driverPointsAccumulated

                        //Reset for next driver
                        offencesExists = false;
                        driverPointsAccumulated = 0;
                    } //end if offencesExists
                } //end if driver is not already disqualified
            } //end foreach allDrivers

            return message;
        }

        public string A56DayNotification()
        {
            List<DriverOffence> _driverOffenceDB = _DAL.ListOfDriverOffences();

            //loop through existing driver offences.
            //compare driver offence committed date against current date.
            //If 56 days has passed mark driver offence as court summons
            //return results
            int currentDay = System.DateTime.Now.Day;
            //int currentYear = System.DateTime.;
            string message = "Drivers marked with a '56 days Year Penalty Point Deletion Notification': \r\n";

            SummonsDetailDAL dal = new SummonsDetailDAL();
            SummonsDetail summonsdetail = new SummonsDetail();

            foreach (DriverOffence offence in _driverOffenceDB)
            {
                //IMPORTANT TO EXCLUDE DELETED
                if ((offence.doStatus != "Deleted") && (offence.doStatus != "Court Summons") &&
                    (offence.doStatus != "Fine Paid"))
                {

                    if (offence.doOffenceDate.AddDays(56) <= (System.DateTime.Now))
                        
                            //if (offence.doOffenceDate.DayOfYear > (currentDay - 55))
                            {

                                message = message + offence.DriverDetail.DdFName +
                                    " " + offence.DriverDetail.DdSName + " (" +
                                    offence.DriverDetail.DdLicenceNo + ").\r\n";
                                //mark driver offence as court summons.
                                SetDriverOffenceSummonsStatus(offence.Id);
                                //summonsdetail.DriverOffence = offence;

                                summonsdetail.SdDate = DateTime.Now;
                                summonsdetail.SdFName = offence.DriverDetail.DdFName;
                                summonsdetail.SdSName = offence.DriverDetail.DdSName;
                                summonsdetail.SdAddress1 = offence.DriverDetail.DdAddress1;
                                summonsdetail.SdAddress2 = offence.DriverDetail.DdAddress2;
                                summonsdetail.SdAddress3 = offence.DriverDetail.DdAddress3;
                                summonsdetail.SdLicenceNo = offence.DriverDetail.DdLicenceNo;
                                summonsdetail.SdRegistration = offence.VehicleDetails.VdRegistration;
                               
                                //this.
                                dal.CreateSummonsDetail(summonsdetail);            


                            } //end if 
                }//end for _driverOffenceDB
            }//!Deleted
            return message;
        }


        /// <method>
        /// A3YearDeleteNotification()  runs '3 Year Penalty Point Deletion Notification' Daily Task.
        /// </method>
        public string A3YearDeleteNotification()
        {
            List<DriverOffence> _driverOffenceDB = _DAL.ListOfDriverOffences();

            //loop through existing driver offences.
            //compare driver offence committed date against current date.
            //If 3 years has passed mark driver offence as deleted
            //return results
            int currentDay = System.DateTime.Now.Day;
            int currentMonth = System.DateTime.Now.Month;
            int currentYear = System.DateTime.Now.Year;
            string message = "Drivers marked with a '3 Year Penalty Point Deletion Notification': \r\n";
            foreach (DriverOffence offence in _driverOffenceDB)
            {
                if ((offence.doStatus != "Deleted") && (offence.doStatus != "Fine Paid"))
                {
                    if (offence.doOffenceDate.Year <= (currentYear - 3))
                        if (offence.doOffenceDate.Month <= currentMonth)
                            if (offence.doOffenceDate.Day <= currentDay)
                            {
                                message = message + offence.DriverDetail.DdFName +
                                    " " + offence.DriverDetail.DdSName + " (" +
                                    offence.DriverDetail.DdLicenceNo + ") residing at " +
                                    offence.DriverDetail.DdAddress1 + ", " +
                                    offence.DriverDetail.DdAddress2 + ", " +
                                    offence.DriverDetail.DdAddress3 + " committed a '" +
                                    offence.ListedOffence.LoDesc + "' offence on " +
                                    offence.doOffenceDate.Day + "/" +
                                    offence.doOffenceDate.Month + "/" +
                                    offence.doOffenceDate.Year +
                                    " at " + offence.doLocation + ".\r\n";
                                //mark driver offence as deleted.
                                SetDriverOffenceDeleteStatus(offence.Id);
                            } //end if 
                }
            }//end for _driverOffenceDB
            return message;
        }
    }
}