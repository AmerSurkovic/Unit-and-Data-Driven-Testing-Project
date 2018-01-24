using Fakultet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_4
{
    [TestClass]
    public class DataDrivenTests_SQL_MasterStudent
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [DataSource("System.Data.SqlClient", "Data Source=DESKTOP-3M6H2LG\\SQLEXPRESS; Initial Catalog=Fakultet; Integrated Security=True",
         "MasterStudents",
         DataAccessMethod.Sequential), TestMethod]
        public void DataDrivenTest_CreatingMasterFromDatabase()
        {
            masterStudent test = new masterStudent(Convert.ToString(TestContext.DataRow["Name"]), Convert.ToString(TestContext.DataRow["Surname"]), Convert.ToDateTime(TestContext.DataRow["DateOfBirth"]), Convert.ToString(TestContext.DataRow["IDNumber"]), Convert.ToString(TestContext.DataRow["IDIndexNumber"]), Convert.ToDateTime(TestContext.DataRow["EndOfPrevEd"]), Convert.ToString(TestContext.DataRow["PlaceOfPrevEd"]));

            Faculty testFax = new Faculty("ETF");
            testFax.AddMasterStudent(Convert.ToString(TestContext.DataRow["Name"]), Convert.ToString(TestContext.DataRow["Surname"]), Convert.ToDateTime(TestContext.DataRow["DateOfBirth"]), Convert.ToString(TestContext.DataRow["IDNumber"]), Convert.ToDateTime(TestContext.DataRow["EndOfPrevEd"]), Convert.ToString(TestContext.DataRow["PlaceOfPrevEd"]));
            Assert.IsTrue(test.IDnumber == testFax.FindStudent(Convert.ToString(TestContext.DataRow["IDNumber"])));

        }
    }
}