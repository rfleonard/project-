<<<<<<< HEAD
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace OOPenaltyPoints.Models
{

    
    [Table(Name = "VehicleDetails")]
    public  class VehicleDetail
    {
         [Column(IsPrimaryKey = true, IsDbGenerated = true)]
         public int Id { get; set; } 
        
        //CC - Added VdRegistration
         [Column(DbType = "NOT NULL")]
         public string VdRegistration { get; set; }

         [Column(DbType = "NOT NULL")]
         public string VdType { get; set; }
         [Column(DbType = "NOT NULL")]
         public string VdMake { get; set; }
         [Column(DbType = "NULL")]   //null
         public decimal VdCubicCapacity { get; set; }

         //CC-commented out Ilits<DriverOffence> relationship
         //1:m
         //[Column(DbType = "NOT NULL")]
         //public virtual IList<DriverOffence> DriverOffences { get; set; }

         public VehicleDetail()
        {
        }

        //CC - Updated Constructor
         public VehicleDetail( string _VdRegistration, string _VdType, string _VdMake, decimal _VdCubicCapacity)
        {
            this.VdRegistration =_VdRegistration;
            this.VdType=_VdType;
            this.VdMake=_VdMake;
            this.VdCubicCapacity = _VdCubicCapacity;
        }
    
    }
}
=======
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace OOPenaltyPoints.Models
{

    
    [Table(Name = "VehicleDetails")]
    public  class VehicleDetail
    {
         [Column(IsPrimaryKey = true, IsDbGenerated = true)]
         public int Id { get; set; } 
        
        //CC - Added VdRegistration
         [Column(DbType = "NOT NULL")]
         public string VdRegistration { get; set; }

         [Column(DbType = "NOT NULL")]
         public string VdType { get; set; }
         [Column(DbType = "NOT NULL")]
         public string VdMake { get; set; }
         [Column(DbType = "NULL")]   //null
         public decimal VdCubicCapacity { get; set; }

         //CC-commented out Ilits<DriverOffence> relationship
         //1:m
         //[Column(DbType = "NOT NULL")]
         //public virtual IList<DriverOffence> DriverOffences { get; set; }

         public VehicleDetail()
        {
        }

        //CC - Updated Constructor
         public VehicleDetail( string _VdRegistration, string _VdType, string _VdMake, decimal _VdCubicCapacity)
        {
            this.VdRegistration =_VdRegistration;
            this.VdType=_VdType;
            this.VdMake=_VdMake;
            this.VdCubicCapacity = _VdCubicCapacity;
        }
    
    }
}
>>>>>>> Added Unit Test & soa
