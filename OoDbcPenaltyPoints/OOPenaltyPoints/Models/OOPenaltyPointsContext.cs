using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using OOPenaltyPoints.Models;
using System.Data.Entity;




namespace OOPenaltyPoints.Models
{



    public class OOPenaltyPointsContext : System.Data.Entity.DbContext
    {

        public OOPenaltyPointsContext(string connection = null)
          : base("OoDbcPenaltyPointsDb")
       { }

        public DbSet<DriverOffence> DriverOffences;



        //public DbSet<ListedOffence> ListedOffences;

       // public DbSet<DriverDetail>  DriverDetails;
       // public DbSet<VehicleDetail> VehicleDetails;
        
       // public DbSet<SummonsDetail> SummonsDetails;
       // public DbSet<NotificationsIssued> NotificationsIssueds;
 
       

       

    }
}

