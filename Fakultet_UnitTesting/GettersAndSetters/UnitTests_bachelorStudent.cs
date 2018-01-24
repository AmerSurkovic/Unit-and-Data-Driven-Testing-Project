using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fakultet;
using System.Collections.Generic;

namespace Fakultet_UnitTesting
{
    [TestClass]
    public class UnitTests_bachelorStudent
    {
        [TestMethod]
        public void TestMethod_bStudent_creatingInstance()
        {
            // Parameters: bachelorStudent(string name, string surname, DateTime dateOfBirth, string IDnumber, string indexIDnumber, DateTime endOfPreviousEducation) : base(name, surname, dateOfBirth, IDnumber, indexIDnumber, endOfPreviousEducation)
            bachelorStudent testUnit = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "16781", new DateTime(2005, 1, 1));
        }

        [TestMethod]
        public void TestMethod_bStudent_equality()
        {
            // Students are equal if index ID number is the same.
            bachelorStudent testUnit1 = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "16781", new DateTime(2016, 1, 1));
            bachelorStudent testUnit2 = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "16781", new DateTime(2016, 1, 1));
            Assert.AreEqual(testUnit1, testUnit2);
        }

        [TestMethod]
        public void TestMethod_bStudent_inequality()
        {
            // Students are equal if index ID number is the same.
            bachelorStudent testUnit1 = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "16781", new DateTime(2016, 1, 1));
            bachelorStudent testUnit2 = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "16782", new DateTime(2016, 1, 1));
            Assert.AreNotEqual(testUnit1, testUnit2);
        }

        #region Setters
        /* These set of setter errors could not have been tested within Faculty container class */

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_bStudent_invalidIndexId_underFlow() // Invalid index ID - numeric (must be 13 letters)
        {
            bachelorStudent testUnit1 = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "1671", new DateTime(2016, 1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_bStudent_invalidIndexId_overFlow() // Invalid index ID - numeric (must be 13 letters)
        {
            bachelorStudent testUnit1 = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "167812", new DateTime(2016, 1, 1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMethod_bStudent_invalidIndexId_numeric() // Invalid index ID - numeric (must be 13 letters)
        {
            bachelorStudent testUnit1 = new bachelorStudent("name", "surname", new DateTime(1990, 1, 1), "1111111111111", "16a#1", new DateTime(2016, 1, 1));
        }

        #endregion

    }
}
