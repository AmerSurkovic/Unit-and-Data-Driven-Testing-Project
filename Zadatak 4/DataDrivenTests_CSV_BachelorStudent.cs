using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;

namespace Zadatak_4
{
    [TestClass]
    public class DataDrivenTests_CSV_BachelorStudent
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
        @"C:\Users\Amer\documents\visual studio 2015\Projects\Fakultet\Zadatak 4\data.csv", "data#csv", DataAccessMethod.Sequential),
        DeploymentItem("data.csv"), TestMethod]
        public void TestMethod_FindBachelorStudentCSV()
        {
            bachelorStudent test = new bachelorStudent(Convert.ToString(TestContext.DataRow["Name"]), Convert.ToString(TestContext.DataRow["Surname"]), new DateTime(1990,1,1), Convert.ToString(TestContext.DataRow["IDNumber"]), Convert.ToString(TestContext.DataRow["IDIndexNumber"]), new DateTime(2013,1,5));

            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent(Convert.ToString(TestContext.DataRow["Name"]), Convert.ToString(TestContext.DataRow["Surname"]), new DateTime(1990, 1, 1), Convert.ToString(TestContext.DataRow["IDNumber"]), new DateTime(2013, 1, 5));
            Assert.IsTrue(test.IDnumber == testFax.FindStudent(Convert.ToString(TestContext.DataRow["IDNumber"])));
        }
    }
}
