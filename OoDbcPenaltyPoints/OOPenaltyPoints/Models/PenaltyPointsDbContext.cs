using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using OOPenaltyPoints.Models;
using System.Data.Entity;


namespace OOPenaltyPoints.Models
{
     [Database]
    public class PenaltyPointsDbContext : System.Data.Entity.DbContext
    {


    public PenaltyPointsDbContext()
       : base("PenaltyPointsDb")
    {}
 
      public DbSet<ListedOffence>ListedOffences;      
      public DbSet<DriverDetail>DriverDetails;
      public DbSet<NotificationsIssued> NotificationsIssueds;
      public DbSet<SummonsDetail> SummonsDetails;
      public DbSet<VehicleDetail> VehicleDetails;
      public DbSet<DriverOffence> DriverOffences; 
 

        
    }
}


