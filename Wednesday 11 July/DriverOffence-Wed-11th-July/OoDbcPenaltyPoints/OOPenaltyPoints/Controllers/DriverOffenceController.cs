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
    public class DriverOffenceController : Controller
    {
        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        //
        // GET: /DriverOffence/

        public ViewResult Index()
        {
            return View(db.DriverOffences.ToList());
        }

        //
        // GET: /DriverOffence/Details/5

        public ViewResult Details(int id)
        {
            DriverOffence driveroffence = db.DriverOffences.Find(id);
            return View(driveroffence);
        }

        //
        // GET: /DriverOffence/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /DriverOffence/Create

        [HttpPost]
        public ActionResult Create(DriverOffence driveroffence)
        {
            if (ModelState.IsValid)
            {
                db.DriverOffences.Add(driveroffence);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(driveroffence);
        }
        
        //
        // GET: /DriverOffence/Edit/5
 
        public ActionResult Edit(int id)
        {
            DriverOffence driveroffence = db.DriverOffences.Find(id);
            return View(driveroffence);
        }

        //
        // POST: /DriverOffence/Edit/5

        [HttpPost]
        public ActionResult Edit(DriverOffence driveroffence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(driveroffence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(driveroffence);
        }

        //
        // GET: /DriverOffence/Delete/5
 
        public ActionResult Delete(int id)
        {
            DriverOffence driveroffence = db.DriverOffences.Find(id);
            return View(driveroffence);
        }

        //
        // POST: /DriverOffence/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            DriverOffence driveroffence = db.DriverOffences.Find(id);
            db.DriverOffences.Remove(driveroffence);
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