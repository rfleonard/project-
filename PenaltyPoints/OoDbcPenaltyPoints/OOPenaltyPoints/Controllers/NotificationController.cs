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
    public class NotificationController : Controller
    {
        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        //
        // GET: /Notification/

        public ViewResult Index()
        {
            //return View(db.Notifications.ToList());

            NotificationDAL dal = new NotificationDAL();
            List<Notification> notification = dal.ListOfNotifications();
            return View(notification);
        }

        //
        // GET: /Notification/Details/5

        public ViewResult Details(int id)
        {
            //Notification notification = db.Notifications.Find(id);
            //return View(notification);           
            NotificationDAL dal = new NotificationDAL();
            Notification notification = dal.NotificationFindById(id);
            return View(notification);

        }

        //
        // GET: /Notification/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Notification/Create

        [HttpPost]
        public ActionResult Create(Notification notification)
        {
            if (ModelState.IsValid)
            {
                // db.Notifications.Add(notification);
                // db.SaveChanges();
                // return RedirectToAction("Index"); 
                NotificationDAL dal = new NotificationDAL();
                dal.CreateNotification(notification);
                return RedirectToAction("Index");
            }
            return View(notification);
        }

        //
        // GET: /Notification/Edit/5

        public ActionResult Edit(int id)
        {
            //Notification notification = db.Notifications.Find(id);
            //return View(notification);

            NotificationDAL dal = new NotificationDAL();
            Notification notification = dal.NotificationFindById(id);
            return View(notification);

        }

        //
        // POST: /Notification/Edit/5

        [HttpPost]
        public ActionResult Edit(Notification notification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notification).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");

                NotificationDAL dal = new NotificationDAL();
                dal.EditNotification(notification);
                return RedirectToAction("Index");
            }
            return View(notification);
        }

        //
        // GET: /Notification/Delete/5

        public ActionResult Delete(int id)
        {
            //Notification notification = db.Notifications.Find(id);
            //return View(notification);

            NotificationDAL dal = new NotificationDAL();
            Notification notification = dal.NotificationFindById(id);
            return View(notification);
        }

        //
        // POST: /Notification/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // Notification notification = db.Notifications.Find(id);
            // db.Notifications.Remove(notification);
            // db.SaveChanges();
            // return RedirectToAction("Index");

            NotificationDAL dal = new NotificationDAL();
            Notification notification = dal.DeleteNotificationById(id);
            return RedirectToAction("Index");


        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}