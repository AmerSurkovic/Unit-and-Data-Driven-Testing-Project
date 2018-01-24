using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet.Mock_Objects;
using Fakultet;
using Fakultet.Enumerations;
using Fakultet.Interfaces;

namespace Fakultet_UnitTesting
{

    [TestClass]
    public class Functionalities_MockObject
    {
        Faculty testFax;  
        AssociateCourse_Mock testMock;
        IList<Employee> teachingEnsamble;

        [TestInitialize]
        public void setMockObject_AssociateCourse()
        {
            teachingEnsamble = new List<Employee>();
            for (int i = 0; i < 10; i++)
            {
                teachingEnsamble.Add(new employeeDEFINITEContract("name", "surname", new DateTime(1970, 1, 1), "5555555555555", i, employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10));
            }

            List<ICourse_Associate> testCourses = new List<ICourse_Associate>();
            testMock = new AssociateCourse_Mock(5544, "VVS", studyLevel.bachelor, 45, 45, 5, teachingEnsamble as List<Employee>);
            testCourses.Add(testMock);

            testFax = new Faculty("ETF");
            testFax.TestAssociateCourses = testCourses;
        }

        [TestMethod]
        public void ICourseAssociate_testingGeneralInformation()
        {
            StringAssert.Contains(testFax.TestAssociateCourses[0].generalInformation(), "5544");
            StringAssert.Contains(testFax.TestAssociateCourses[0].generalInformation(), "VVS");
            StringAssert.Contains(testFax.TestAssociateCourses[0].generalInformation(), "Kod kursa: 5544 Naziv kursa: VVS");
        }

        [TestMethod]
        public void ICourseAssociate_ECTSinHours()
        {
            Assert.AreEqual(testFax.TestAssociateCourses[0].ECTSinHours(), 5 * 5);
        }

        [TestMethod]
        public void ICourseAssociate_ExamValue()
        {
            Assert.AreEqual(testFax.TestAssociateCourses[0].ECTS_ExamValue(), 5 * 0.4);
        }

        [TestMethod]
        public void ICourseAssociate_HomeworkValue()
        {
            Assert.AreEqual(testFax.TestAssociateCourses[0].ECTS_HomeworkValue(), 5 * 0.1);
        }

        [TestMethod]
        public void ICourseAssociate_ProjectValue()
        {
            Assert.AreEqual(testFax.TestAssociateCourses[0].ECTS_ProjectValue(), 5 * 0.1);
        }

        [TestMethod]
        public void ICourseAssociate_SeminarValue()
        {
            Assert.AreEqual(testFax.TestAssociateCourses[0].ECTS_SeminarValue(), 5 * 0.1);
        }

        [TestMethod]
        public void ICourse_teachingEnsamble()
        {
            IList<Employee> employees = new List<Employee>();

            for (int i = 0; i < 10; i++)
            {
                employees.Add(new employeeDEFINITEContract("name", "surname", new DateTime(1970, 1, 1), "5555555555555", i, employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10));
            }

            IList<Employee> getEmployees = testFax.TestAssociateCourses[0].teachingEnsamble();
            CollectionAssert.Equals(getEmployees as List<Employee>, employees as List<Employee>);
        }

    }
}
