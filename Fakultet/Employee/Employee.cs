using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet
{
    public abstract class Employee : Person
    {
        private double _salary;
        private int _employeeID;

        public Employee(string name, string surname, DateTime dateOfBirth, string IDnumber, int employeeID) : base(name, surname, dateOfBirth, IDnumber)
        {
            EmploymentID = employeeID;
        }

        public int EmploymentID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        public virtual double Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
    }
}
