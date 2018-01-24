using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using Fakultet.Enumerations;

namespace Fakultet_UnitTesting
{
    [TestClass]
    public class Functionalities_DefiniteEmployee
    {
        /* Testing input of employee with definite contract
         * in Faculty container class */
        [TestMethod]
        public void TestMethod_InputDefiniteEmp()
        {
            Faculty testFax = new Faculty("ETF");

            /* employeeDEFINITEContract(string name, string surname, DateTime dateOfBirth, string IDnumber, int employeeID, employmentPosition_OnContract employeePosition, DateTime startOfContract, DateTime endOfContract, int numberOfClassesWeekly) */
            /* We add object employee by sending parameters of 
             * the employee constructor without "employee ID"
             * because like in the case of students, the container
             * class "Faculty" generates unique ID for it.
             */
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017,1,1), new DateTime(2019,1,1), 10);
           
        }

        [TestMethod]
        public void TestMethod_InputOfMoreDefiniteEmp()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555556", employmentPosition_OnContract.gostujuciPredavac, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555557", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555558", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555559", employmentPosition_OnContract.strucnjakIzPrakse, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            Assert.AreEqual(testFax.ListOfDefiniteContractEmployees.Count, 5);

            CollectionAssert.AllItemsAreUnique(testFax.ListOfDefiniteContractEmployees);
            CollectionAssert.AllItemsAreUnique(testFax.ListOfEmployees);
            CollectionAssert.AllItemsAreNotNull(testFax.ListOfDefiniteContractEmployees);
            CollectionAssert.IsSubsetOf(testFax.ListOfDefiniteContractEmployees, testFax.ListOfEmployees);
        }

        [TestMethod]
        public void TestMethod_definiteEmp_ValidityOfGeneratedWorkIDs()
        {
            /* Container class "Faculty" is generating
             * employee ID by it's built-in start value of 1.
             */
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555556", employmentPosition_OnContract.gostujuciPredavac, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555557", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555558", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555559", employmentPosition_OnContract.strucnjakIzPrakse, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            Assert.AreEqual(testFax.ListOfDefiniteContractEmployees[0].EmploymentID, 1);
            Assert.AreEqual(testFax.ListOfDefiniteContractEmployees[1].EmploymentID, 2);
            Assert.AreEqual(testFax.ListOfDefiniteContractEmployees[2].EmploymentID, 3);
            Assert.AreEqual(testFax.ListOfDefiniteContractEmployees[3].EmploymentID, 4);
            Assert.AreEqual(testFax.ListOfDefiniteContractEmployees[4].EmploymentID, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_definiteEmp_AddingPeopleWithSameIDs()
        {
            /* Container class "Faculty" is generating
             * employee ID by it's built-in start value of 1.
             */
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.gostujuciPredavac, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
        }


        [TestMethod]
        public void TestMethod_definiteEmp_ValidityOfInputData()
        {
            Faculty testFax = new Faculty("ETF");

            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);

            string name = testFax.ListOfDefiniteContractEmployees[0].Name;
            Assert.AreEqual(name, "name");

            string surname = testFax.ListOfDefiniteContractEmployees[0].Surname;
            Assert.AreEqual(surname, "surname");

            DateTime birth = testFax.ListOfDefiniteContractEmployees[0].DateOfBirth;
            Assert.AreEqual(birth, new DateTime(1970, 1, 1));

            string ID = testFax.ListOfDefiniteContractEmployees[0].IDnumber;
            Assert.AreEqual(ID, "5555555555555");

            employmentPosition_OnContract position = testFax.ListOfDefiniteContractEmployees[0].EmployeePosition;
            Assert.AreEqual(position, employmentPosition_OnContract.demonstrator);

            DateTime contractStart = testFax.ListOfDefiniteContractEmployees[0].StartOfContract;
            Assert.AreEqual(contractStart, new DateTime(2017, 1, 1));

            DateTime contractEnd = testFax.ListOfDefiniteContractEmployees[0].EndOfContract;
            Assert.AreEqual(contractEnd, new DateTime(2019, 1, 1));

            int classes = testFax.ListOfDefiniteContractEmployees[0].NumberOfClassesWeekly;
            Assert.AreEqual(classes, 10);
        }

        [TestMethod]
        public void TestMethod_definiteEmp_ValidityOfChangedData()
        {
            Faculty testFax = new Faculty("ETF");

            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);

            testFax.ListOfDefiniteContractEmployees[0].Name = "changedName";
            string name = testFax.ListOfDefiniteContractEmployees[0].Name;
            Assert.AreEqual(name, "changedName");

            testFax.ListOfDefiniteContractEmployees[0].Surname = "changedSurname";
            string surname = testFax.ListOfDefiniteContractEmployees[0].Surname;
            Assert.AreEqual(surname, "changedSurname");

            testFax.ListOfDefiniteContractEmployees[0].DateOfBirth = new DateTime(1990, 1, 1);
            DateTime birth = testFax.ListOfDefiniteContractEmployees[0].DateOfBirth;
            Assert.AreEqual(birth, new DateTime(1990, 1, 1));

            testFax.ListOfDefiniteContractEmployees[0].IDnumber = "6666666666666";
            string ID = testFax.ListOfDefiniteContractEmployees[0].IDnumber;
            Assert.AreEqual(ID, "6666666666666");

            testFax.ListOfDefiniteContractEmployees[0].EmployeePosition = employmentPosition_OnContract.gostujuciPredavac;
            employmentPosition_OnContract position = testFax.ListOfDefiniteContractEmployees[0].EmployeePosition;
            Assert.AreEqual(position, employmentPosition_OnContract.gostujuciPredavac);

            testFax.ListOfDefiniteContractEmployees[0].StartOfContract = new DateTime(2018, 1, 1);
            DateTime contractStart = testFax.ListOfDefiniteContractEmployees[0].StartOfContract;
            Assert.AreEqual(contractStart, new DateTime(2018, 1, 1));

            testFax.ListOfDefiniteContractEmployees[0].EndOfContract = new DateTime(2021, 1, 1);
            DateTime contractEnd = testFax.ListOfDefiniteContractEmployees[0].EndOfContract;
            Assert.AreEqual(contractEnd, new DateTime(2021, 1, 1));

            testFax.ListOfDefiniteContractEmployees[0].NumberOfClassesWeekly = 15;
            int classes = testFax.ListOfDefiniteContractEmployees[0].NumberOfClassesWeekly;
            Assert.AreEqual(classes, 15);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_definiteEmp_InvalidNameInput()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("nam22e#", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_definiteEmp_InvalidSurameInput()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "s24urn$$ame", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_definiteEmp_InvalidDateOfBirth()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(2020, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_definiteEmp_InvaliStartOfContract_BeforeToday()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2009, 1, 1), new DateTime(2019, 1, 1), 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_definiteEmp_InvaliStartOfContract_AfterEnd()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2025, 1, 1), new DateTime(2019, 1, 1), 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_definiteEmp_NegativeNmbOfClasses()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), -10);
        }

        [TestMethod]
        public void TestMethod_DeletingDefiniteEmployee_ByID()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddDefiniteEmployee("name", "surname", new DateTime(1970, 1, 1), "5555555555555", employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10);
            Assert.AreEqual(testFax.ListOfEmployees.Count, 1);
            Assert.AreEqual(testFax.ListOfDefiniteContractEmployees.Count, 1);

            testFax.deleteEmployeeByID("5555555555555");
            Assert.AreEqual(testFax.ListOfEmployees.Count, 0);
            Assert.AreEqual(testFax.ListOfDefiniteContractEmployees.Count, 0);
        }
    }
}
