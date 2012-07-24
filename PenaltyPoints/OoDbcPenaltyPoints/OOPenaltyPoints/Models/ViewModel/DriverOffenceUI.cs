<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OOPenaltyPoints.Models.ViewModel
{
    public class DriverOffenceUI
    {
        //driving offence
        public int id { get; set; }
        [Required]
        public string gardaId { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public System.DateTime offenceDate { get; set; }

        //offence properties
        public int offenceId { get; set; }
        [Required]
        public string description { get; set; }

        //driver properties
        public int driverId {get; set;}
        [Required]
        public string LicenceNo {get; set;}
        [Required]
        public string FName {get; set;}
        [Required]
        public string SName {get; set;}
        [Required]
        public string Address1 {get; set;}
        [Required]
        public string Address2 {get; set;}
        [Required]
        public string Address3 {get; set;}
        [Required]
        public string LicenceStatus {get; set;}

        //Vechicle properties
        public int vehicleId { get; set; }
        [Required]
        public string Registration {get; set;}
        [Required]
        public string Type {get; set;}
        [Required]
        public string Make {get; set;}
        [Required]
        public decimal Capacity {get; set;}



        
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OOPenaltyPoints.Models.ViewModel
{
    public class DriverOffenceUI
    {
        //driving offence
        public int id { get; set; }
        [Required]
        public string gardaId { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public System.DateTime offenceDate { get; set; }

        //offence properties
        public int offenceId { get; set; }
        [Required]
        public string description { get; set; }

        //driver properties
        public int driverId {get; set;}
        [Required]
        public string LicenceNo {get; set;}
        [Required]
        public string FName {get; set;}
        [Required]
        public string SName {get; set;}
        [Required]
        public string Address1 {get; set;}
        [Required]
        public string Address2 {get; set;}
        [Required]
        public string Address3 {get; set;}
        [Required]
        public string LicenceStatus {get; set;}

        //Vechicle properties
        public int vehicleId { get; set; }
        [Required]
        public string Registration {get; set;}
        [Required]
        public string Type {get; set;}
        [Required]
        public string Make {get; set;}
        [Required]
        public decimal Capacity {get; set;}



        
    }
>>>>>>> Added Unit Test & soa
}