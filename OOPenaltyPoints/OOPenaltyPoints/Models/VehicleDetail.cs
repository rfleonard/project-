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
         [Column(IsPrimaryKey = true, IsDbGenerated = false)]         
        public string VdRegistration { get; set; }

         [Column]public string VdType { get; set; }
         [Column]public string VdMake { get; set; }
         [Column]public decimal VdCubicCapacity { get; set; }
    
    }
}
