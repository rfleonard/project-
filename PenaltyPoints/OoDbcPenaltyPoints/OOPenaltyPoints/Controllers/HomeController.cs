<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Web;
using System.Web.Mvc;
using OOPenaltyPoints.Models;

namespace OOPenaltyPoints.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            bool databaseExists = false;
 
           OOPenaltyPointsContext db = new OOPenaltyPointsContext();
           
            databaseExists = db.Database.Exists();

            if (databaseExists)
            {
              
                // for development purposes only
               //db.Database.Delete();
               //db.Database.Create();
 
          }
           else
          {
                db.Database.Create();


          }
            ViewBag.Message = "Motorist Penalty Points Offence System";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Web;
using System.Web.Mvc;
using OOPenaltyPoints.Models;

namespace OOPenaltyPoints.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            bool databaseExists = false;
 
           OOPenaltyPointsContext db = new OOPenaltyPointsContext();
           
            databaseExists = db.Database.Exists();

            if (databaseExists)
            {
              
                // for development purposes only
               //db.Database.Delete();
               //db.Database.Create();
 
          }
           else
          {
                db.Database.Create();


          }
            ViewBag.Message = "Motorist Penalty Points Offence System";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
>>>>>>> Added Unit Test & soa
