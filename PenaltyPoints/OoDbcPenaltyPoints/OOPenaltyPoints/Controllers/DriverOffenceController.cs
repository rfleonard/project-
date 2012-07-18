using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OOPenaltyPoints.BLL;
using OOPenaltyPoints.Models.ViewModel;

namespace OOPenaltyPoints.Controllers
{
    public class DriverOffenceController : Controller
    {
        private DriverOffenceBLL _driverOffenceBLL = null;

        protected DriverOffenceBLL _BLL
        {
            get
            {
                if (_driverOffenceBLL == null)
                    _driverOffenceBLL = new DriverOffenceBLL();

                return _driverOffenceBLL;
            }
        }
        /// <method>
        /// GET: /DriverOffence/Index
        /// Index() returns all active offences to UI.
        /// </method>
        public ActionResult Index()
        {
            return View(_BLL.GetOffences());
        }

        /// <method>
        /// Create() displays UI to create a new driver offence.
        /// GET: /DriverOffence/Create
        /// </method>
        public ActionResult Create()
        {
            return View();
        }

        /// <method>
        /// Create() inserts a new driver offence into the database.
        /// POST: /DriverOffence/Create
        /// </method>
        [HttpPost]
        public ActionResult Create(DriverOffenceUI OffenceUI)
        {
            if (ModelState.IsValid)
            {
                // model is valid, save to db
                _BLL.CreateOffence(OffenceUI);
                return RedirectToAction("Index");
            }
            //CC- to be removed as just checking for error messages.
            foreach (var modelStateValue in ViewData.ModelState.Values)
            {
                foreach (var error in modelStateValue.Errors)
                {
                    // Do something useful with these properties
                    var errorMessage = error.ErrorMessage;
                    var exception = error.Exception;
                }
            }

            // model is not valid
            return View(OffenceUI);
        }

        /// <method>
        /// Edit() retrieves a driver offence as specifed by id from database for editing.
        /// GET: /DriverOffence/Edit/5
        /// </method>
        public ActionResult Edit(int id)
        {
            return View(_BLL.GetDriverOffence(id));
        }

        
        /// <method>
        /// Edit() saves an updated driver offence back to the database.
        /// POST: /driverOffence/Edit/5
        /// </method>
        [HttpPost]
        public ActionResult Edit(DriverOffenceUI driverOffenceUI)
        {
            if (ModelState.IsValid)
            {
                _BLL.EditDriverOffence(driverOffenceUI);
                return RedirectToAction("Index");
            }
            return View(driverOffenceUI);
        }

        /// <method>
        /// Details() retrieves a driver offence as specifed by id from database for editing.
        /// GET: /DriverOffence/Edit/5
        /// </method>
        public ActionResult Details(int id)
        {
            return View(_BLL.GetDriverOffence(id));
        }

        /// <method>
        /// Delete() retrieves a driver offence as specifed by id 
        /// from database from deletion.
        /// GET: /DriverOffence/Delete/5
        /// </method>
        public ActionResult Delete(int id)
        {
            return View(_BLL.GetDriverOffence(id));
        }

        /// <method>
        /// Delete() updates status of driving offence to 'deleted'
        /// POST: /DriverOffence/Delete/5
        /// </method
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _BLL.SetDriverOffenceDeleteStatus(id);
            return RedirectToAction("Index");
        }
    }
}
