using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using Fakultet.Enumerations;

namespace Zadatak_4
{
    [TestClass]
    public class DataDrivenTests_SQL_IndefiniteContractEmp
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [DataSource("System.Data.SqlClient", "Data Source=DESKTOP-3M6H2LG\\SQLEXPRESS; Initial Catalog=Fakultet; Integrated Security=True",
         "IndefiniteContractEmployees",
         DataAccessMethod.Sequential), TestMethod]
        public void DataDrivenTest_CreatingIndefiniteEmployeeFromDatabase()
        {
            employeeINDEFINITEContract test = new employeeINDEFINITEContract(TestContext.DataRow["Name"].ToString(), TestContext.DataRow["Surname"].ToString(), Convert.ToDateTime(TestContext.DataRow["DateOfBirth"]), TestContext.DataRow["IDNumber"].ToString(), Convert.ToInt32(TestContext.DataRow["EmployeeID"]), employmentPosition_indefinitePeriod.asistent, Convert.ToDouble(TestContext.DataRow["Norm"]), TestContext.DataRow["JobQualification"].ToString(), TestContext.DataRow["Title"].ToString());

            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee(TestContext.DataRow["Name"].ToString(), TestContext.DataRow["Surname"].ToString(), Convert.ToDateTime(TestContext.DataRow["DateOfBirth"]), TestContext.DataRow["IDNumber"].ToString(), employmentPosition_indefinitePeriod.asistent, Convert.ToDouble(TestContext.DataRow["Norm"]), TestContext.DataRow["JobQualification"].ToString(), TestContext.DataRow["Title"].ToString());
            Assert.IsTrue(test.IDnumber == testFax.FindEmployee(Convert.ToString(TestContext.DataRow["IDNumber"])));

        }
    }
}
