using System;
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
           
            PenaltyPointsDataContext db = new PenaltyPointsDataContext();
            bool dbaexists = db.DatabaseExists();
            if (!dbaexists)
            {

                db.CreateDatabase();
            }
            else
            {
                // for development purposes only
                db.DeleteDatabase();
                db.CreateDatabase();

                //OffencesHistory myoffence= new OffencesHistory();

                
                //db.SubmitChanges();
            }
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
