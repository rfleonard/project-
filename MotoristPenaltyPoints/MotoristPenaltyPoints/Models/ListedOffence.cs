//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MotoristPenaltyPoints.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ListedOffence
    {
        public ListedOffence()
        {
            this.OffencesHistories = new HashSet<OffencesHistory>();
        }
    
        // Primitive properties
    
        public int LoId { get; set; }
        public string LoName { get; set; }
        public string LoDesc { get; set; }
        public int Lo28Days { get; set; }
        public int Lo56days { get; set; }
        public int LoCourtPoints { get; set; }
        public decimal LoFine28 { get; set; }
        public decimal LoFine56 { get; set; }
    
        // Navigation properties
    
        public virtual ICollection<OffencesHistory> OffencesHistories { get; set; }
    
    }
}
