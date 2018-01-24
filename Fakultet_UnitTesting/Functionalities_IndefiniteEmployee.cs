using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using Fakultet.Enumerations;

namespace Fakultet_UnitTesting
{
    [TestClass]
    public class Functionalities_IndefiniteEmployee
    {
        /* Testing input of employee with definite contract
         * in Faculty container class */
        [TestMethod]
        public void TestMethod_InputIndefiniteEmp()
        {
            Faculty testFax = new Faculty("ETF");

            /* We add object employee by sending parameters of 
             * the employee constructor without "employee ID"
             * because like in the case of students, the container
             * class "Faculty" generates unique ID for it.
             */
            /* string name, string surname, DateTime dateOfBirth, string IDnumber, int employeeID, employmentPosition_indefinitePeriod employeePosition, double norm, string jobQualification, string title) */
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
           
        }

        [TestMethod]
        public void TestMethod_InputOfMoreIndefiniteEmp()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555556", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555557", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555558", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555559", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            Assert.AreEqual(testFax.ListOfIndefiniteContractEmployees.Count, 5);

            CollectionAssert.AllItemsAreUnique(testFax.ListOfIndefiniteContractEmployees);
            CollectionAssert.AllItemsAreUnique(testFax.ListOfEmployees);
            CollectionAssert.AllItemsAreNotNull(testFax.ListOfIndefiniteContractEmployees);
            CollectionAssert.IsSubsetOf(testFax.ListOfIndefiniteContractEmployees, testFax.ListOfEmployees);
        }

        [TestMethod]
        public void TestMethod_indefiniteEmp_ValidityOfGeneratedWorkIDs()
        {
            /* Container class "Faculty" is generating
             * employee ID by it's built-in start value of 1.
             */
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555556", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555557", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555558", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555559", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            Assert.AreEqual(testFax.ListOfIndefiniteContractEmployees[0].EmploymentID, 1);
            Assert.AreEqual(testFax.ListOfIndefiniteContractEmployees[1].EmploymentID, 2);
            Assert.AreEqual(testFax.ListOfIndefiniteContractEmployees[2].EmploymentID, 3);
            Assert.AreEqual(testFax.ListOfIndefiniteContractEmployees[3].EmploymentID, 4);
            Assert.AreEqual(testFax.ListOfIndefiniteContractEmployees[4].EmploymentID, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_indefiniteEmp_AddingPeopleWithSameIDs()
        {
            /* Container class "Faculty" is generating
             * employee ID by it's built-in start value of 1.
             */
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
        }


        [TestMethod]
        public void TestMethod_indefiniteEmp_ValidityOfInputData()
        {
            Faculty testFax = new Faculty("ETF");

            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");

            string name = testFax.ListOfIndefiniteContractEmployees[0].Name;
            Assert.AreEqual(name, "name");

            string surname = testFax.ListOfIndefiniteContractEmployees[0].Surname;
            Assert.AreEqual(surname, "surname");

            DateTime birth = testFax.ListOfIndefiniteContractEmployees[0].DateOfBirth;
            Assert.AreEqual(birth, new DateTime(1970, 1, 1));

            string ID = testFax.ListOfIndefiniteContractEmployees[0].IDnumber;
            Assert.AreEqual(ID, "5555555555555");

            employmentPosition_indefinitePeriod position = testFax.ListOfIndefiniteContractEmployees[0].EmployeePosition;
            Assert.AreEqual(position, employmentPosition_indefinitePeriod.asistent);

            string title = testFax.ListOfIndefiniteContractEmployees[0].Title;
            Assert.AreEqual(title, "title");

            string qual = testFax.ListOfIndefiniteContractEmployees[0].JobQualification;
            Assert.AreEqual(qual, "jobQual");

            double norm = testFax.ListOfIndefiniteContractEmployees[0].Norm;
            Assert.AreEqual(norm, 0.5);

        }

        [TestMethod]
        public void TestMethod_indefiniteEmp_ValidityOfChangedData()
        {
            Faculty testFax = new Faculty("ETF");

            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");

            testFax.ListOfIndefiniteContractEmployees[0].Name = "changedName";
            string name = testFax.ListOfIndefiniteContractEmployees[0].Name;
            Assert.AreEqual(name, "changedName");

            testFax.ListOfIndefiniteContractEmployees[0].Surname = "changedSurname";
            string surname = testFax.ListOfIndefiniteContractEmployees[0].Surname;
            Assert.AreEqual(surname, "changedSurname");

            testFax.ListOfIndefiniteContractEmployees[0].DateOfBirth = new DateTime(1971, 1, 1);
;            DateTime birth = testFax.ListOfIndefiniteContractEmployees[0].DateOfBirth;
            Assert.AreEqual(birth, new DateTime(1971, 1, 1));

            testFax.ListOfIndefiniteContractEmployees[0].IDnumber = "6666666666666";
            string ID = testFax.ListOfIndefiniteContractEmployees[0].IDnumber;
            Assert.AreEqual(ID, "6666666666666");

            testFax.ListOfIndefiniteContractEmployees[0].EmployeePosition = employmentPosition_indefinitePeriod.visiAsistent;
            employmentPosition_indefinitePeriod position = testFax.ListOfIndefiniteContractEmployees[0].EmployeePosition;
            Assert.AreEqual(position, employmentPosition_indefinitePeriod.visiAsistent);

            testFax.ListOfIndefiniteContractEmployees[0].Title = "changedTitle";
            string title = testFax.ListOfIndefiniteContractEmployees[0].Title;
            Assert.AreEqual(title, "changedTitle");

            testFax.ListOfIndefiniteContractEmployees[0].Title = "changedJob";
            string qual = testFax.ListOfIndefiniteContractEmployees[0].Title;
            Assert.AreEqual(qual, "changedJob");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_indefiniteEmp_InvalidNameInput()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("na4$me", "surname", new DateTime(1970, 1, 1), "5555555555556", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_indefiniteEmp_InvalidSurameInput()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "su4$$rname", new DateTime(1970, 1, 1), "5555555555556", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_indefiniteEmp_InvalidDateOfBirth()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(2019, 1, 1), "5555555555556", employmentPosition_indefinitePeriod.asistent, 0.5, "jobQual", "title");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_indefiniteEmp_InvaliNorm_Underflow()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555556", employmentPosition_indefinitePeriod.asistent, 0.4, "jobQual", "title");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_indefiniteEmp_InvaliNorm_Overflow()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555556", employmentPosition_indefinitePeriod.asistent, 1.6, "jobQual", "title");
        }

        [TestMethod]
        public void TestMethod_DeletingIndefiniteEmployee_ByID()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddIndefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555556", employmentPosition_indefinitePeriod.asistent, 1.5, "jobQual", "title");
            Assert.AreEqual(testFax.ListOfEmployees.Count, 1);
            Assert.AreEqual(testFax.ListOfIndefiniteContractEmployees.Count, 1);

            testFax.deleteEmployeeByID("5555555555556");

            Assert.AreEqual(testFax.ListOfEmployees.Count, 0);
            Assert.AreEqual(testFax.ListOfIndefiniteContractEmployees.Count, 0);
        }
    }
}
