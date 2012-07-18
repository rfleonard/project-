using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OOPenaltyPoints.BLL;
using OOPenaltyPoints.Models;


namespace OOPenaltyPoints.Controllers
{
    public class ListedOffenceController : Controller
    {
        private ListedOffenceBLL _listedOffenceBLL = null;

        protected ListedOffenceBLL _BLL
        {
            get
            {
                if (_listedOffenceBLL == null)
                    _listedOffenceBLL = new ListedOffenceBLL();

                return _listedOffenceBLL;
            }
        }

        /// <method>
        /// GET: /ListedOffence/Index
        /// Index() returns all active offences to UI.
        /// </method>
        public ActionResult Index()
        {
            return View(_BLL.GetOffences());
        }

        /// <method>
        /// GET: /ListedOffence/Details/5
        /// Details() returns the offence specified by id from the database.
        /// </method>
        public ViewResult Details(int id)
        {
            return View(_BLL.GetOffence(id));
        }



        /// <method>
        /// Create() displays UI to create a new offence.
        /// GET: /ListedOffence/Create
        /// </method>
        public ActionResult Create()
        {
            return View();
        }

        /// <method>
        /// Create() inserts a new offence into the database.
        /// POST: /ListedOffence/Create
        /// </method>
        [HttpPost]
        public ActionResult Create(ListedOffence _newOffence)
        {
            if (ModelState.IsValid)
            {
                // model is valid, save to db
                _BLL.CreateOffence(_newOffence);
                return RedirectToAction("Index");
            }

            // model is not valid
            return View(_newOffence);
        }


        /// <method>
        /// Delete() returns offence specified by id for the UI for deletion.
        /// GET/ListedOffence/Delete/5
        /// </method>
        public ActionResult Delete(int id)
        {
            return View(_BLL.GetOffence(id));
        }

        /// <method>
        /// DeleteConfirmed() saves offence status=deleted in database.
        /// Post: /ListedOffence/Delete/5
        /// </method>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            //offences cannot be deleted from the database
            //as they are referenced in the drivingoffence table.
            //Instead an offence will have its status=false
            //so it cannot be used in new driving offences.
            //This ensures integrity within existing driving offences.
            _BLL.SetOffenceDeleteStatus(id);
            return RedirectToAction("Index"); 
        }

        /// <method>
        /// GET: /ListedOffence/Edit/5
        /// Edit() returns the offence specified by id to the UI for editing.
        /// </method>
        public ActionResult Edit(int id)
        {
            return View(_BLL.GetOffence(id));
        }

        /// <method>
        /// EditConfirmed() saves updated offence to database.
        /// POST: /ListedOffence/Edit/5
        /// </method>
        [HttpPost]
        public ActionResult Edit(ListedOffence _offence)
        {
            //offences cannot be updated as they are referenced in the driving offence table.
            //Instead a offence will be create and assiged the value of the existing offence.
            //The exiting offence will have its status set to false so it cannot be used 
            //in new driving offences but can be accessed by existing driving offences.

            if (ModelState.IsValid)
            {
                _BLL.EditOffence(_offence);
                return RedirectToAction("Index");
            }
            return View("help");
  
        }
       

    }
}
