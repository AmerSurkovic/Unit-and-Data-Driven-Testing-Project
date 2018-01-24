using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using System.Collections.Generic;

namespace Fakultet_UnitTesting
{
    [TestClass]
    public class Functionalities_Courses
    {
        /* Adding of course to the container class of Faculty */
        [TestMethod]
        public void TestMethod_AddingCourse()
        {
            Faculty testFax = new Faculty("ETF");

            /* public Course(int courseCode, string courseName, studyLevel level, int numberOfLectures, int numberOfExercies, int ECTS, List<Employee> teachingEnsamble) */
            List<Employee> ensamble = new List<Employee>();
            Course input = new Course(1234, "testSubject", studyLevel.bachelor, 45, 45, 5, ensamble);
            testFax.AddCourse(input);
        }

        /* Validating if input data is stored correctly within container class */
        [TestMethod]
        public void TestMethod_CourseInputValidity()
        {
            Faculty testFax = new Faculty("ETF");

            List<Employee> ensamble = new List<Employee>();
            Course input = new Course(1234, "testSubject", studyLevel.bachelor, 45, 45, 5, ensamble);
            testFax.AddCourse(input);

            int corCode = testFax.ListOfCourses[0].CourseCode;
            Assert.AreEqual(corCode, 1234);

            string name = testFax.ListOfCourses[0].CourseName;
            Assert.AreEqual(name, "testSubject");

            studyLevel level = testFax.ListOfCourses[0].Level;
            Assert.AreEqual(level, studyLevel.bachelor);

            int nmbLectures = testFax.ListOfCourses[0].NumberOfLectures;
            Assert.AreEqual(nmbLectures, 45);

            int nmbExercices = testFax.ListOfCourses[0].NumberOfExercises;
            Assert.AreEqual(nmbExercices, 45);

            int ects = testFax.ListOfCourses[0].ECTS;
            Assert.AreEqual(ects, 5);

            List<Employee> testEns = testFax.ListOfCourses[0].TeachingEnsamble;
            Assert.AreEqual(ensamble, testEns);
        }

        [TestMethod]
        public void TestMethod_GetterInfoValidity()
        {
            Faculty testFax = new Faculty("ETF");

            List<Employee> ensamble = new List<Employee>();
            Course input = new Course(1234, "testSubject", studyLevel.bachelor, 45, 45, 5, ensamble);
            testFax.AddCourse(input);

            testFax.ListOfCourses[0].CourseCode = 1222;
            int corCode = testFax.ListOfCourses[0].CourseCode;
            Assert.AreEqual(corCode, 1222);

            testFax.ListOfCourses[0].CourseName = "change";
            string name = testFax.ListOfCourses[0].CourseName;
            Assert.AreEqual(name, "change");

            testFax.ListOfCourses[0].Level = studyLevel.master;
            studyLevel level = testFax.ListOfCourses[0].Level;
            Assert.AreEqual(level, studyLevel.master);

            testFax.ListOfCourses[0].NumberOfLectures = 50;
            int nmbLectures = testFax.ListOfCourses[0].NumberOfLectures;
            Assert.AreEqual(nmbLectures, 50);

            testFax.ListOfCourses[0].NumberOfExercises = 50;
            int nmbExercices = testFax.ListOfCourses[0].NumberOfExercises;
            Assert.AreEqual(nmbExercices, 50);

            testFax.ListOfCourses[0].ECTS = 7;
            int ects = testFax.ListOfCourses[0].ECTS;
            Assert.AreEqual(ects, 7);

        }


    }
}
