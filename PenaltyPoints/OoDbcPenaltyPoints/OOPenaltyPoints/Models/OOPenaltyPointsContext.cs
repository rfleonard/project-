using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using OOPenaltyPoints.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;



namespace OOPenaltyPoints.Models
{

 
    public class OOPenaltyPointsContext : System.Data.Entity.DbContext
    {

        public OOPenaltyPointsContext(){}
        public OOPenaltyPointsContext(string connection = null)
          : base("OoDbcPenaltyPointsDb")
        {}

        public DbSet<ListedOffence> ListedOffences { get; set; }
        public DbSet<DriverOffence> DriverOffences { get; set; }
        public DbSet<DriverDetail> DriverDetails { get; set; }
        public DbSet<VehicleDetail> VehicleDetails { get; set; }

        public DbSet<SummonsDetail> SummonsDetails { get; set; }
        public DbSet<Notification> Notifications { get; set; }
 
       
       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
        /*
         modelBuilder.Entity<DriverDetail>()
             .HasRequired(p => p.DriverOffences)
            //HasMany<DriverOffence>(a => a.DriverOffences)
             .WithMany();
             //.WithRequired()
             // .HasForeignKey(c => c.Id);

         modelBuilder.Entity<VehicleDetail>()
             //.HasMany<DriverOffence>(a => a.DriverOffences)
             .HasRequired(p => p.DriverOffences)
             .WithMany();
             // .WithRequired()
             // .HasForeignKey(c => c.Id); 
       */
       }
       

    }
}

