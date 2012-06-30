using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using OOPenaltyPoints.Models;
using System.Data.Entity;


namespace OOPenaltyPoints.Models
{
  
     public  class PenaltyPointsDbEntities : DataContext
    {
        public PenaltyPointsDbEntities()
            : base("C:\\Users\\AnthonyOToole\\Desktop\\ooPenaltyPointsDb.mdf")
        {
        }

        public Table<ListedOffence>ListedOffences;
        public Table<DriverDetail>DriverDetais;
        public Table<NotificationsIssued> NotificationsIssueds;
        public Table<OffencesHistory> OffencesHistorys;
        public Table<SummonsDetail> SummonsDetails;
        public Table<VehicleDetail> VehicleDetails;
        
    
    
    }
}


