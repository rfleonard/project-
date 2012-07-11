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
         //[Column]public string VdRegistration { get; set; }
         [Column(DbType = "NOT NULL")]
         public string VdType { get; set; }
         [Column(DbType = "NOT NULL")]
         public string VdMake { get; set; }
         [Column(DbType = "NULL")]   //null
         public decimal VdCubicCapacity { get; set; }
 
         //1:m
         [Column] public virtual IList<DriverOffence> DriverOffences { get; set; }

         public VehicleDetail()
        {
        }

         public VehicleDetail( string _VdType, string _VdMake, decimal _VdCubicCapacity)
        {
            //this.VdRegistration =_VdRegistration;
            this.VdType=_VdType;
            this.VdMake=_VdMake;
            this.VdCubicCapacity = _VdCubicCapacity;
        }
    
    }
}
