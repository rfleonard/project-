using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OOPenaltyPoints.Models;
using OOPenaltyPoints.DAL;

namespace OOPenaltyPoints.Controllers
{ 
    public class ListedOffenceController : Controller
    {
        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        //
        // GET: /ListedOffence/

        public ViewResult Index()
        {
            //return View(db.ListedOffences.ToList());

            ListedOffenceDAL dal = new ListedOffenceDAL();
            List<ListedOffence> listedoffence = dal.ListOfListedOffences();
            return View(listedoffence);
        }

        //
        // GET: /ListedOffence/Details/5

        public ViewResult Details(int id)
        {
            //ListedOffence listedoffence = db.ListedOffences.Find(id);
            //return View(listedoffence);           
             ListedOffenceDAL dal = new ListedOffenceDAL();
             ListedOffence listedoffence = dal.ListedOffenceFindById(id);            
             return View(listedoffence);
           
        }

        //
        // GET: /ListedOffence/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ListedOffence/Create

        [HttpPost]
        public ActionResult Create(ListedOffence listedoffence)
        {
            if (ModelState.IsValid)
            {
               // db.ListedOffences.Add(listedoffence);
               // db.SaveChanges();
               // return RedirectToAction("Index"); 
                ListedOffenceDAL dal = new ListedOffenceDAL();
                dal.CreateListedOffence(listedoffence);            
                return RedirectToAction("Index");  
            }
            return View(listedoffence);
        }
        
        //
        // GET: /ListedOffence/Edit/5
 
        public ActionResult Edit(int id)
        {
            //ListedOffence listedoffence = db.ListedOffences.Find(id);
            //return View(listedoffence);

            ListedOffenceDAL dal = new ListedOffenceDAL();
            ListedOffence listedoffence = dal.ListedOffenceFindById(id);
            return View(listedoffence);

        }

        //
        // POST: /ListedOffence/Edit/5

        [HttpPost]
        public ActionResult Edit(ListedOffence listedoffence)
        {
            if (ModelState.IsValid)
            {
                 db.Entry(listedoffence).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");

                ListedOffenceDAL dal = new ListedOffenceDAL();               
                dal.EditListedOffence(listedoffence);            
                return RedirectToAction("Index");
            }
            return View(listedoffence);
        }

        //
        // GET: /ListedOffence/Delete/5
 
        public ActionResult Delete(int id)
        {
            //ListedOffence listedoffence = db.ListedOffences.Find(id);
            //return View(listedoffence);

            ListedOffenceDAL dal = new ListedOffenceDAL();
            ListedOffence listedoffence = dal.ListedOffenceFindById(id);
            return View(listedoffence);
        }

        //
        // POST: /ListedOffence/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
           // ListedOffence listedoffence = db.ListedOffences.Find(id);
           // db.ListedOffences.Remove(listedoffence);
           // db.SaveChanges();
           // return RedirectToAction("Index");
           
            ListedOffenceDAL dal = new ListedOffenceDAL();
            ListedOffence listedoffence = dal.DeleteListedOffenceById(id);            
            return RedirectToAction("Index");


        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}