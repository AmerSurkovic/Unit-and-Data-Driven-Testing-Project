using Fakultet.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet
{
    public class employeeDEFINITEContract : Employee
    {
        private employmentPosition_OnContract _employeePosition;

        private DateTime _startOfContract; // pocetak ugovora
        private DateTime _endOfContract; // kraj ugovora
        private int _numberOfClasesWeekly; // broj casova sedmicno

        public employeeDEFINITEContract(string name, string surname, DateTime dateOfBirth, string IDnumber, int employeeID, employmentPosition_OnContract employeePosition, DateTime startOfContract, DateTime endOfContract, int numberOfClassesWeekly) : base(name, surname, dateOfBirth, IDnumber, employeeID)
        {
            if(startOfContract>endOfContract)
                throw new ArgumentException("Given start date of contract is not valid");

            EmployeePosition = employeePosition;
            StartOfContract = startOfContract;
            EndOfContract = endOfContract;
            NumberOfClassesWeekly = numberOfClassesWeekly;

            if (employeePosition == employmentPosition_OnContract.demonstrator)
            {
                Salary = (numberOfClassesWeekly * 10) * (endOfContract - startOfContract).TotalDays;
            }
            else if (employeePosition == employmentPosition_OnContract.gostujuciPredavac)
            {
                Salary = (numberOfClassesWeekly * 15) * (endOfContract - startOfContract).TotalDays;
            }
            else if (employeePosition == employmentPosition_OnContract.strucnjakIzPrakse)
            {
                Salary = (numberOfClassesWeekly * 20) + 150;
            }
        }

        public employmentPosition_OnContract EmployeePosition
        {
            get { return _employeePosition; }
            set { _employeePosition = value; }
        }

        public DateTime StartOfContract
        {
            get { return _startOfContract; }
            set
            {
                if (value < DateTime.Today)
                {
                    throw new ArgumentException("Given start date of contract is not valid");
                }
                _startOfContract = value;
            }
        }

        public DateTime EndOfContract
        {
            get { return _endOfContract; }
            set { _endOfContract = value; }
        }

        public int NumberOfClassesWeekly
        {
            get { return _numberOfClasesWeekly; }
            set
            {
                if(value<0)
                    throw new ArgumentException("Given number of classes is not valid");
                _numberOfClasesWeekly = value;
            }
        }

        public override double Salary
        {
            get { return base.Salary; }
            set { base.Salary = value; }
        }
    }
}
