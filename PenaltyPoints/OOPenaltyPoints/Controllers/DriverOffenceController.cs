using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Web;
using System.Web.Mvc;
using OOPenaltyPoints.BLL;
using OOPenaltyPoints.Models.ViewModel;
using OOPenaltyPoints.Models;

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
        [Authorize(Roles = "Super, Worker")]
        public ActionResult Index()
        {
            return View(_BLL.GetOffences());
        }

        /// <method>
        /// Create() displays UI to create a new driver offence.
        /// GET: /DriverOffence/Create
        /// </method>
        [Authorize(Roles = "Super, Worker")]
        public ActionResult Create()
        {
            List<SelectListItem> doStatus = new List<SelectListItem>();
            List<SelectListItem> licenceStatus = new List<SelectListItem>();
            List<SelectListItem> County = new List<SelectListItem>();
            List<SelectListItem> doDescription = new List<SelectListItem>();

            //Define a driver offence status list
            doStatus.Add(new SelectListItem
            {
                Text = "New Offence",
                Value = "New Offence",
                Selected = true
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Penalty Notification",
                Value = "Penalty Notification"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "28 Days Notification",
                Value = "28 Days Notification"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Court Summons",
                Value = "Court Summons"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Fine Paid",
                Value = "Fine Paid"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Deleted",
                Value = "Deleted"
            });
           
            //Define a driver licence status list
            licenceStatus.Add(new SelectListItem
            {
                Text = "Full Licence",
                Value = "Full Licence",
                Selected = true
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "Provisional Licence",
                Value = "Provisional Licence"
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "Disqualified",
                Value = "Disqualified"
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "No Valid Licence",
                Value = "No Valid Licence"
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "Other",
                Value = "Other"
            });

            //Define a county name list
            County.Add(new SelectListItem
            {
                Text = "Carlow",
                Value = "Carlow"
            });
            County.Add(new SelectListItem
            {
                Text = "Cavan",
                Value = "Cavan"
            });
            County.Add(new SelectListItem
            {
                Text = "Clare",
                Value = "Clare"
            });
            County.Add(new SelectListItem
            {
                Text = "Cork",
                Value = "Cork"
            });
            County.Add(new SelectListItem
            {
                Text = "Donegal",
                Value = "Donegal"
            });
            County.Add(new SelectListItem
            {
                Text = "Dublin",
                Value = "Dublin"
            });
            County.Add(new SelectListItem
            {
                Text = "Galway",
                Value = "Galway",
                Selected = true
            });
            County.Add(new SelectListItem
            {
                Text = "Kerry",
                Value = "Kerry"
            });
            County.Add(new SelectListItem
            {
                Text = "Kildare",
                Value = "Kildare"
            });
            County.Add(new SelectListItem
            {
                Text = "Kilkenny",
                Value = "Kilkenny"
            });
            County.Add(new SelectListItem
            {
                Text = "Laois",
                Value = "Laois"
            });
            County.Add(new SelectListItem
            {
                Text = "Leitrim",
                Value = "Leitrim"
            });
            County.Add(new SelectListItem
            {
                Text = "Limerick",
                Value = "Limerick"
            });
            County.Add(new SelectListItem
            {
                Text = "Longford",
                Value = "Longford"
            });
            County.Add(new SelectListItem
            {
                Text = "Louth",
                Value = "Louth"
            });
            County.Add(new SelectListItem
            {
                Text = "Mayo",
                Value = "Mayo"
            });
            County.Add(new SelectListItem
            {
                Text = "Meath",
                Value = "Meath"
            });
            County.Add(new SelectListItem
            {
                Text = "Monaghan",
                Value = "Monaghan"
            });
            County.Add(new SelectListItem
            {
                Text = "Offaly",
                Value = "Offaly"
            });
            County.Add(new SelectListItem
            {
                Text = "Roscommon",
                Value = "Roscommon"
            });
            County.Add(new SelectListItem
            {
                Text = "Sligo",
                Value = "Sligo"
            });
            County.Add(new SelectListItem
            {
                Text = "Tipperary",
                Value = "Tipperary"
            });
            County.Add(new SelectListItem
            {
                Text = "Waterford",
                Value = "Waterford"
            });
            County.Add(new SelectListItem
            {
                Text = "Westmeath",
                Value = "Westmeath"
            });
            County.Add(new SelectListItem
            {
                Text = "Wexford",
                Value = "Wexford"
            });
            County.Add(new SelectListItem
            {
                Text = "Wicklow",
                Value = "Wicklow"
            });
            County.Add(new SelectListItem
            {
                Text = "Other",
                Value = "Other"
            });

            //Define a offence description list
            ListedOffenceBLL listedOffenceBLL = new ListedOffenceBLL();
            doDescription = listedOffenceBLL.GetOffenceDescription();

            ViewData["doDescription"] = new SelectList(doDescription, "Value", "Text");
            ViewData["doStatus"] = new SelectList(doStatus, "Value", "Text");
            ViewData["licenceStatus"] = new SelectList(licenceStatus, "Value", "Text");
            ViewData["County"] = new SelectList(County, "Value", "Text");
            return View();
        }

        /// <method>
        /// Create() inserts a new driver offence into the database.
        /// POST: /DriverOffence/Create
        /// </method>
        [HttpPost]
        public ActionResult Create(DriverOffenceUI OffenceUI)
        {
            List<SelectListItem> doDescription = new List<SelectListItem>();
            ListedOffenceBLL listedOffenceBLL = new ListedOffenceBLL();
            doDescription = listedOffenceBLL.GetOffenceDescription();
            ViewData["doDescription"] = new SelectList(doDescription, "Value", "Text");
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
        [Authorize(Roles = "Super, Worker")]
        public ActionResult Edit(int id)
        {
            List<SelectListItem> doStatus = new List<SelectListItem>();
            List<SelectListItem> licenceStatus = new List<SelectListItem>();
            List<SelectListItem> County = new List<SelectListItem>();
            //Define a driver offence status list
            doStatus.Add(new SelectListItem
            {
                Text = "New Offence",
                Value = "New Offence",
                Selected = true
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Penalty Notification",
                Value = "Penalty Notification"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "28 Days Notification",
                Value = "28 Days Notification"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Court Summons",
                Value = "Court Summons"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Fine Paid",
                Value = "Fine Paid"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Deleted",
                Value = "Deleted"
            });

            //Define a driver licence status list
            licenceStatus.Add(new SelectListItem
            {
                Text = "Full Licence",
                Value = "Full Licence",
                Selected = true
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "Provisional Licence",
                Value = "Provisional Licence"
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "Disqualified",
                Value = "Disqualified"
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "No Valid Licence",
                Value = "No Valid Licence"
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "Other",
                Value = "Other"
            });

            //Define a county name list
            County.Add(new SelectListItem
            {
                Text = "Carlow",
                Value = "Carlow"
            });
            County.Add(new SelectListItem
            {
                Text = "Cavan",
                Value = "Cavan"
            });
            County.Add(new SelectListItem
            {
                Text = "Clare",
                Value = "Clare"
            });
            County.Add(new SelectListItem
            {
                Text = "Cork",
                Value = "Cork"
            });
            County.Add(new SelectListItem
            {
                Text = "Donegal",
                Value = "Donegal"
            });
            County.Add(new SelectListItem
            {
                Text = "Dublin",
                Value = "Dublin"
            });
            County.Add(new SelectListItem
            {
                Text = "Galway",
                Value = "Galway",
                Selected = true
            });
            County.Add(new SelectListItem
            {
                Text = "Kerry",
                Value = "Kerry"
            });
            County.Add(new SelectListItem
            {
                Text = "Kildare",
                Value = "Kildare"
            });
            County.Add(new SelectListItem
            {
                Text = "Kilkenny",
                Value = "Kilkenny"
            });
            County.Add(new SelectListItem
            {
                Text = "Laois",
                Value = "Laois"
            });
            County.Add(new SelectListItem
            {
                Text = "Leitrim",
                Value = "Leitrim"
            });
            County.Add(new SelectListItem
            {
                Text = "Limerick",
                Value = "Limerick"
            });
            County.Add(new SelectListItem
            {
                Text = "Longford",
                Value = "Longford"
            });
            County.Add(new SelectListItem
            {
                Text = "Louth",
                Value = "Louth"
            });
            County.Add(new SelectListItem
            {
                Text = "Mayo",
                Value = "Mayo"
            });
            County.Add(new SelectListItem
            {
                Text = "Meath",
                Value = "Meath"
            });
            County.Add(new SelectListItem
            {
                Text = "Monaghan",
                Value = "Monaghan"
            });
            County.Add(new SelectListItem
            {
                Text = "Offaly",
                Value = "Offaly"
            });
            County.Add(new SelectListItem
            {
                Text = "Roscommon",
                Value = "Roscommon"
            });
            County.Add(new SelectListItem
            {
                Text = "Sligo",
                Value = "Sligo"
            });
            County.Add(new SelectListItem
            {
                Text = "Tipperary",
                Value = "Tipperary"
            });
            County.Add(new SelectListItem
            {
                Text = "Waterford",
                Value = "Waterford"
            });
            County.Add(new SelectListItem
            {
                Text = "Westmeath",
                Value = "Westmeath"
            });
            County.Add(new SelectListItem
            {
                Text = "Wexford",
                Value = "Wexford"
            });
            County.Add(new SelectListItem
            {
                Text = "Wicklow",
                Value = "Wicklow"
            });
            County.Add(new SelectListItem
            {
                Text = "Other",
                Value = "Other"
            });

            DriverOffenceUI driver = _BLL.GetDriverOffence(id);
            ViewData["doStatus"] = new SelectList(doStatus, "Value", "Text", driver.status.ToString());
            ViewData["licenceStatus"] = new SelectList(licenceStatus, "Value", "Text", driver.LicenceStatus.ToString());
            ViewData["County"] = new SelectList(County, "Value", "Text", driver.Address3.ToString());
            return View(driver);
        }

        
        /// <method>
        /// Edit() saves an updated driver offence back to the database.
        /// POST: /driverOffence/Edit/5
        /// </method>
        [HttpPost]
        public ActionResult Edit(DriverOffenceUI driverOffenceUI)
        {
            List<SelectListItem> doStatus = new List<SelectListItem>();
            List<SelectListItem> licenceStatus = new List<SelectListItem>();
            List<SelectListItem> County = new List<SelectListItem>();
            //Define a driver offence status list
            doStatus.Add(new SelectListItem
            {
                Text = "New Offence",
                Value = "New Offence",
                Selected = true
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Penalty Notification",
                Value = "Penalty Notification"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "28 Days Notification",
                Value = "28 Days Notification"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Court Summons",
                Value = "Court Summons"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Fine Paid",
                Value = "Fine Paid"
            });
            doStatus.Add(new SelectListItem
            {
                Text = "Deleted",
                Value = "Deleted"
            });

            //Define a driver licence status list
            licenceStatus.Add(new SelectListItem
            {
                Text = "Full Licence",
                Value = "Full Licence",
                Selected = true
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "Provisional Licence",
                Value = "Provisional Licence"
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "Disqualified",
                Value = "Disqualified"
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "No Valid Licence",
                Value = "No Valid Licence"
            });
            licenceStatus.Add(new SelectListItem
            {
                Text = "Other",
                Value = "Other"
            });

            //Define a county name list
            County.Add(new SelectListItem
            {
                Text = "Carlow",
                Value = "Carlow"
            });
            County.Add(new SelectListItem
            {
                Text = "Cavan",
                Value = "Cavan"
            });
            County.Add(new SelectListItem
            {
                Text = "Clare",
                Value = "Clare"
            });
            County.Add(new SelectListItem
            {
                Text = "Cork",
                Value = "Cork"
            });
            County.Add(new SelectListItem
            {
                Text = "Donegal",
                Value = "Donegal"
            });
            County.Add(new SelectListItem
            {
                Text = "Dublin",
                Value = "Dublin"
            });
            County.Add(new SelectListItem
            {
                Text = "Galway",
                Value = "Galway",
                Selected = true
            });
            County.Add(new SelectListItem
            {
                Text = "Kerry",
                Value = "Kerry"
            });
            County.Add(new SelectListItem
            {
                Text = "Kildare",
                Value = "Kildare"
            });
            County.Add(new SelectListItem
            {
                Text = "Kilkenny",
                Value = "Kilkenny"
            });
            County.Add(new SelectListItem
            {
                Text = "Laois",
                Value = "Laois"
            });
            County.Add(new SelectListItem
            {
                Text = "Leitrim",
                Value = "Leitrim"
            });
            County.Add(new SelectListItem
            {
                Text = "Limerick",
                Value = "Limerick"
            });
            County.Add(new SelectListItem
            {
                Text = "Longford",
                Value = "Longford"
            });
            County.Add(new SelectListItem
            {
                Text = "Louth",
                Value = "Louth"
            });
            County.Add(new SelectListItem
            {
                Text = "Mayo",
                Value = "Mayo"
            });
            County.Add(new SelectListItem
            {
                Text = "Meath",
                Value = "Meath"
            });
            County.Add(new SelectListItem
            {
                Text = "Monaghan",
                Value = "Monaghan"
            });
            County.Add(new SelectListItem
            {
                Text = "Offaly",
                Value = "Offaly"
            });
            County.Add(new SelectListItem
            {
                Text = "Roscommon",
                Value = "Roscommon"
            });
            County.Add(new SelectListItem
            {
                Text = "Sligo",
                Value = "Sligo"
            });
            County.Add(new SelectListItem
            {
                Text = "Tipperary",
                Value = "Tipperary"
            });
            County.Add(new SelectListItem
            {
                Text = "Waterford",
                Value = "Waterford"
            });
            County.Add(new SelectListItem
            {
                Text = "Westmeath",
                Value = "Westmeath"
            });
            County.Add(new SelectListItem
            {
                Text = "Wexford",
                Value = "Wexford"
            });
            County.Add(new SelectListItem
            {
                Text = "Wicklow",
                Value = "Wicklow"
            });
            County.Add(new SelectListItem
            {
                Text = "Other",
                Value = "Other"
            });

            ViewData["doStatus"] = new SelectList(doStatus, "Value", "Text");
            ViewData["licenceStatus"] = new SelectList(licenceStatus, "Value", "Text");
            ViewData["County"] = new SelectList(County, "Value", "Text");
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
        [Authorize(Roles = "Super, Worker")]
        public ActionResult Details(int id)
        {
            return View(_BLL.GetDriverOffence(id));
        }

        /// <method>
        /// Delete() retrieves a driver offence as specifed by id 
        /// from database from deletion.
        /// GET: /DriverOffence/Delete/5
        /// </method>
        [Authorize(Roles = "Super, Worker")]
        public ActionResult Delete(int id)
        {
            return View(_BLL.GetDriverOffence(id));
        }

        /// <method>
        /// Delete() updates status of driving offence to 'deleted'
        /// POST: /DriverOffence/Delete/5
        /// </method>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _BLL.SetDriverOffenceDeleteStatus(id);
            return RedirectToAction("Index");
        }

        /// <method>
        /// Search() displays search screen
        /// GET: /DriverOffence/Search/
        /// </method>
        public ActionResult Search()
        {
            SearchDriverOffenceUI searchCriteria = new SearchDriverOffenceUI();
            //Define a offence description list
            List<SelectListItem> doDescription = new List<SelectListItem>();
            ListedOffenceBLL listedOffenceBLL = new ListedOffenceBLL();
            doDescription = listedOffenceBLL.GetOffenceDescription();
            doDescription.Add(new SelectListItem
            {
                Text = "(None)",
                Value = "(None)",
                Selected = true
            });
            ViewData["doDescription"] = new SelectList(doDescription, "Value", "Text");

            //Define a vehicle registration list
            List<SelectListItem> vehicleRegs = new List<SelectListItem>();
            VehicleDetailBLL vehicleDetailBLL = new VehicleDetailBLL();
            vehicleRegs = vehicleDetailBLL.GetVehicleRegs();
            ViewData["vehicleRegs"] = new SelectList(vehicleRegs, "Value", "Text");

            //Define a driver licence number list
            List<SelectListItem> licences = new List<SelectListItem>();
            DriverDetailBLL driverDetailBLL = new DriverDetailBLL();
            licences = driverDetailBLL.GetDriverLicences();
            ViewData["driverLicences"] = new SelectList(licences, "Value", "Text");

            
            return View();
        }


        /// <method>
        /// Search() displays all driver offences matching search criteria
        /// Get: /driverOffence/Search/{search_criteria}
        /// </method>
        [HttpPost]
        public ActionResult Search(SearchDriverOffenceUI searchCriteria)
        {
            if (ModelState.IsValid)
            {
                //1. Search by offence Type only
                if (searchCriteria.LicenceNo == "(None)" && searchCriteria.Registration == "(None)" &&
                    searchCriteria.description != "(None)")
                    return RedirectToAction ("SearchComplete", new { index = 1, licenceNo = searchCriteria.LicenceNo,
                        registration = searchCriteria.Registration, description = searchCriteria.description });
                //2. Search by vehicle registration only
                else if (searchCriteria.LicenceNo == "(None)" && searchCriteria.Registration != "(None)" &&
                    searchCriteria.description == "(None)")
                    return RedirectToAction("SearchComplete", new { index = 2, licenceNo = searchCriteria.LicenceNo,
                        registration = searchCriteria.Registration, description = searchCriteria.description });
                //3. Search by driver licence number only
                else if (searchCriteria.LicenceNo != "(None)" && searchCriteria.Registration == "(None)" &&
                    searchCriteria.description == "(None)")
                    return RedirectToAction("SearchComplete", new { index = 3, licenceNo = searchCriteria.LicenceNo,
                        registration = searchCriteria.Registration, description = searchCriteria.description });
                //4. Search by driver licence number, vehicle registration and offence type
                else if (searchCriteria.LicenceNo != "(None)" && searchCriteria.Registration != "(None)" &&
                    searchCriteria.description != "(None)")
                    return RedirectToAction("SearchComplete", new { index = 4, licenceNo = searchCriteria.LicenceNo,
                        registration = searchCriteria.Registration, description = searchCriteria.description });
                //5. Search by driver licence number and vehicle registration
                else if (searchCriteria.LicenceNo != "(None)" && searchCriteria.Registration != "(None)" &&
                    searchCriteria.description == "(None)")
                    return RedirectToAction("SearchComplete", new { index = 5, licenceNo = searchCriteria.LicenceNo,
                        registration = searchCriteria.Registration, description = searchCriteria.description });
                //6. Search by driver licence number and offence type
                else if (searchCriteria.LicenceNo != "(None)" && searchCriteria.Registration == "(None)" &&
                    searchCriteria.description != "(None)")
                    return RedirectToAction("SearchComplete", new { index = 6, licenceNo = searchCriteria.LicenceNo,
                        registration = searchCriteria.Registration, description = searchCriteria.description });
                //7. Search by driver vehicle registration and offence type
                else if (searchCriteria.LicenceNo == "(None)" && searchCriteria.Registration != "(None)" &&
                    searchCriteria.description != "(None)")
                    return RedirectToAction("SearchComplete", new { index = 7, licenceNo = searchCriteria.LicenceNo,
                        registration = searchCriteria.Registration, description = searchCriteria.description });
                //7. No search criteria is empty
                else 
                    return RedirectToAction("SearchComplete", new { index = 8,  licenceNo = searchCriteria.LicenceNo,
                        registration = searchCriteria.Registration, description = searchCriteria.description });
            }
            return View();
        }

        ///<method>
        /// SearchComplete() returns and displays 
        /// all offences belonging to the specified search criteria
        /// GET: /DriverOffence/SearchComplete/{driveroffences}
        /// </method>
        public ActionResult SearchComplete(int index, string licenceNo, string registration, string description)
        {
            List<GetDriverOffenceUI> _offenceUI = new List<GetDriverOffenceUI>();
            if (index == 1)
                return View(_BLL.SearchByOffenceType(description));
            else if (index == 2)
                return View(_BLL.SearchByRegistration(registration));
            else if (index == 3)
                return View(_BLL.SearchByDriver(licenceNo));
            else if (index == 4)
                return View(_BLL.SearchByDVO(licenceNo, registration, description));
            else if (index == 5)
                return View(_BLL.SearchByDV(licenceNo, registration));
            else if (index == 6)
                return View(_BLL.SearchByDO(licenceNo, description));
            else if (index == 7)
                return View(_BLL.SearchByVO(registration, description));
            else if (index == 8)
                return View(_offenceUI);

            return View();
        }

        /// <method>
        /// Statistics() displays statistics screen
        /// GET: /DriverOffence/Statistics
        /// </method>
        public ActionResult Statistics()
        {
            //Define a stats report list
            List<SelectListItem> doStats = new List<SelectListItem>();
            StatisticsUI statisticsUI = new StatisticsUI
             {
                Name = "(None)"
             };


            doStats.Add(new SelectListItem
            {
                Text = "Penalty Points by Offence Type",
                Value = "Offence",
                Selected = true
            });
            doStats.Add(new SelectListItem
            {
                Text = "Penalty Points Incurred Per Driver Per County",
                Value = "Driver"
            });
            doStats.Add(new SelectListItem
            {
                Text = "Number of Drivers by Licence Type",
                Value = "Licence"
            });

            ViewData["doStats"] = new SelectList(doStats, "Value", "Text");

            return View(statisticsUI);
        }

        /// <method>
        /// Statistics() returns statistics view required.
        /// Get: /driverOffence/Statistics/{statistics_view}
        /// </method>
        [HttpPost]
        public ActionResult Statistics(StatisticsUI statisticsUI)
        {
            if (ModelState.IsValid)
            {
                //1. View statistics for 'Penalty Points by Offence Type'
                if (statisticsUI.Name == "Offence")
                    return RedirectToAction("StatisticsComplete", new
                    {
                        index = 1
                    });
                //2. View statistics for 'Penalty Points Incurred Per Driver'
                else if (statisticsUI.Name == "Driver")
                    return RedirectToAction("StatisticsComplete", new
                    {
                        index = 2
                    });
                //3. View statistics for 'Number of Drivers by Licence Type'
                else if (statisticsUI.Name == "Licence")
                    return RedirectToAction("StatisticsComplete", new
                    {
                        index = 3
                    });
                //4. Statistics view not specified
                else
                        return RedirectToAction("StatsticsComplete", new
                        {
                            index = 4
                        });
 
            }
            return View();
        }

        ///<method>
        /// StatisticsComplete() returns and displays 
        /// all statistics belonging to the specified statistics view
        /// GET: /DriverOffence/StatisticsComplete/{index}
        /// </method>
        public ActionResult StatisticsComplete(int index)
        {
            string message = "No Statistics Available.";
            if (index == 1)
                message = _BLL.StatisticsOffence();
            else if (index == 2)
                message = _BLL.StatisticsDriver();
            else if (index == 3)
                message = _BLL.StatisticsLicence();
            else if (index == 4)
                return View(message);

            ViewBag.MultilineRaw = message;
            List<string> eachLine = message.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            ViewBag.MultilineSplitted = eachLine;
            return View();
        }


        /// <method>
        /// DailyTasks() displays daily task screen
        /// GET: /DriverOffence/DailyTasks
        /// </method>
         [Authorize(Roles = "Super, Admin")]
        public ActionResult DailyTasks()
        {
            //Define a stats report list
            List<SelectListItem> doDailyTasks = new List<SelectListItem>();
            DailyTasksUI dailyTasksUI = new DailyTasksUI()
            {
                Name = "(None)"
            };

            doDailyTasks.Add(new SelectListItem
            {
                Text = "Penalty Point New Offence Notification",
                Value = "NewOffence",
                Selected = true
            });
            doDailyTasks.Add(new SelectListItem
            {
                Text = "Penalty Points 28 Days Notification",
                Value = "28Days"
            });
            doDailyTasks.Add(new SelectListItem
            {
                Text = "Penalty Points 56 Days Notification",
                Value = "56Days"
            });
            doDailyTasks.Add(new SelectListItem
            {
                Text = "12 Point Licence Disqualification Notification",
                Value = "Disqualification"
            });
            doDailyTasks.Add(new SelectListItem
            {
                Text = "3 Year Penalty Point Deletion Notification",
                Value = "3YearDelete"
            });

            ViewData["doDailyTasks"] = new SelectList(doDailyTasks, "Value", "Text");

            return View(dailyTasksUI);
        }


        /// <method>
        /// Statistics() returns daily task required.
        /// Get: /driverOffence/DailyTasks/{dailyTask}
        /// </method>
        [HttpPost]
        public ActionResult DailyTasks(DailyTasksUI dailyTasksUI)
        {
            if (ModelState.IsValid)
            {
                //1. Run Daily Task 'Penalty Point New Offence Notification'
                if (dailyTasksUI.Name == "NewOffence")
                    return RedirectToAction("DailyTasksComplete", new
                    {
                        index = 1
                    });
                //2. Run Daily Task 'Penalty Points 28 Days Notification'
                else if (dailyTasksUI.Name == "28Days")
                    return RedirectToAction("DailyTasksComplete", new
                    {
                        index = 2
                    });
                //3. Run Daily Task 'Penalty Points 56 Days Notification'
                else if (dailyTasksUI.Name == "56Days")
                    return RedirectToAction("DailyTasksComplete", new
                    {
                        index = 3
                    });
                //4. Run Daily Task '12 Point Licence Disqualification Notification'
                if (dailyTasksUI.Name == "Disqualification")
                    return RedirectToAction("DailyTasksComplete", new
                    {
                        index = 4
                    });
                //5. Run Daily Task '3 Year Penalty Point Deletion Notification'
                else if (dailyTasksUI.Name == "3YearDelete")
                    return RedirectToAction("DailyTasksComplete", new
                    {
                        index = 5
                    });
                //6. Daily Task not specified
                else
                    return RedirectToAction("DailyTasksComplete", new
                    {
                        index = 6
                    });

            }
            return View();
        }

        ///<method>
        /// DailyTasksComplete() returns confirmation the 
        /// daily task was run.
        /// GET: /DriverOffence/DailyTasksComplete/{index}
        /// </method>
        public ActionResult DailyTasksComplete(int index)
        {
            string message = "No Noification Required";
            if (index == 1)
                message =  _BLL.NewOffenceNotification();
            else if (index == 2)
               message = _BLL.A28DaysNotification();
            else if (index == 3)
                message = _BLL.A56DayNotification();
            else if (index == 4)
                message = _BLL.DisqualificationNotification();
            else if (index == 5)
                message = _BLL.A3YearDeleteNotification();

            ViewBag.MultilineRaw = message;
            List<string> eachLine = message.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            ViewBag.MultilineSplitted = eachLine;
            return View();
        }
    }
}
