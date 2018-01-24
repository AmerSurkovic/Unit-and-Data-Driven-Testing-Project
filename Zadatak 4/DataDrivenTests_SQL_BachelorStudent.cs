using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using System.Collections.Generic;

namespace Zadatak_4
{

    [TestClass]
    public class DataDrivenTests_SQL_BachelorStudent
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [DataSource("System.Data.SqlClient", "Data Source=DESKTOP-3M6H2LG\\SQLEXPRESS; Initial Catalog=Fakultet; Integrated Security=True",
         "BachelorStudents",
         DataAccessMethod.Sequential),TestMethod]
        public void DataDrivenTest_CreatingBachelorFromDatabase()
        {
            bachelorStudent test = new bachelorStudent(Convert.ToString(TestContext.DataRow["Name"]), Convert.ToString(TestContext.DataRow["Surname"]), Convert.ToDateTime(TestContext.DataRow["DateOfBirth"]), Convert.ToString(TestContext.DataRow["IDNumber"]), Convert.ToString(TestContext.DataRow["IDIndexNumber"]), Convert.ToDateTime(TestContext.DataRow["EndOfPrevEd"]));

            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent(Convert.ToString(TestContext.DataRow["Name"]), Convert.ToString(TestContext.DataRow["Surname"]), Convert.ToDateTime(TestContext.DataRow["DateOfBirth"]), Convert.ToString(TestContext.DataRow["IDNumber"]), Convert.ToDateTime(TestContext.DataRow["EndOfPrevEd"]));
            Assert.IsTrue(test.IDnumber == testFax.FindStudent(Convert.ToString(TestContext.DataRow["IDNumber"])));

        }


    }
}
