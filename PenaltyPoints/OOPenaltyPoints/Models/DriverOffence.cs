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
using System.Data.Linq;
using System.Data.Linq.Mapping;
//using System.ComponentModel.DataAnnotations;


namespace OOPenaltyPoints.Models
{    
    [Table(Name = "DriverOffences")]
    public class DriverOffence
    {           
        [Column(IsPrimaryKey = true, IsDbGenerated = true)] //Note
        public int Id { get; set; }
        [Column(DbType = "NOT NULL")]  //<--- issue
        public System.DateTime doOffenceDate { get; set; }

        //CC - Add location
        [Column(DbType = "NULL")]
        public string doLocation { get; set; }

        //CC - removed doRegistration and doLicenceNo as in DriverDetail and Vechile detail object
        //[Column(DbType = "NOT NULL")]  //<--- issue
        //public string doRegistration { get; set; }
         //[Column(DbType = "NOT NULL")]
        //public string doLicenceNo { get; set; }


        [Column(DbType = "NULL")]
        public string doStatus { get; set; }

        //CC - removed doPoitsApplied and doPointsDate as should be in Summons and Notificaton table
        //[Column(DbType = "NULL")]
       // public int doPointsApplied { get; set; }
        //[Column(DbType = " NULL")]
        //public System.DateTime doPointsDate { get; set; }
        
        [Column(DbType = " NULL")]
        public string doGardaId { get; set; }

        //CC-removed virtual from all listedoffence, vechicledetails, driverdetails
        //m:1
        [Column] public virtual ListedOffence ListedOffence { get; set; }

        //m:1
        [Column] public virtual VehicleDetail VehicleDetails { get; set; }

        //m:1
        [Column] public virtual DriverDetail DriverDetail { get; set; }
        
        public DriverOffence()
        {
        }

        //CC - Updated Constructor
        public DriverOffence(System.DateTime _doOffenceDate, string _doStatus, string _doLocation, string _doGardaId,
        string _DdLicenceNo, string _DdFName, string _DdSName, string _DdAddress1, 
        string _DdAddress2, string _DdAddress3, string _DdLicenceStatus,
        string _VdRegistration, string _VdType, string _VdMake, decimal _VdCubicCapacity)
        {
            //DriverOffence
            this.doOffenceDate = _doOffenceDate;
            this.doStatus = _doStatus;
            this.doLocation = _doLocation;
            this.doGardaId = _doGardaId;

            //DriverDetails
            this.DriverDetail.DdLicenceNo = _DdLicenceNo;
            this.DriverDetail.DdFName = _DdFName;
            this.DriverDetail.DdSName = _DdSName;
            this.DriverDetail.DdAddress1 = _DdAddress1;
            this.DriverDetail.DdAddress2 = _DdAddress2;
            this.DriverDetail.DdAddress3 = _DdAddress3;
            this.DriverDetail.DdLicenceStatus = _DdLicenceStatus;

            //VehicleDetails
            this.VehicleDetails.VdRegistration = _VdRegistration;
            this.VehicleDetails.VdType = _VdType;
            this.VehicleDetails.VdMake = _VdMake;
            this.VehicleDetails.VdCubicCapacity = _VdCubicCapacity;
        }
    }
}
