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
    public class VehicleDetailController : Controller
    {
        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        //
        // GET: /VehicleDetail/

        public ViewResult Index()
        {
            //return View(db.VehicleDetails.ToList());

            VehicleDetailDAL dal = new VehicleDetailDAL();
            List<VehicleDetail> vehicledetail = dal.ListOfVehicleDetails();
            return View(vehicledetail);
        }

        //
        // GET: /VehicleDetail/Details/5

        public ViewResult Details(int id)
        {
            //VehicleDetail vehicledetail = db.VehicleDetails.Find(id);
            //return View(vehicledetail);           
            VehicleDetailDAL dal = new VehicleDetailDAL();
            VehicleDetail vehicledetail = dal.VehicleDetailFindById(id);
            return View(vehicledetail);

        }

        //
        // GET: /VehicleDetail/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /VehicleDetail/Create

        [HttpPost]
        public ActionResult Create(VehicleDetail vehicledetail)
        {
            if (ModelState.IsValid)
            {
                // db.VehicleDetails.Add(vehicledetail);
                // db.SaveChanges();
                // return RedirectToAction("Index"); 
                VehicleDetailDAL dal = new VehicleDetailDAL();
                dal.CreateVehicleDetail(vehicledetail);
                return RedirectToAction("Index");
            }
            return View(vehicledetail);
        }

        //
        // GET: /VehicleDetail/Edit/5

        public ActionResult Edit(int id)
        {
            //VehicleDetail vehicledetail = db.VehicleDetails.Find(id);
            //return View(vehicledetail);

            VehicleDetailDAL dal = new VehicleDetailDAL();
            VehicleDetail vehicledetail = dal.VehicleDetailFindById(id);
            return View(vehicledetail);

        }

        //
        // POST: /VehicleDetail/Edit/5

        [HttpPost]
        public ActionResult Edit(VehicleDetail vehicledetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicledetail).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");

                VehicleDetailDAL dal = new VehicleDetailDAL();
                dal.EditVehicleDetail(vehicledetail);
                return RedirectToAction("Index");
            }
            return View(vehicledetail);
        }

        //
        // GET: /VehicleDetail/Delete/5

        public ActionResult Delete(int id)
        {
            //VehicleDetail vehicledetail = db.VehicleDetails.Find(id);
            //return View(vehicledetail);

            VehicleDetailDAL dal = new VehicleDetailDAL();
            VehicleDetail vehicledetail = dal.VehicleDetailFindById(id);
            return View(vehicledetail);
        }

        //
        // POST: /VehicleDetail/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // VehicleDetail vehicledetail = db.VehicleDetails.Find(id);
            // db.VehicleDetails.Remove(vehicledetail);
            // db.SaveChanges();
            // return RedirectToAction("Index");

            VehicleDetailDAL dal = new VehicleDetailDAL();
            VehicleDetail vehicledetail = dal.DeleteVehicleDetailById(id);
            return RedirectToAction("Index");


        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}