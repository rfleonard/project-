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

        //DbSet<DriverOffence> DriverOffences;
        //
        // GET: /Calculate/

        public ActionResult Index()
        {
            return View(db.DriverOffences.ToList());
        }

        //
        // GET: /Calculate/Details/5

        public ActionResult Details(int id = 0)
        {
            DriverOffence driveroffence = db.DriverOffences.Find(id);
            if (driveroffence == null)
            {
                return HttpNotFound();
            }
            return View(driveroffence);
        }

        //
        // GET: /Calculate/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Calculate/Create

        [HttpPost]
        public ActionResult Create(DriverOffence driveroffence)
        {
            // OOPenaltyPointsContext db = new OOPenaltyPointsContext();
            if (ModelState.IsValid)
            {
                //DriverOffence dof = new DriverOffence();
              
                //dof.doOffenceDate = System.DateTime.Now;
                //dof.doPointsApplied = 3;
                //dof.doPointsDate = System.DateTime.Now;
                //dof.doStatus = "OK";
                //db.Database.Connection.Open();
                //db.DriverOffences.Add(dof);

                db.DriverOffences.Add(driveroffence);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(driveroffence);
        }

        //
        // GET: /Calculate/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DriverOffence driveroffence = db.DriverOffences.Find(id);
            if (driveroffence == null)
            {
                return HttpNotFound();
            }
            return View(driveroffence);
        }

        //
        // POST: /Calculate/Edit/5

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
        // GET: /Calculate/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DriverOffence driveroffence = db.DriverOffences.Find(id);
            if (driveroffence == null)
            {
                return HttpNotFound();
            }
            return View(driveroffence);
        }

        //
        // POST: /Calculate/Delete/5

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
