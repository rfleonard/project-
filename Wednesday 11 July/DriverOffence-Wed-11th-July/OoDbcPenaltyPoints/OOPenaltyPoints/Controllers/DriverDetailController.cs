using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OOPenaltyPoints.Models;

namespace OOPenaltyPoints.Controllers
{ 
    public class DriverDetailController : Controller
    {
        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        //
        // GET: /DriverDetail/

        public ViewResult Index()
        {
            return View(db.DriverDetails.ToList());
        }

        //
        // GET: /DriverDetail/Details/5

        public ViewResult Details(int id)
        {
            DriverDetail driverdetail = db.DriverDetails.Find(id);
            return View(driverdetail);
        }

        //
        // GET: /DriverDetail/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /DriverDetail/Create

        [HttpPost]
        public ActionResult Create(DriverDetail driverdetail)
        {
            if (ModelState.IsValid)
            {
                db.DriverDetails.Add(driverdetail);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(driverdetail);
        }
        
        //
        // GET: /DriverDetail/Edit/5
 
        public ActionResult Edit(int id)
        {
            DriverDetail driverdetail = db.DriverDetails.Find(id);
            return View(driverdetail);
        }

        //
        // POST: /DriverDetail/Edit/5

        [HttpPost]
        public ActionResult Edit(DriverDetail driverdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driverdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driverdetail);
        }

        //
        // GET: /DriverDetail/Delete/5
 
        public ActionResult Delete(int id)
        {
            DriverDetail driverdetail = db.DriverDetails.Find(id);
            return View(driverdetail);
        }

        //
        // POST: /DriverDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            DriverDetail driverdetail = db.DriverDetails.Find(id);
            db.DriverDetails.Remove(driverdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}