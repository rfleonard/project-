using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//aot
using MotoristPenaltyPoints.Models;
//aot

namespace MotoristPenaltyPoints.Controllers
{
    public class ListedOffencesController : Controller
    {
        //
        // GET: /ListedOffences/

        public ActionResult Index()
        //aot begin
        {
            using (var db = new PenaltyPointsDbEntities())
            {
                return View(db.ListedOffences.ToList());
            }
        }
        //aot end

        //
        // GET: /ListedOffences/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ListedOffences/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ListedOffences/Create


        //aot begin
        [HttpPost]
        public ActionResult Create(ListedOffence listedoffence)
        {
            try
            {
                // TODO: Add insert logic here
                using (var db = new PenaltyPointsDbEntities())
                {
                    db.ListedOffences.Add(listedoffence);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //aot end

        //
        // GET: /ListedOffences/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ListedOffences/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ListedOffences/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ListedOffences/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
