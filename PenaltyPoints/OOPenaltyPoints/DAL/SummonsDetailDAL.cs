using System;
using System.Collections.Generic;
using System.Data;     //<-------------  NOTE added to acquire EntityState.Modified in "EditSummonsDetail"
using System.Linq;
using System.Web;
using OOPenaltyPoints.Models;


namespace OOPenaltyPoints.DAL
{
    public class SummonsDetailDAL
    {
        // System.Diagnostics.Debug.WriteLine("Now in SummonsDetailDal.SummonsDetailFindById");

        private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

        public SummonsDetail SummonsDetailFindById(int id)
        {
            SummonsDetail summonsdetail = db.SummonsDetails.Find(id);
            return (summonsdetail);           
        }

       public List<SummonsDetail> ListOfSummonsDetails(){
           return(db.SummonsDetails.ToList());
        }

       public SummonsDetail CreateSummonsDetail(SummonsDetail summonsdetail)
       {
           db.SummonsDetails.Add(summonsdetail);
           db.SaveChanges();
           return null;
       }

       public SummonsDetail DeleteSummonsDetailById(int id)
       {
           SummonsDetail summonsdetail = db.SummonsDetails.Find(id);
           db.SummonsDetails.Remove(summonsdetail);
           db.SaveChanges();

           return null;
       }


       public SummonsDetail EditSummonsDetail(SummonsDetail summonsdetail)
       {       
           db.Entry(summonsdetail).State = EntityState.Modified;
           db.SaveChanges();
           return null;
       }

    }
}