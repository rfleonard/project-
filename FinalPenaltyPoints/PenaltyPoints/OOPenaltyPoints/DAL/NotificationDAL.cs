using System;
using System.Collections.Generic;
using System.Data;     //<-------------  NOTE added to acquire EntityState.Modified in "EditNotification"
using System.Linq;
using System.Web;
using OOPenaltyPoints.Models;


namespace OOPenaltyPoints.DAL
{
    public class NotificationDAL
    {
        // System.Diagnostics.Debug.WriteLine("Now in NotificationDal.NotificationFindById");

        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        public Notification NotificationFindById(int id)
        {
            Notification notification = db.Notifications.Find(id);
            return (notification);           
        }

       public List<Notification> ListOfNotifications(){
           return(db.Notifications.ToList());
        }

       public Notification CreateNotification(Notification notification)
       {
           db.Notifications.Add(notification);
           db.SaveChanges();
           return null;
       }

       public Notification DeleteNotificationById(int id)
       {
           Notification notification = db.Notifications.Find(id);
           db.Notifications.Remove(notification);
           db.SaveChanges();

           return null;
       }


       public Notification EditNotification(Notification notification)
       {       
           db.Entry(notification).State = EntityState.Modified;
           db.SaveChanges();
           return null;
       }

    }
}