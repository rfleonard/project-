using OOPenaltyPoints.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using OOPenaltyPoints.Models;
//using OOPenaltyPoints.Tests.Models;
using System.Collections.Generic;

namespace OOPenaltyPoints.Tests
{
    
    /// <summary>
    ///-----------------------------------------------------------------
    ///          As these tests hit the Production database
    /// 1. Theys should  NOT be run in a deployed production environment
    /// 2. Many of these Tests require visual verification from the database
    ///  
    ///------------------------------------------------------------------

    ///This is a test class for ListedOffenceDALTest and is intended
    ///to contain all ListedOffenceDALTest Unit Tests
    ///</summary>
    
    [TestClass()]
    public class ListedOffenceDALTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        /// --------------------------------------------------
        // Tried a OOPenaltyPointsContextTest.cs (now deleted)
        // A seperate testing databasewass created
        // But dbcontext cannot be cross cut into main project
        // Need a factory pattern maybe
        // ---------------------------------------------------
        /// </summary>
        [TestMethod()]
        public void InitialSetup()
        {
           //Do not uncomment
           //OOPenaltyPointsContextTest db = new OOPenaltyPointsContextTest();
           //db.Database.Delete();
           //db.Database.Create();
        }
        
        [TestMethod()]
        public void CreateListedOffenceTest()
        {
           // -----------------------------
           // Listed Offences Table Fields
           // accessed by ListedOffenceDAL
           // ------------------------------
           // type  of fields on table
           // Order of fields in Constructor
           // -------------------------------
           //Id (auto gen by db)
           //string   allow null  LoDesc    
           //int      not   null  Lo28Days  
           //int      not   null  Lo56days  
           //dec      not   null  LoFine28  
           //dec      not   null  LoFine56  
           //bool     allow null  LoStatus 
           //DateTime not   null  LoDateCreated  
           //DateTime not   null  LoDateLastModified 
           //bool     allow null  LoMandatoryCourtAppearance 
           //------------------------------------------------

           /* Listed Offence Constructor
            public ListedOffence(string _LoDesc, int _Lo28Days, int _Lo56days, decimal _LoFine28, decimal _LoFine56, bool _LoStatus, System.DateTime _LoDateCreated, System.DateTime _LoDateLastModified, bool _LoMandatoryCourtAppearance )
           {
           this.LoDesc=_LoDesc;
           this.Lo28Days =_Lo28Days;
           this.Lo56days=_Lo56days;
           this.LoFine28=_LoFine28;
           this.LoFine56=_LoFine56;
           this.LoStatus = _LoStatus;
           this.LoDateCreated = _LoDateCreated;
           this.LoDateLastModified = _LoDateLastModified;
           this.LoMandatoryCourtAppearance = _LoMandatoryCourtAppearance;)     
            */
          
            // Some useful data
            string dt;
            DateTime date = DateTime.Now;
            dt = date.ToShortDateString();
            bool LoStat = true;
            bool MandCourt = true;
            string desc = "Speeding";

    
            ListedOffenceDAL target = new ListedOffenceDAL(); 

            ListedOffence listedoffence = new ListedOffence(desc, 20, 40, 35.66m, 70.29m, LoStat, date, date, MandCourt);
          
            target.CreateListedOffence(listedoffence);

            ListedOffence expected = target.ListedOffenceFindById(listedoffence.Id);
            Assert.AreEqual(expected, listedoffence);
        }

        [TestMethod()]
        public void DeleteListedOffenceByIdTest()
        {

            // Some useful data
            string dt;
            DateTime date = DateTime.Now;
            dt = date.ToShortDateString();
            bool LoStat = true;
            bool MandCourt = true;
            string desc = "Speeding";


            ListedOffenceDAL target = new ListedOffenceDAL();

            //populate
            ListedOffence listedoffence = new ListedOffence(desc, 20, 40, 35.66m, 70.29m, LoStat, date, date, MandCourt);

            target.CreateListedOffence(listedoffence);

            //retrieve
            ListedOffence expected = target.ListedOffenceFindById(listedoffence.Id);

            //delete
            target.DeleteListedOffenceById(listedoffence.Id);

            
             //Assert.IsNull(target.DeleteListedOffenceById(listedoffence.Id));
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void EditListedOffenceTest()
        {
            // Some useful data
            string dt;
            DateTime date = DateTime.Now;
            dt = date.ToShortDateString();
            bool LoStat = true;
            bool MandCourt = true;
            string desc = "Speeding";


            ListedOffenceDAL target = new ListedOffenceDAL();


            //populate
            ListedOffence listedoffence = new ListedOffence(desc, 20, 40, 35.66m, 70.29m, LoStat, date, date, MandCourt);
            target.CreateListedOffence(listedoffence);

            listedoffence.LoFine28 = 4000.00m;
            target.EditListedOffence(listedoffence);

            //retrieve
            //ListedOffence expected = target.ListedOffenceFindById(listedoffence.Id);

            //Assert.AreEqual(4000.00m, listedoffence.LoFine28);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }


        [TestMethod()]
        public void ListedOffenceFindByIdTest()
        {

             // Some useful data
             string dt;
             DateTime date = DateTime.Now;
             dt = date.ToShortDateString();
             bool LoStat = true;
             bool MandCourt = true;
             string desc = "Speeding";


             ListedOffenceDAL target = new ListedOffenceDAL();

             //populate
             ListedOffence listedoffence = new ListedOffence(desc, 20, 40, 35.66m, 70.29m, LoStat, date, date, MandCourt);

             target.CreateListedOffence(listedoffence);

             //retrieve
             ListedOffence expected = target.ListedOffenceFindById(listedoffence.Id);

 
            //Assert.IsNull(target.DeleteListedOffenceById(listedoffence.Id));
            Assert.Inconclusive("Verify the correctness of this test method.");
 
        }

        [TestMethod()]
        public void ListOfListedOffencesTest()
        {
            ListedOffenceDAL target = new ListedOffenceDAL(); // TODO: Initialize to an appropriate value
            List<ListedOffence> actual;
            actual = target.ListOfListedOffences();
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

    }
}
