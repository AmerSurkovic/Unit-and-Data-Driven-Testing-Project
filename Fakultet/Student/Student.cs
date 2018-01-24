using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fakultet
{
    abstract public class Student : Person
    {
        private DateTime _endOfPreviousEducation; // datum zavrsenja prethodnog obrazovanja
        private string _indexIDnumber; // broj indeksa
        private List<Course> _passedCourses; // polozeni predmeti

        public Student(string name, string surname, DateTime dateOfBirth, string IDnumber, string indexIDnumber, DateTime endOfPreviousEducation) : base(name, surname, dateOfBirth, IDnumber)
        {
            IndexIDNumber = indexIDnumber;
            EndOfPreviousEducation = endOfPreviousEducation;

            _passedCourses = new List<Course>();
        }

        public DateTime EndOfPreviousEducation
        {
            get { return _endOfPreviousEducation; }
            set
            {
                if (value > DateTime.Today)
                {
                    throw new ArgumentException("Given end date of previous education is not valid");
                }

                _endOfPreviousEducation = value;
            }
        }

        public virtual string IndexIDNumber
        { 
            get { return _indexIDnumber; } 
            set { _indexIDnumber = value; }
        }

        public List<Course> PassedCourses
        {
            get { return _passedCourses; }
            set { _passedCourses = value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                Student student = (Student)obj;
                return student.IndexIDNumber == IndexIDNumber;
            }
            return false;
        }
    }
}
