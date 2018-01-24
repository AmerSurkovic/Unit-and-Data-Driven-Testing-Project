using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fakultet
{
    public class masterStudent : Student
    {
        private static readonly Regex MASTER_INDEX_ID_NUMBER_PATTERN = new Regex("^[0-9]{3}/[0-9]{5}$");

        private string _placeOfPreviousEd; // mjesto zavrsetka bivseg obrazovanja

        public masterStudent(string name, string surname, DateTime dateOfBirth, string IDnumber, string indexIDnumber, DateTime endOfPreviousEducation, string placeOfPreviousEd) : base(name, surname, dateOfBirth, IDnumber, indexIDnumber, endOfPreviousEducation)
        {
            IndexIDNumber = indexIDnumber;
            PlaceOfPreviousEd = placeOfPreviousEd;
        }

        public string PlaceOfPreviousEd
        {
            get { return _placeOfPreviousEd; }
            set
            {
                _placeOfPreviousEd = value;
            }
        }

        public override string IndexIDNumber
        {
            get { return base.IndexIDNumber; }
            set
            {
                if (MASTER_INDEX_ID_NUMBER_PATTERN.IsMatch(value) == false)
                {
                    throw new ArgumentException("Provided ID index number is not valid");
                }
                base.IndexIDNumber = value;
            }
        }
    }
}
