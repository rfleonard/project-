using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OOPenaltyPoints.Models.ViewModel
{
    public class SearchDriverOffenceUI
    {
        //driver properties
        [Required]
        public string LicenceNo { get; set; }
        //offence properties
        [Required]
        public string description { get; set; }
        //Vechicle properties
        [Required]
        public string Registration { get; set; }
    }
}