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
    ///This is a test class for SummonsDetailDALTest and is intended
    ///to contain all SummonsDetailDALTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SummonsDetailDALTest
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

        [TestMethod()]
        public void SummonsDetailFindByIdTest()
        {
            //Summons Detail

            DateTime date = DateTime.Now;


            SummonsDetailDAL target = new SummonsDetailDAL(); // TODO: Initialize to an appropriate value
            int id = 2; // TODO: Initialize to an appropriate value
            SummonsDetail expected = null; // TODO: Initialize to an appropriate value
            SummonsDetail actual;
            
            actual = target.SummonsDetailFindById(id);
            Assert.IsNotNull(actual);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

         [TestMethod()]
        public void CreateSummonsDetailTest()
        {

        //Summons Detail
        
        DateTime date = DateTime.Now;
  
        string mySdLicenceNo="abc123";
        string mySdFName="ronan";
        string mySdSName="leonard";

        //More driver detail
        string mySdAddress1="23 windmill lane apart";
        string mySdAddress2="windmill lane";
        string mySdAddress3="dublin 2";
        string mySdJudgement="";

           

            SummonsDetailDAL target = new SummonsDetailDAL(); 

            SummonsDetail summonsdetail = new SummonsDetail(date, mySdLicenceNo,  mySdFName, mySdSName,mySdAddress1, mySdAddress2, mySdAddress3, mySdJudgement);
          
            target.CreateSummonsDetail(summonsdetail);

           
            SummonsDetail expected = target.SummonsDetailFindById(summonsdetail.Id);
            Assert.AreEqual(expected,summonsdetail);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>

        [TestMethod()]
        public void ListOfSummonsDetailsTest()
        {
            SummonsDetailDAL target = new SummonsDetailDAL(); // TODO: Initialize to an appropriate value
            List<SummonsDetail> actual;
            actual = target.ListOfSummonsDetails();
            Assert.IsNotNull(actual);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

    }
}
