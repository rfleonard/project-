using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using OOPenaltyPoints.Models;
using System.Data.Entity;


namespace OOPenaltyPoints.Models
{
     [Database]
     public  class PenaltyPointsDataContext : DataContext
    {
         public PenaltyPointsDataContext() : 
             base("C:\\Program Files\\Microsoft SQL Server\\MSSQL10.SQLEXPRESS\\MSSQL\\DATA\\PenaltyPointsDb.mdf") { }
      
      
      public Table<ListedOffence>ListedOffences;      
      public Table<DriverDetail>DriverDetails;
      public Table<NotificationsIssued> NotificationsIssueds;
      public Table<SummonsDetail> SummonsDetails;
      public Table<VehicleDetail> VehicleDetails;
      public Table<DriverOffence> DriverOffences;               
    }
}


