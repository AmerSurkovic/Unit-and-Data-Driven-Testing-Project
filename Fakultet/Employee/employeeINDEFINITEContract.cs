using Fakultet.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fakultet
{
    public class employeeINDEFINITEContract : Employee
    {

        private employmentPosition_indefinitePeriod _employeePosition;
        private double _norm; // norma
        private string _jobQualification; // strucna sprema
        private string _title; // titula

        public employeeINDEFINITEContract(string name, string surname, DateTime dateOfBirth, string IDnumber, int employeeID, employmentPosition_indefinitePeriod employeePosition, double norm, string jobQualification, string title) : base(name, surname, dateOfBirth, IDnumber, employeeID)
        {
            EmployeePosition = employeePosition;
            Norm = norm;
            JobQualification = jobQualification;
            Title = title;

            if (employeePosition == employmentPosition_indefinitePeriod.asistent)
            {
                Salary = norm * 1100;
            }
            else if (employeePosition == employmentPosition_indefinitePeriod.visiAsistent)
            {
                Salary = norm * 1300;
            }
            else if (employeePosition == employmentPosition_indefinitePeriod.docent)
            {
                Salary = (norm + 0.1) * 1300;
            }
            else if (employeePosition == employmentPosition_indefinitePeriod.vanredniProfesor)
            {
                Salary = (norm + 0.2) * 1300 + 150;
            }
            else if (employeePosition == employmentPosition_indefinitePeriod.redovniProfesor)
            {
                Salary = (norm + 0.3) * 1500;
            }
            else if (employeePosition == employmentPosition_indefinitePeriod.akademik)
            {
                Salary = (norm + 0.3) * 2000;
            }
        }

        public employmentPosition_indefinitePeriod EmployeePosition
        {
            get { return _employeePosition; }
            set { _employeePosition = value; }
        }

        public double Norm
        {
            get { return _norm; }
            set
            {
                if(value<0.5 || value > 1.5)
                {
                    throw new ArgumentException("Given norm value is not correct");
                }
                _norm = value;
            }
        }

        public string JobQualification
        {
            get { return _jobQualification; }
            set { _jobQualification = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public override double Salary
        {
            get { return base.Salary; }
            set { base.Salary = value; }
                
        }
        
    }
}
