using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using System.Collections.Generic;

namespace Fakultet_UnitTesting
{
    [TestClass]
    public class UnitTests_masterStudent
    {
        [TestMethod]
        public void TestMethod_mStudent_creatingInstance()
        {
            // Parameters: string name, string surname, DateTime dateOfBirth, string IDnumber, string indexIDnumber, DateTime endOfPreviousEducation, string placeOfPreviousEd)
            masterStudent testUnit = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "111/16781", new DateTime(2005, 1, 1), "ETF Sarajevo");
        }

        [TestMethod]
        public void TestMethod_mStudent_equality()
        {
            // Students are equal if index ID number is the same.
            masterStudent testUnit1 = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "111/16781", new DateTime(2016, 1, 1), "ETF Sarajevo");
            masterStudent testUnit2 = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "111/16781", new DateTime(2016, 1, 1), "ETF Sarajevo");
            Assert.AreEqual(testUnit1, testUnit2);
        }

        [TestMethod]
        public void TestMethod_mStudent_inequality()
        {
            // Students are equal if index ID number is the same.
            masterStudent testUnit1 = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "111/16781", new DateTime(2016, 1, 1), "ETF Sarajevo");
            masterStudent testUnit2 = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "111/16782", new DateTime(2016, 1, 1), "ETF Sarajevo");
            Assert.AreNotEqual(testUnit1, testUnit2);
        }

        #region Setters

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_mStudent_invalidIndexId_underFlow() // Invalid index ID - numeric (must be 13 letters)
        {
            masterStudent testUnit1 = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "111/1671", new DateTime(2016, 1, 1), "ETF Sarajevo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_mStudent_invalidIndexId_overFlow() // Invalid index ID - numeric (must be 13 letters)
        {
            masterStudent testUnit1 = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "111/167812", new DateTime(2016, 1, 1), "ETF Sarajevo");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_mStudent_invalidIndexId_numeric() // Invalid index ID - numeric (must be 13 letters)
        {
            masterStudent testUnit1 = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "111/16a#1", new DateTime(2016, 1, 1), "ETF Sarajevo");
        }

        #endregion

        #region Getters

        [TestMethod]
        public void TestMethod_mStudent_Getters()
        {
            masterStudent testUnit = new masterStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "111/16781", new DateTime(2005, 1, 1), "ETF Sarajevo");

            string name = testUnit.Name;
            Assert.AreEqual(name, "name");

            string surname = testUnit.Surname;
            Assert.AreEqual(surname, "surname");

            DateTime birth = testUnit.DateOfBirth;
            Assert.AreEqual(birth, new DateTime(1990, 1, 1));

            string ID = testUnit.IDnumber;
            Assert.AreEqual(ID, "1111111111111");

            string index = testUnit.IndexIDNumber;
            Assert.AreEqual(index, "111/16781");

            DateTime endOfPrevEd = testUnit.EndOfPreviousEducation;
            Assert.AreEqual(endOfPrevEd, new DateTime(2005, 1, 1));

            string placeOfPrevEd = testUnit.PlaceOfPreviousEd;
            Assert.AreEqual(placeOfPrevEd, "ETF Sarajevo");

            List<Course> lista = new List<Course>();
            testUnit.PassedCourses = lista;
            Assert.AreEqual(lista, testUnit.PassedCourses);
        }

        #endregion

    }
}

