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
    
    public partial class SummonsDetail
    {
        // Primitive properties
    
        public int SdId { get; set; }
        public System.DateTime SdDate { get; set; }
        public string SdJudgement { get; set; }
    
        // Navigation properties
    
        public virtual OffencesHistory OffencesHistory { get; set; }
    
    }
}
