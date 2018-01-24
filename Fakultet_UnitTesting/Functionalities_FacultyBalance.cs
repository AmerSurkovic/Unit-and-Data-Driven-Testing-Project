using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;

namespace Fakultet_UnitTesting
{
    [TestClass]
    public class Functionalities_FacultyBalance
    {
        [TestMethod]
        public void TestMethod_FacultyBalance()
        {
            Faculty testFax = new Faculty("ETF");

            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111112", new DateTime(2005, 1, 1));
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111113", new DateTime(2005, 1, 1));
            double expenditures = testFax.Balance;
            Assert.AreEqual(expenditures, 9000 * 3);

            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111114", new DateTime(2005, 1, 1), "ETF Sarajevo");
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111115", new DateTime(2005, 1, 1), "ETF Sarajevo");
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111116", new DateTime(2005, 1, 1), "ETF Sarajevo");
            expenditures = testFax.Balance;
            Assert.AreEqual(expenditures, (9000 * 3) + (11000 * 3));

            Assert.AreEqual(testFax.FLAG, 1);
        }
    }
}
