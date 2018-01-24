using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using Fakultet.Enumerations;

namespace Fakultet_UnitTesting
{
    [TestClass]
    public class Functionalities_employeeSalaries
    {
        [TestMethod]
        public void TestMethod_definiteEmp_demonstratorSalary()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            double salary = testFax.ListOfDefiniteContractEmployees[0].Salary;
            /* Demonstrator:
             * Salary = (numberOfClassesWeekly * 10) * (endOfContract - startOfContract).TotalDays;
             * Salary = 10 * 10 * 2 *365 (because the work period is from 2017 do 2019
             */
            Assert.AreEqual(salary, 10 * 10 * 2 * 365);
        }
    

        [TestMethod]
        public void TestMethod_definiteEmp_gostujuciPredavacSalary()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.gostujuciPredavac, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            double salary = testFax.ListOfDefiniteContractEmployees[0].Salary;
            /* Gostujuci predavac:
             * Salary = (numberOfClassesWeekly* 15) * (endOfContract - startOfContract).TotalDays;
             * Salary = 10 * 15 * 2 *365 (because the work period is from 2017 do 2019
             */
            Assert.AreEqual(salary, 10 * 15 * 2 * 365);
        }

        [TestMethod]
        public void TestMethod_definiteEmp_strucnjakIzPrakseSalary()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.strucnjakIzPrakse, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            double salary = testFax.ListOfDefiniteContractEmployees[0].Salary;
            /* Strucnjak iz prakse:
             * Salary = (numberOfClassesWeekly * 20) + 150;
             * Salary = (10 * 20) + 150 
             */
            Assert.AreEqual(salary, (10 * 20) +150);
        }

        [TestMethod]
        public void TestMethod_indefiniteEmp_asistentSalary()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            double salary = testFax.ListOfIndefiniteContractEmployees[0].Salary;
            /* Asistent:
             * Salary = norm * 1100;
             * Salary = 0.5 * 1100
             */
            Assert.AreEqual(salary, 0.5 * 1100);
        }

        [TestMethod]
        public void TestMethod_indefiniteEmp_visiAsistentSalary()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.visiAsistent, 0.5, "jobQual", "title");
            double salary = testFax.ListOfIndefiniteContractEmployees[0].Salary;
            /* Visi asistent:
             * Salary = norm * 1300;
             * Salary = 0.5 * 1300
             */
            Assert.AreEqual(salary, 0.5 * 1300);
        }

        [TestMethod]
        public void TestMethod_indefiniteEmp_docentSalary()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.docent, 0.5, "jobQual", "title");
            double salary = testFax.ListOfIndefiniteContractEmployees[0].Salary;
            /* Docent:
             * Salary = (norm + 0.1) * 1300;
             * Salary = (0.5 + 0.1) * 1300
             */
            Assert.AreEqual(salary, (0.5 + 0.1) * 1300);
        }

        [TestMethod]
        public void TestMethod_indefiniteEmp_vanredniProfesorSalary()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.vanredniProfesor, 0.5, "jobQual", "title");
            double salary = testFax.ListOfIndefiniteContractEmployees[0].Salary;
            /* Vanredni profesor:
             * Salary = (norm + 0.2) * 1300 + 150;
             * Salary = (0.5 + 0.2) * 1300 + 150
             */
            Assert.AreEqual(salary, (0.5 + 0.2) * 1300 + 150);
        }

        [TestMethod]
        public void TestMethod_indefiniteEmp_redovniProfesorSalary()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.redovniProfesor, 0.5, "jobQual", "title");
            double salary = testFax.ListOfIndefiniteContractEmployees[0].Salary;
            /* Redovni profesor:
             * Salary = (norm + 0.3) * 1500;
             * Salary = (0.5 + 0.3) * 1500
             */
            Assert.AreEqual(salary, (0.5 + 0.3) * 1500);
        }

        [TestMethod]
        public void TestMethod_indefiniteEmp_akademikSalary()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.akademik, 0.5, "jobQual", "title");
            double salary = testFax.ListOfIndefiniteContractEmployees[0].Salary;
            /* Akademik:
             * Salary = (norm + 0.3) * 2000;
             * Salary = (0.5 + 0.3) * 2000
             */
            Assert.AreEqual(salary, (0.5 + 0.3) * 2000);
        }

    }
}
