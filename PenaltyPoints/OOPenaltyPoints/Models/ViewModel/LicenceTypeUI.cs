using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OOPenaltyPoints.Models.ViewModel
{
    public class LicenceTypeUI
    {
        public int FullLicence { get; set; }
        public int Provisional { get; set; }
        public int Disqualified { get; set; }
        public int NoLicence { get; set; }
        public int Other { get; set; }
    }
}