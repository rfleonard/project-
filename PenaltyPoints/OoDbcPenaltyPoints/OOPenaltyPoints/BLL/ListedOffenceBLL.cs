<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OOPenaltyPoints.DAL;
using OOPenaltyPoints.Models;
using System.Web.Mvc;

/// <summary>
/// TO DO Summary description for ListedOffenceBLL
/// </summary>
namespace OOPenaltyPoints.BLL
{
    public class ListedOffenceBLL
    {
        private ListedOffenceDAL _listedOffenceDAL = null;

        protected ListedOffenceDAL _DAL
        {
            get
            {
                if (_listedOffenceDAL == null)
                    _listedOffenceDAL = new ListedOffenceDAL();

                return _listedOffenceDAL;
            }
        }

        /// <method>
        /// GetOffences() returns a list of all active offence types in the database
        /// </method>
        public List<ListedOffence> GetOffences()
        {
            //Get penalty point offences from database
            //Iterate through the list 
            //For all offences with status=true add to _activeOffences
            //return _activeOffences
            
            List<ListedOffence> _offencesDB = _DAL.ListOfListedOffences();
            List<ListedOffence> _activeOffences = new List<ListedOffence>();

            foreach (ListedOffence offence in _offencesDB)
            {
                if (offence.LoStatus)
                    _activeOffences.Add(offence);
            }

            return _activeOffences; 
        }

        /// <method>
        /// CreateOffence() inserts a new offence object into the database
        /// </method>
        public void CreateOffence(ListedOffence _newOffence)
        {
            _newOffence.LoDateCreated = System.DateTime.Now;
            _newOffence.LoDateLastModified = System.DateTime.Now;
            _newOffence.LoStatus = true;

            //CC - To do: check if mandatoryCourtAppearance/Description is set correctly
            //because required is not working on all fields.
            if (_newOffence.LoMandatoryCourtAppearance == true)
            {
                _newOffence.Lo28Days = 0;
                //_newOffence.Lo56days = 0;
                _newOffence.LoFine28 = 0;
                _newOffence.LoFine56 = 0;
            };

            
            _DAL.CreateListedOffence(_newOffence);
        }

        /// <method>
        /// GetOffence() returns the offence specified by id from the database.
        /// </method>
        public ListedOffence GetOffence(int id)
        {
            return _DAL.ListedOffenceFindById(id);
        }
        
        /// <method>
        /// SetOffenceStatus() sets status of offence to false
        /// So it cannot be used for new offences.
        /// </method>
        public void SetOffenceDeleteStatus(int id)
        {
            //offences cannot be deleted from the database
            //as they are referenced in the drivingoffence table.
            //Instead an offence will have its status=false
            //so it cannot be used in new driving offences.
            //This ensures integrity within existing driving offences. 
            ListedOffence _offence =  _DAL.ListedOffenceFindById(id);
            _offence.LoStatus = false;
            _offence.LoDateLastModified = System.DateTime.Now;
            _DAL.EditListedOffence(_offence);
        }

        // POST: /ListedOffence/Edit/5
        public void EditOffence(ListedOffence _offence)
        {
            //offences cannot be updated as they are referenced in the driving offence table.
            //Instead a new offence will be created and assigned the updated values.
            //The existing offence status will be set to false so it cannot be used 
            //in new driving offences but can be accessed by existing driving offences.

            //create new offence
            ListedOffence _newOffence = new ListedOffence();
            //get existing offence from database
            ListedOffence _updatedOffence = _DAL.ListedOffenceFindById(_offence.Id);

            //assign new offence updated values of existing offence
            _newOffence.LoDesc = _offence.LoDesc.ToString();
            _newOffence.Lo28Days = _offence.Lo28Days;
            _newOffence.Lo56days = _offence.Lo56days;
            _newOffence.LoFine28 = _offence.LoFine28;
            _newOffence.LoFine56 = _offence.LoFine56;
            _newOffence.LoMandatoryCourtAppearance = _offence.LoMandatoryCourtAppearance;
            _newOffence.LoStatus = true;
            _newOffence.LoDateCreated = _offence.LoDateCreated;
            _newOffence.LoDateLastModified = System.DateTime.Now;
            //add new offence to database
            _DAL.CreateListedOffence(_newOffence);

            //Update status of existing offence to false 
            //so it is not accessable to new driver offences
            //but is available to existing driver offences.
            _updatedOffence.LoStatus = false;
            _updatedOffence.LoDateLastModified = System.DateTime.Now;
            //Update database record of existing offence
            _DAL.EditListedOffence(_updatedOffence);
        
        }

        public List<SelectListItem> GetOffenceDescription()
        {
            //Define a offence description list
            List<SelectListItem> doDescription = new List<SelectListItem>();
            List<ListedOffence> listedOffences = GetOffences();


            //bool selectFirst = true;
            foreach (ListedOffence offence in listedOffences)
            {
                    doDescription.Add(new SelectListItem
                    {
                        Text = offence.LoDesc,
                        Value = offence.LoDesc
                    });
            }
            return doDescription;
        }
    } //End ListedOffenceBLL
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OOPenaltyPoints.DAL;
using OOPenaltyPoints.Models;
using System.Web.Mvc;

/// <summary>
/// TO DO Summary description for ListedOffenceBLL
/// </summary>
namespace OOPenaltyPoints.BLL
{
    public class ListedOffenceBLL
    {
        private ListedOffenceDAL _listedOffenceDAL = null;

        protected ListedOffenceDAL _DAL
        {
            get
            {
                if (_listedOffenceDAL == null)
                    _listedOffenceDAL = new ListedOffenceDAL();

                return _listedOffenceDAL;
            }
        }

        /// <method>
        /// GetOffences() returns a list of all active offence types in the database
        /// </method>
        public List<ListedOffence> GetOffences()
        {
            //Get penalty point offences from database
            //Iterate through the list 
            //For all offences with status=true add to _activeOffences
            //return _activeOffences
            
            List<ListedOffence> _offencesDB = _DAL.ListOfListedOffences();
            List<ListedOffence> _activeOffences = new List<ListedOffence>();

            foreach (ListedOffence offence in _offencesDB)
            {
                if (offence.LoStatus)
                    _activeOffences.Add(offence);
            }

            return _activeOffences; 
        }

        /// <method>
        /// CreateOffence() inserts a new offence object into the database
        /// </method>
        public void CreateOffence(ListedOffence _newOffence)
        {
            _newOffence.LoDateCreated = System.DateTime.Now;
            _newOffence.LoDateLastModified = System.DateTime.Now;
            _newOffence.LoStatus = true;

            //CC - To do: check if mandatoryCourtAppearance/Description is set correctly
            //because required is not working on all fields.
            if (_newOffence.LoMandatoryCourtAppearance == true)
            {
                _newOffence.Lo28Days = 0;
                //_newOffence.Lo56days = 0;
                _newOffence.LoFine28 = 0;
                _newOffence.LoFine56 = 0;
            };

            
            _DAL.CreateListedOffence(_newOffence);
        }

        /// <method>
        /// GetOffence() returns the offence specified by id from the database.
        /// </method>
        public ListedOffence GetOffence(int id)
        {
            return _DAL.ListedOffenceFindById(id);
        }
        
        /// <method>
        /// SetOffenceStatus() sets status of offence to false
        /// So it cannot be used for new offences.
        /// </method>
        public void SetOffenceDeleteStatus(int id)
        {
            //offences cannot be deleted from the database
            //as they are referenced in the drivingoffence table.
            //Instead an offence will have its status=false
            //so it cannot be used in new driving offences.
            //This ensures integrity within existing driving offences. 
            ListedOffence _offence =  _DAL.ListedOffenceFindById(id);
            _offence.LoStatus = false;
            _offence.LoDateLastModified = System.DateTime.Now;
            _DAL.EditListedOffence(_offence);
        }

        // POST: /ListedOffence/Edit/5
        public void EditOffence(ListedOffence _offence)
        {
            //offences cannot be updated as they are referenced in the driving offence table.
            //Instead a offence will be create and assiged the value of the existing offence.
            //The exiting offence will have its status set to false so it cannot be used 
            //in new driving offences but can be accessed by existing driving offences.

            ListedOffence _newOffence = new ListedOffence();

            _offence.LoStatus = false;
            _offence.LoDateLastModified = System.DateTime.Now;
            _newOffence.LoDesc = _offence.LoDesc.ToString();
            _newOffence.Lo28Days = _offence.Lo28Days;
            _newOffence.Lo56days = _offence.Lo56days;
            _newOffence.LoFine28 = _offence.LoFine28;
            _newOffence.LoFine56 = _offence.LoFine56;
            _newOffence.LoMandatoryCourtAppearance = _offence.LoMandatoryCourtAppearance;
            _newOffence.LoStatus = true;
            _newOffence.LoDateCreated = _offence.LoDateCreated;
            _newOffence.LoDateLastModified = System.DateTime.Now;

            _DAL.EditListedOffence(_offence);
            _DAL.CreateListedOffence(_newOffence);
        
        }

        public List<SelectListItem> GetOffenceDescription()
        {
            //Define a offence description list
            List<SelectListItem> doDescription = new List<SelectListItem>();
            List<ListedOffence> listedOffences = GetOffences();


            //bool selectFirst = true;
            foreach (ListedOffence offence in listedOffences)
            {
                    doDescription.Add(new SelectListItem
                    {
                        Text = offence.LoDesc,
                        Value = offence.LoDesc
                    });
            }
            return doDescription;
        }
    } //End ListedOffenceBLL
>>>>>>> Added Unit Test & soa
}