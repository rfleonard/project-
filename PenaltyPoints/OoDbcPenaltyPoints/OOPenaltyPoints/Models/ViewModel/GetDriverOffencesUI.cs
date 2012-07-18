using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OOPenaltyPoints.Models.ViewModel
{
    public struct GetDriverOffenceUI
    {
        //driving offence
        public int id { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public System.DateTime offenceDate { get; set; }

        //offence properties
        [Required]
        public string description { get; set; }

        //driver properties
        [Required]
        public string LicenceNo {get; set;}
        [Required]
        public string FName {get; set;}
        [Required]
        public string SName {get; set;}
        [Required]
        public string LicenceStatus {get; set;}

        //Vechicle properties
        [Required]
        public string Registration {get; set;}





        
    }
}