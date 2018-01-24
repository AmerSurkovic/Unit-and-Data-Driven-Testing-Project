using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Fakultet_UnitTesting
{
    [TestClass]
    public class Functionalities_BachelorStudents
    {
        private static readonly Regex INDEX_ID_NUMBER_PATTERN = new Regex("^[0-9]{5}$");


        /* Testing input of bachelor student in Faculty container class */
        [TestMethod]
        public void TestMethod_InputBachelorStudent()
        {
            Faculty testFax = new Faculty("ETF");
            
            /* We are sending instance of bachelor student 
             * without index number because container
             * class "Faculty" is generating index for us.
             */
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));            
        }

        #region Error handling for wrong input
        /* In this region we will test if the exception is thrown if we try
         * to input wrong form of data as a part of creating object
         * bachelorStudent through the container object "Faculty"
         */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_bStudent_invalidName() // Invalid name
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent("nam$$e", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2016, 1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_bStudent_invalidSurname() // Invalid surname
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent("name", "surn@@ame", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2016, 1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_bStudent_invalidBirthDate() // Invalid birth date
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent("name", "surname", new DateTime(2017, 1, 1), "1111111111111", new DateTime(2016, 1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_bStudent_invalidPersonId_underflow() // Invalid person ID - underflow (must be 13 letters)
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "111111111111", new DateTime(2016, 1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_bStudent_invalidPersonIdCTOR_overflow() // Invalid person ID - overflow (must be 13 letters)
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "11111111111111", new DateTime(2016, 1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_bStudent_invalidPersonId_numeric() // Invalid person ID - numeric (must be 13 letters)
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "11111111111a#", new DateTime(2016, 1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_bStudent_invalidDateOfPreviousEd() // Invalid date of previous education
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2020, 1, 1));
        }

        #endregion

        /* Testing validity of generated index from the Faculty container class */
        [TestMethod]
        public void TestMethod_bachelor_GeneratedIndexValidity()
        {
            Faculty testFax = new Faculty("ETF");

            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));
            string index = testFax.ListOfBachelorStudents[0].IndexIDNumber;
            /* Container class "Faculty" has default
             * start bachelor index value at 17000
             */
            Assert.AreEqual(index, "17000");
            StringAssert.Matches(index, INDEX_ID_NUMBER_PATTERN);
        }

        /* Testing if the information we sent to container class
         * for the new bachelor student is processed correctly
         * by asking for the return values for all of the sent parameters.
         */
        [TestMethod]
        public void TestMethod_bachelor_GetterInfoValidity()
        {
            Faculty testFax = new Faculty("ETF");

            /* We are sending instance of bachelor student 
             * without index number because container
             * class "Faculty" is generating index for us.
             */
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));
            string index = testFax.ListOfBachelorStudents[0].IndexIDNumber;
            Assert.AreEqual(index, "17000");
            string name = testFax.ListOfBachelorStudents[0].Name;
            Assert.AreEqual(name, "name");
            string surname = testFax.ListOfBachelorStudents[0].Surname;
            Assert.AreEqual(surname, "surname");
            DateTime birth = testFax.ListOfBachelorStudents[0].DateOfBirth;
            Assert.AreEqual(birth, new DateTime(1990, 1, 1));
            string ID = testFax.ListOfBachelorStudents[0].IDnumber;
            Assert.AreEqual(ID, "1111111111111");
            DateTime endOfPrevEd = testFax.ListOfBachelorStudents[0].EndOfPreviousEducation;
            Assert.AreEqual(endOfPrevEd, new DateTime(2005, 1, 1));

            /* Adding passed courses for the student */
            List<Course> passed = new List<Course>();
            testFax.ListOfBachelorStudents[0].PassedCourses = passed;
            Assert.AreEqual(passed, testFax.ListOfBachelorStudents[0].PassedCourses);
        }

        /* Testing if the changes to the parameters of the bachelor student
         * in the list of bachelor students are processed correctly.
         */
        [TestMethod]
        public void TestMethod_bachelor_SetterInfoValidity()
        {
            Faculty testFax = new Faculty("ETF");

            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));

            string index = testFax.ListOfBachelorStudents[0].IndexIDNumber;
            Assert.AreEqual(index, "17000");

            testFax.ListOfBachelorStudents[0].Name = "changedName";
            string name = testFax.ListOfBachelorStudents[0].Name;
            Assert.AreEqual(name, "changedName");

            testFax.ListOfBachelorStudents[0].Surname = "changedSurname";
            string surname = testFax.ListOfBachelorStudents[0].Surname;
            Assert.AreEqual(surname, "changedSurname");

            testFax.ListOfBachelorStudents[0].DateOfBirth = new DateTime(1994,1,1);
            DateTime birth = testFax.ListOfBachelorStudents[0].DateOfBirth;
            Assert.AreEqual(birth, new DateTime(1994, 1, 1));

            testFax.ListOfBachelorStudents[0].IDnumber = "2222222222222";
            string ID = testFax.ListOfBachelorStudents[0].IDnumber;
            Assert.AreEqual(ID, "2222222222222");

            testFax.ListOfBachelorStudents[0].EndOfPreviousEducation = new DateTime(2006, 1, 1);
            DateTime endOfPrevEd = testFax.ListOfBachelorStudents[0].EndOfPreviousEducation;
            Assert.AreEqual(endOfPrevEd, new DateTime(2006, 1, 1));

            /* Setting new list of passed courses for the student */
            List<Course> passed = new List<Course>();
            testFax.ListOfBachelorStudents[0].PassedCourses = passed;
            List<Course> passedChanged = new List<Course>();
            testFax.ListOfBachelorStudents[0].PassedCourses = passedChanged;
            Assert.AreEqual(passedChanged, testFax.ListOfBachelorStudents[0].PassedCourses);

        }

        /* Testing insertion of more bachelor students
         * in the list of Faculty container class.
         * All of the generated indicies should be unique
         * and itterated from the start value of 17000!
         */
        [TestMethod]
        public void TestMethod_InputMoreBachelorStudents()
        {
            Faculty testFax = new Faculty("ETF");

            /* Container class "Faculty" has default
             * start bachelor index value at 17000.
             * Two of the additional students added
             * to the list should have indices
             * "17001" and "17002".
             */
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));
            string index = testFax.ListOfBachelorStudents[0].IndexIDNumber;
            Assert.AreEqual(index, "17000");

            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111112", new DateTime(2005, 1, 1));
            index = testFax.ListOfBachelorStudents[1].IndexIDNumber;
            Assert.AreEqual(index, "17001");

            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111113", new DateTime(2005, 1, 1));
            index = testFax.ListOfBachelorStudents[2].IndexIDNumber;
            Assert.AreEqual(index, "17002");

            CollectionAssert.AllItemsAreUnique(testFax.ListOfBachelorStudents);
            CollectionAssert.AllItemsAreUnique(testFax.ListOfAllStudent);
            CollectionAssert.AllItemsAreNotNull(testFax.ListOfBachelorStudents);
            CollectionAssert.IsSubsetOf(testFax.ListOfBachelorStudents, testFax.ListOfAllStudent);
        }

        /* Testing if the exception is handled when
         * we try to input more bachelor students
         * with the same ID.
         */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_InputMoreBachelorStudents_SameID()
        {
            Faculty testFax = new Faculty("ETF");

            /* We are sending instance of bachelor student 
             * without index number because container
             * class "Faculty" is generating index for us.
             */
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));
            string index = testFax.ListOfBachelorStudents[0].IndexIDNumber;

            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));
            index = testFax.ListOfBachelorStudents[1].IndexIDNumber;

            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));
            index = testFax.ListOfBachelorStudents[2].IndexIDNumber;
            /* Exception should be thrown
             * because all instances of students
             * have the same ID.
             */
        }

        /* Testing if the exception is handled
         * when we try to assign the list of
         * bachelor students.
         */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_AssigningListOfBachelorStudents()
        {
            Faculty testFax = new Faculty("ETF");

            bachelorStudent unit1 = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "16781", new DateTime(2005, 1, 1));
            bachelorStudent unit2 = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111112", "16782", new DateTime(2005, 1, 1));
            bachelorStudent unit3 = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111113", "16783", new DateTime(2005, 1, 1));
            List<bachelorStudent> input = new List<bachelorStudent>();

            testFax.ListOfBachelorStudents = input;
            /* List of bachelor students cannot be 
             * assigned because we don't know if the list
             * is valid for system input
             */
        }

        [TestMethod]
        public void TestMethod_DeletingBachelorStudent_ByID()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));
            Assert.AreEqual(testFax.ListOfAllStudent.Count, 1);
            Assert.AreEqual(testFax.ListOfBachelorStudents.Count, 1);

            testFax.deleteStudentByID("1111111111111");
            Assert.AreEqual(testFax.ListOfAllStudent.Count, 0);
            Assert.AreEqual(testFax.ListOfBachelorStudents.Count, 0);
        }

        [TestMethod]
        public void TestMethod_DeletingBachelorStudent_ByIndex()
        {
            Faculty testFax = new Faculty("ETF");
            testFax.AddBachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", new DateTime(2005, 1, 1));
            Assert.AreEqual(testFax.ListOfAllStudent.Count, 1);
            Assert.AreEqual(testFax.ListOfBachelorStudents.Count, 1);

            string index = testFax.ListOfBachelorStudents[0].IndexIDNumber;

            testFax.deleteStudentByIndex(index);
            Assert.AreEqual(testFax.ListOfAllStudent.Count, 0);
            Assert.AreEqual(testFax.ListOfBachelorStudents.Count, 0);
        }

    }
}
