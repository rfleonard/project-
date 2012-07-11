using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OOPenaltyPoints.Models;

namespace OOPenaltyPoints.DAL
{
   //private OOPenaltyPointsContext db = new OOPenaltyPointsContext();

    public class DriverOffenceDAL
    {
        public DriverOffenceDAL()
        {
        }
 
        //
        // GET: /DriverOffence/
        public DriverOffence Index()
        {

            return null;
            //return db.DriverOffences.ToList();
        }

    }
}


