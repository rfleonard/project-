using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PenaltyPointsMVC3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            //aot begin
           // Response.Redirect("/PenaltyPoints/Index");
            //aot end
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
