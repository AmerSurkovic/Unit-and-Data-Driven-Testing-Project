using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using Fakultet.Interfaces;
using Fakultet.Stub_Objects;
using Fakultet.Enumerations;

namespace Fakultet_UnitTesting
{
    /// <summary>
    /// Summary description for Functionalities_StubObject
    /// </summary>
    [TestClass]
    public class Functionalities_StubObject
    {
        [TestMethod]
        public void ICourse_testingGeneralInformation()
        {
            Faculty testFax = new Faculty("ETF");

            List<ICourse> testCourses = new List<ICourse>();
            testCourses.Add(new stubCourse());
            testFax.TestCourses = testCourses;

            Assert.AreEqual(testFax.TestCourses[0].generalInformation(), "infoAboutCourse");
        }

        [TestMethod]
        public void ICourse_ECTSInHours()
        {
            Faculty testFax = new Faculty("ETF");

            List<ICourse> testCourses = new List<ICourse>();
            testCourses.Add(new stubCourse());
            testFax.TestCourses = testCourses;

            Assert.AreEqual(testFax.TestCourses[0].ECTSinHours(), 100.5);
        }

        [TestMethod]
        public void ICourse_teachingEnsamble()
        {
            Faculty testFax = new Faculty("ETF");

            List<ICourse> testCourses = new List<ICourse>();
            testCourses.Add(new stubCourse());
            testFax.TestCourses = testCourses;

            IList<Employee> employees = new List<Employee>();

            for (int i = 0; i < 10; i++)
            {
                employees.Add(new employeeDEFINITEContract("name", "surname", new DateTime(1970, 1, 1), "5555555555555", i, employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10));
            }

            IList<Employee> getEmployees = testFax.TestCourses[0].teachingEnsamble();
            CollectionAssert.Equals(getEmployees as List<Employee>, employees as List<Employee>);
        }

    }
}
