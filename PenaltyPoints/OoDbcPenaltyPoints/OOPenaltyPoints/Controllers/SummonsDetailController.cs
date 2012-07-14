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
    public class SummonsDetailController : Controller
    {
        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        //
        // GET: /SummonsDetail/

        public ViewResult Index()
        {
            //return View(db.SummonsDetails.ToList());

            SummonsDetailDAL dal = new SummonsDetailDAL();
            List<SummonsDetail> summonsdetail = dal.ListOfSummonsDetails();
            return View(summonsdetail);
        }

        //
        // GET: /SummonsDetail/Details/5

        public ViewResult Details(int id)
        {
            //SummonsDetail summonsdetail = db.SummonsDetails.Find(id);
            //return View(summonsdetail);           
             SummonsDetailDAL dal = new SummonsDetailDAL();
             SummonsDetail summonsdetail = dal.SummonsDetailFindById(id);            
             return View(summonsdetail);
           
        }

        //
        // GET: /SummonsDetail/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /SummonsDetail/Create

        [HttpPost]
        public ActionResult Create(SummonsDetail summonsdetail)
        {
            if (ModelState.IsValid)
            {
               // db.SummonsDetails.Add(summonsdetail);
               // db.SaveChanges();
               // return RedirectToAction("Index"); 
                SummonsDetailDAL dal = new SummonsDetailDAL();
                dal.CreateSummonsDetail(summonsdetail);            
                return RedirectToAction("Index");  
            }
            return View(summonsdetail);
        }
        
        //
        // GET: /SummonsDetail/Edit/5
 
        public ActionResult Edit(int id)
        {
            //SummonsDetail summonsdetail = db.SummonsDetails.Find(id);
            //return View(summonsdetail);

            SummonsDetailDAL dal = new SummonsDetailDAL();
            SummonsDetail summonsdetail = dal.SummonsDetailFindById(id);
            return View(summonsdetail);

        }

        //
        // POST: /SummonsDetail/Edit/5

        [HttpPost]
        public ActionResult Edit(SummonsDetail summonsdetail)
        {
            if (ModelState.IsValid)
            {
                 db.Entry(summonsdetail).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");

                SummonsDetailDAL dal = new SummonsDetailDAL();               
                dal.EditSummonsDetail(summonsdetail);            
                return RedirectToAction("Index");
            }
            return View(summonsdetail);
        }

        //
        // GET: /SummonsDetail/Delete/5
 
        public ActionResult Delete(int id)
        {
            //SummonsDetail summonsdetail = db.SummonsDetails.Find(id);
            //return View(summonsdetail);

            SummonsDetailDAL dal = new SummonsDetailDAL();
            SummonsDetail summonsdetail = dal.SummonsDetailFindById(id);
            return View(summonsdetail);
        }

        //
        // POST: /SummonsDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
           // SummonsDetail summonsdetail = db.SummonsDetails.Find(id);
           // db.SummonsDetails.Remove(summonsdetail);
           // db.SaveChanges();
           // return RedirectToAction("Index");
           
            SummonsDetailDAL dal = new SummonsDetailDAL();
            SummonsDetail summonsdetail = dal.DeleteSummonsDetailById(id);            
            return RedirectToAction("Index");


        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}