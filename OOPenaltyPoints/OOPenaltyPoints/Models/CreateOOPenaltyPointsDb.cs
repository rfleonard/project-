using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using OOPenaltyPoints.Models;


namespace OOPenaltyPoints.Models
{
    [Database]

     public partial class PenaltyPointsDbEntities : DbContext
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


