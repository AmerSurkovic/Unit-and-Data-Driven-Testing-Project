using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fakultet
{
    public class bachelorStudent : Student
    {
        private static readonly Regex INDEX_ID_NUMBER_PATTERN = new Regex("^[0-9]{5}$");

        public bachelorStudent(string name, string surname, DateTime dateOfBirth, string IDnumber, string indexIDnumber, DateTime endOfPreviousEducation) : base(name, surname, dateOfBirth, IDnumber, indexIDnumber, endOfPreviousEducation)
        {
        }

        public override string IndexIDNumber
        {
            get { return base.IndexIDNumber; }
            set
            {
                if (INDEX_ID_NUMBER_PATTERN.IsMatch(value) == false)
                {
                    throw new ArgumentException("Provided ID index number is not valid");
                }
                base.IndexIDNumber = value;
            }
        }
    }

}
