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


    [Table(Name = "ListedOffences")]
    public  class ListedOffence
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column]public int LoId { get; set; }
        [Column]public string LoName { get; set; }
        [Column]public string LoDesc { get; set; }
        [Column]public int Lo28Days { get; set; }
        [Column]public int Lo56days { get; set; }
        [Column]public int LoCourtPoints { get; set; }
        [Column]public decimal LoFine28 { get; set; }
        [Column]public decimal LoFine56 { get; set; }
    
    }
}
