using System;
using Fakultet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet.Enumerations;

namespace Zadatak_4
{
    [TestClass]
    public class DataDrivenTests_SQL_DefiniteContractEmp
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [DataSource("System.Data.SqlClient", "Data Source=DESKTOP-3M6H2LG\\SQLEXPRESS; Initial Catalog=Fakultet; Integrated Security=True",
         "DefiniteContractEmployees",
         DataAccessMethod.Sequential), TestMethod]
        public void DataDrivenTest_CreatingDefiniteEmployeeFromDatabase()
        {
            employeeDEFINITEContract test = new employeeDEFINITEContract(TestContext.DataRow["Name"].ToString(), TestContext.DataRow["Surname"].ToString(), Convert.ToDateTime(TestContext.DataRow["DateOfBirth"]), TestContext.DataRow["IDNumber"].ToString(), Convert.ToInt32(TestContext.DataRow["EmployeeID"]), employmentPosition_OnContract.demonstrator, Convert.ToDateTime(TestContext.DataRow["StartOfContract"]), Convert.ToDateTime(TestContext.DataRow["EndOfContract"]), Convert.ToInt32(TestContext.DataRow["NmbOfClassesWeekly"]));

            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee(TestContext.DataRow["Name"].ToString(), TestContext.DataRow["Surname"].ToString(), Convert.ToDateTime(TestContext.DataRow["DateOfBirth"]), TestContext.DataRow["IDNumber"].ToString(), employmentPosition_OnContract.demonstrator, Convert.ToDateTime(TestContext.DataRow["StartOfContract"]), Convert.ToDateTime(TestContext.DataRow["EndOfContract"]), Convert.ToInt32(TestContext.DataRow["NmbOfClassesWeekly"]));
            Assert.IsTrue(test.IDnumber == testFax.FindEmployee(Convert.ToString(TestContext.DataRow["IDNumber"])));

        }
    }
}
