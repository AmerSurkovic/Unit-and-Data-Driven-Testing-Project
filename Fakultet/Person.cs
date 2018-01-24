using Fakultet.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fakultet
{
    public abstract class Person
    {
        private static readonly Regex ID_NUMBER_PATTERN = new Regex("^[0-9]{13}$");

        private string _name;
        private string _surname;
        private DateTime _dateOfBirth;
        private string _IDnumber; // maticni broj

        public Person(string name, string surname, DateTime dateOfBirth, string idNumber)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            IDnumber = idNumber;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (!Validator.ValidateAlphaNumeric(value))
                {
                    throw new ArgumentException("Provided name is not valid");
                }
                _name = value;
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if(!Validator.ValidateAlphaNumeric(value))
                {
                    throw new ArgumentException("Provided surname is not valid");
                }
                _surname = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentException("Given birth date is not valid");
                }
                _dateOfBirth = value;
            }
        }

        public string IDnumber
        {
            get { return _IDnumber; }
            set {
                if (ID_NUMBER_PATTERN.IsMatch(value) == false)
                {
                    throw new ArgumentException("Provided ID number is not valid");
                }
                _IDnumber = value;
            }
        }
    }
}
