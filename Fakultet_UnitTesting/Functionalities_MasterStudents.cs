using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fakultet_UnitTesting
{
    [TestClass]
    public class Functionalities_MasterStudents
    {
        private static readonly Regex MASTER_INDEX_ID_NUMBER_PATTERN = new Regex("^[0-9]{3}/[0-9]{5}$");

        /* Testing input of master student in Faculty container class */
        [TestMethod]
        public void TestMethod_InputMasterStudent()
        {
            Faculty testFax = new Faculty("ETF");

            /* We are sending instance of bachelor student 
             * without index number because container
             * class "Faculty" is generating index for us.
             */
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");
        }

        #region Error handling for wrong input
        /* In this region we will test if the exception is thrown if we try
         * to input wrong form of data as a part of creating object
         * masterStudent through the container object "Faculty"
         */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_mStudent_invalidName() // Invalid name
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddMasterStudent("nam$$e", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2016, 1, 1), "ETF Sarajevo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_mStudent_invalidSurname() // Invalid surname
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddMasterStudent("name", "surn@@ame", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2016, 1, 1), "ETF Sarajevo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_mStudent_invalidBirthDate() // Invalid birth date
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddMasterStudent("name", "surname", new DateTime(2017, 1, 1), "1111111111111", new DateTime(2016, 1, 1), "ETF Sarajevo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_mStudent_invalidPersonId_underflow() // Invalid person ID - underflow (must be 13 letters)
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "111111111111", new DateTime(2016, 1, 1), "ETF Sarajevo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_mStudent_invalidPersonIdCTOR_overflow() // Invalid person ID - overflow (must be 13 letters)
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "11111111111111", new DateTime(2016, 1, 1), "ETF Sarajevo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_mStudent_invalidPersonId_numeric() // Invalid person ID - numeric (must be 13 letters)
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "11111111111a#", new DateTime(2016, 1, 1), "ETF Sarajevo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_mStudent_invalidDateOfPreviousEd() // Invalid date of previous education
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2020, 1, 1), "ETF Sarajevo");
        }

        #endregion

        /* Testing validity of generated index from the Faculty container class */
        [TestMethod]
        public void TestMethod_master_GeneratedIndexValidity()
        {
            Faculty testFax = new Faculty("ETF");

            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");
            string index = testFax.ListOfMasterStudents[0].IndexIDNumber;
            /* Container class "Faculty" has default
             * start master index value at 100/17000
             */
            Assert.AreEqual(index, "100/17000");
            StringAssert.Contains(index, "/");
            StringAssert.Matches(index, MASTER_INDEX_ID_NUMBER_PATTERN);
            StringAssert.EndsWith(index, "17000");
        }

        /* Testing if the information we sent to container class
         * for the new master student is processed correctly
         * by asking for the return values for all of the sent parameters.
         */
        [TestMethod]
        public void TestMethod_master_GetterInfoValidity()
        {
            Faculty testFax = new Faculty("ETF");

            /* We are sending instance of bachelor student 
             * without index number because container
             * class "Faculty" is generating index for us.
             */
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");
            string index = testFax.ListOfMasterStudents[0].IndexIDNumber;
            Assert.AreEqual(index, "100/17000");

            string name = testFax.ListOfMasterStudents[0].Name;
            Assert.AreEqual(name, "name");

            string surname = testFax.ListOfMasterStudents[0].Surname;
            Assert.AreEqual(surname, "surname");

            DateTime birth = testFax.ListOfMasterStudents[0].DateOfBirth;
            Assert.AreEqual(birth, new DateTime(1990, 1, 1));

            string ID = testFax.ListOfMasterStudents[0].IDnumber;
            Assert.AreEqual(ID, "1111111111111");

            DateTime endOfPrevEd = testFax.ListOfMasterStudents[0].EndOfPreviousEducation;
            Assert.AreEqual(endOfPrevEd, new DateTime(2005, 1, 1));

            string exEdplace = testFax.ListOfMasterStudents[0].PlaceOfPreviousEd;
            Assert.AreEqual(exEdplace, "ETF Sarajevo");

            /* Adding passed courses for the student */
            List<Course> passed = new List<Course>();
            testFax.ListOfMasterStudents[0].PassedCourses = passed;
            Assert.AreEqual(passed, testFax.ListOfMasterStudents[0].PassedCourses);
        }

        /* Testing if the changes to the parameters of the master student
         * in the list of master students are processed correctly.
         */
        [TestMethod]
        public void TestMethod_master_SetterInfoValidity()
        {
            Faculty testFax = new Faculty("ETF");

            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");

            string index = testFax.ListOfMasterStudents[0].IndexIDNumber;
            Assert.AreEqual(index, "100/17000");

            testFax.ListOfMasterStudents[0].Name = "changedName";
            string name = testFax.ListOfMasterStudents[0].Name;
            Assert.AreEqual(name, "changedName");

            testFax.ListOfMasterStudents[0].Surname = "changedSurname";
            string surname = testFax.ListOfMasterStudents[0].Surname;
            Assert.AreEqual(surname, "changedSurname");

            testFax.ListOfMasterStudents[0].DateOfBirth = new DateTime(1994, 1, 1);
            DateTime birth = testFax.ListOfMasterStudents[0].DateOfBirth;
            Assert.AreEqual(birth, new DateTime(1994, 1, 1));

            testFax.ListOfMasterStudents[0].IDnumber = "2222222222222";
            string ID = testFax.ListOfMasterStudents[0].IDnumber;
            Assert.AreEqual(ID, "2222222222222");

            testFax.ListOfMasterStudents[0].EndOfPreviousEducation = new DateTime(2006, 1, 1);
            DateTime endOfPrevEd = testFax.ListOfMasterStudents[0].EndOfPreviousEducation;
            Assert.AreEqual(endOfPrevEd, new DateTime(2006, 1, 1));

            testFax.ListOfMasterStudents[0].PlaceOfPreviousEd = "changedPlace";
            string exEd = testFax.ListOfMasterStudents[0].PlaceOfPreviousEd;
            Assert.AreEqual(exEd, "changedPlace");

            /* Setting new list of passed courses for the student */
            List<Course> passed = new List<Course>();
            testFax.ListOfMasterStudents[0].PassedCourses = passed;
            List<Course> passedChanged = new List<Course>();
            testFax.ListOfMasterStudents[0].PassedCourses = passedChanged;
            Assert.AreEqual(passedChanged, testFax.ListOfMasterStudents[0].PassedCourses);

        }

        /* Testing insertion of more master students
         * in the list of Faculty container class.
         * All of the generated indicies should be unique
         * and itterated from the start value of 100 and 17000!
         */
        [TestMethod]
        public void TestMethod_InputMoreMasterStudents()
        {
            Faculty testFax = new Faculty("ETF");

            /* Container class "Faculty" has default
             * start bachelor index value at 17000.
             * Two of the additional students added
             * to the list should have indices
             * "17001" and "17002".
             */
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");
            string index = testFax.ListOfMasterStudents[0].IndexIDNumber;
            Assert.AreEqual(index, "100/17000");

            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111112", new DateTime(2005, 1, 1), "ETF Sarajevo");
            index = testFax.ListOfMasterStudents[1].IndexIDNumber;
            Assert.AreEqual(index, "101/17001");

            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111113", new DateTime(2005, 1, 1), "ETF Sarajevo");
            index = testFax.ListOfMasterStudents[2].IndexIDNumber;
            Assert.AreEqual(index, "102/17002");

            CollectionAssert.AllItemsAreUnique(testFax.ListOfMasterStudents);
            CollectionAssert.AllItemsAreUnique(testFax.ListOfAllStudent);
            CollectionAssert.AllItemsAreNotNull(testFax.ListOfMasterStudents);
            CollectionAssert.IsSubsetOf(testFax.ListOfMasterStudents, testFax.ListOfAllStudent);
        }

        /* Testing if the exception is handled when
         * we try to input more master students
         * with the same ID.
         */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_InputMoreMasterStudents_SameID()
        {
            Faculty testFax = new Faculty("ETF");

            /* We are sending instance of bachelor student 
             * without index number because container
             * class "Faculty" is generating index for us.
             */
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");
            string index = testFax.ListOfMasterStudents[0].IndexIDNumber;

            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");
            index = testFax.ListOfMasterStudents[1].IndexIDNumber;

            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");
            index = testFax.ListOfMasterStudents[2].IndexIDNumber;
            /* Exception should be thrown
             * because all instances of students
             * have the same ID.
             */
        }

        /* Testing input of master student in Faculty container class
         * when student is trasnfering from bachelor programme. 
         */
        [TestMethod]
        public void TestMethod_InputMasterStudent_ifBachelorStudentExists()
        {
            Faculty testFax = new Faculty("ETF");

            /* We are adding bachelor student */
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));
            /* List of all bachelor students and all students should be 1. */
            Assert.AreEqual(testFax.ListOfBachelorStudents.Count, 1);
            Assert.AreEqual(testFax.ListOfAllStudent.Count, 1);
            /* Index number of entered student should be 17000 */
            Assert.AreEqual(testFax.ListOfBachelorStudents[0].IndexIDNumber, "17000");

            /* We are adding master student with same person ID! */
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");
            /* Now, there should be 0 bachelor students and 1 master student in container class */
            Assert.AreEqual(testFax.ListOfBachelorStudents.Count, 0);
            Assert.AreEqual(testFax.ListOfMasterStudents.Count, 1);
            /* Master student index should be his last index (17000) with added 100 as generated by the container class */
            Assert.AreEqual(testFax.ListOfMasterStudents[0].IndexIDNumber, "100/17000");
            /* List of all students should remain at 1 */
            Assert.AreEqual(testFax.ListOfAllStudent.Count, 1);

        }

        /* Testing if the exception is handled
         * when we try to assign the list of
         * bachelor students.
         */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_AssigningListOfMasterStudents()
        {
            Faculty testFax = new Faculty("ETF");

            masterStudent unit1 = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "100/16781", new DateTime(2005, 1, 1), "ETF Sarajevo");
            masterStudent unit2 = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111112", "100/16782", new DateTime(2005, 1, 1), "ETF Sarajevo");
            masterStudent unit3 = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111113", "100/16783", new DateTime(2005, 1, 1), "ETF Sarajevo");
            List<masterStudent> input = new List<masterStudent>();

            testFax.ListOfMasterStudents = input;
            /* List of master students cannot be 
             * assigned because we don't know if the list
             * is valid for system input
             */
        }

        [TestMethod]
        public void TestMethod_DeletingMasterStudent_ByID()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");
            Assert.AreEqual(testFax.ListOfAllStudent.Count, 1);
            Assert.AreEqual(testFax.ListOfMasterStudents.Count, 1);

            testFax.deleteStudentByID("1111111111111");
            Assert.AreEqual(testFax.ListOfAllStudent.Count, 0);
            Assert.AreEqual(testFax.ListOfMasterStudents.Count, 0);
        }

        [TestMethod]
        public void TestMethod_DeletingMasterStudent_ByIndex()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddMasterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1), "ETF Sarajevo");
            Assert.AreEqual(testFax.ListOfAllStudent.Count, 1);
            Assert.AreEqual(testFax.ListOfMasterStudents.Count, 1);

            string index = testFax.ListOfMasterStudents[0].IndexIDNumber;

            testFax.deleteStudentByIndex(index);
            Assert.AreEqual(testFax.ListOfAllStudent.Count, 0);
            Assert.AreEqual(testFax.ListOfMasterStudents.Count, 0);
        }
    }
}
