using Fakultet.Enumerations;
using Fakultet.Interfaces;
using Fakultet.Stub_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet
{
    public class Faculty
    {
        /* Will always be unique because for every
         * added student both are iterated.
         */
        private int bachelor_index_start;
        private int master_index_start;
        private int employee_ID_start;

        private double _income;
        private double _expenditure;
        private double _balance;
        public void balanceRefresh() { _balance = _income - _expenditure; }

        /* We are recieveing 9000 money units for Bachelor student
         * and 11000 money units for master student!
         */
        public double Balance { get { return _balance; } set { _balance = value; } }

        /* If WARNING flag is -1 then that will be indicated in
         * solution using this library
         */
        [Flags]
        public enum accountBalance { negative = -1, pozitive = 1 }
        private accountBalance _flag;
        public int FLAG
        {
            get
            {
                if (_flag == accountBalance.pozitive) return 1;
                else
                    return -1;
            }
            set { throw new ArgumentException("Cannot set faculty flag"); }
        }

        private List<Student> _listOfAllStudents; /* list of all students for validating
                                           * that person with same ID is not inputted in the system. */
        private List<bachelorStudent> _listOfBachelorStudents; // lista svih bachelor studenata
        private List<masterStudent> _listOfMasterStudents; // lista svih master studenata

        private List<Employee> _listOfAllEmployees;

        private List<employeeDEFINITEContract> _listOfDefiniteContractEmployees; // lista svih uposlenika na ugovoru na odredjeno
        private List<employeeINDEFINITEContract> _listOfIndefiniteContractEmployees; // lista svih uposlenika na ugovoru na neodredjeno

        private List<Course> _courses; // lista svih kurseva
        
        /* Stub object testing */
        private List<ICourse> _testCourses;

        public List<ICourse> TestCourses
        {
            get { return _testCourses; }
            set { _testCourses = value; }
        }

        /* Mock object testing */
        private List<ICourse_Associate> _testAssociateCourses;
    
        public List<ICourse_Associate> TestAssociateCourses
        {
            get { return _testAssociateCourses; }
            set { _testAssociateCourses = value; }
        }

        string _name; // naziv fakulteta;

        public Faculty(string name)
        {
            _listOfBachelorStudents = new List<bachelorStudent>();
            _listOfMasterStudents = new List<masterStudent>();
            _listOfAllStudents = new List<Student>();

            _listOfAllEmployees = new List<Employee>();
            _listOfDefiniteContractEmployees = new List<employeeDEFINITEContract>();
            _listOfIndefiniteContractEmployees = new List<employeeINDEFINITEContract>();

            _courses = new List<Course>();

            _testCourses = new List<ICourse>();

            _testAssociateCourses = new List<ICourse_Associate>();

            /* We are going to create an instance of stub object for testing
             * methods not implemented 
             */

            _name = name;

            bachelor_index_start = 17000;
            master_index_start = 100;
            employee_ID_start = 1;

            _income = 0;
            _expenditure = 0;
            _balance = 0;
            _flag = accountBalance.pozitive;
        }

        public string FindStudent(string ID)
        {
            foreach(Student x in ListOfAllStudent)
            {
                if (x.IDnumber == ID) { 
                    return x.IDnumber;
                }
            }
            return "";
        }

        public string FindEmployee(string ID)
        {
            foreach (Employee x in ListOfEmployees)
            {
                if (x.IDnumber == ID)
                {
                    return x.IDnumber;
                }
            }
            return "";
        }

        // new Course(int courseCode, string courseName, studyLevel level, int numberOfLectures, int numberOfExercies, int ECTS, List<Employee> teachingEnsamble)
        public void AddCourse(Course input)
        {
            _courses.Add(input);
        }

        /* We will not allow adding of object bachelorStudent or masterStudent
         * because container class Faculty handles the indexes 
         * for both types of students
         */
        public void AddBachelorStudent(string name, string surname, DateTime dateOfBirth, string IDnumber, DateTime endOfPreviousEducation) 
        {
            foreach(Student x in _listOfAllStudents)
            {
                if (x.IDnumber == IDnumber)
                    throw new ArgumentException("There is already person with the same ID number in the system");
            }
            
            // Oblik: "[0-9]{5}"
            string indexIDnumber = bachelor_index_start.ToString();
            bachelor_index_start++;

            bachelorStudent input = new bachelorStudent(name, surname, dateOfBirth, IDnumber, indexIDnumber, endOfPreviousEducation);
            _listOfBachelorStudents.Add(input);
            _listOfAllStudents.Add(input);
            _income += 9000;
            balanceRefresh();
            if (_balance < 0)
                _flag = accountBalance.negative;
            else
                _flag = accountBalance.pozitive;
        }

        public void AddMasterStudent(string name, string surname, DateTime dateOfBirth, string IDnumber, DateTime endOfPreviousEducation, string placeOfPreviousEd)
        {
            string indexIDnumber;
            masterStudent input;
            bool exists = false;

            foreach (Student x in _listOfAllStudents)
            {
                if (x.IDnumber == IDnumber && (x is masterStudent))
                    throw new ArgumentException("There is already person with the same ID number in the system");
            }

            foreach(bachelorStudent x in _listOfBachelorStudents)
            {
                if (x.IDnumber == IDnumber)
                {
                    // Oblik: "[0-9]{3}/[0-9]{5}"
                    indexIDnumber = master_index_start.ToString() + "/" + x.IndexIDNumber;
                    master_index_start++;

                    input = new masterStudent(name, surname, dateOfBirth, IDnumber, indexIDnumber, endOfPreviousEducation, placeOfPreviousEd);
                    _listOfMasterStudents.Add(input);
                    _listOfBachelorStudents.Remove(x);
                    _listOfAllStudents.Remove(x);
                    _listOfAllStudents.Add(input);
                    _income += 11000;
                    balanceRefresh();
                    if (_balance < 0)
                        _flag = accountBalance.negative;
                    else
                        _flag = accountBalance.pozitive;
                    exists = true;

                    break;
                }
            }

            if (exists == false)
            {
                // Oblik: "[0-9]{3}/[0-9]{5}"
                indexIDnumber = master_index_start.ToString() + "/" + bachelor_index_start;
                master_index_start++;
                bachelor_index_start++;

                input = new masterStudent(name, surname, dateOfBirth, IDnumber, indexIDnumber, endOfPreviousEducation, placeOfPreviousEd);
                _listOfMasterStudents.Add(input);
                _listOfAllStudents.Add(input);
                _income += 11000;
                balanceRefresh();
                if (_balance < 0)
                    _flag = accountBalance.negative;
                else
                    _flag = accountBalance.pozitive;
            }
        }

        /* Based on different parameters sent
         * in the function different type of
         * employee will be added to corresponding list.
         */ 
        public void AddDefiniteEmployee(string name, string surname, DateTime dateOfBirth, string IDnumber, employmentPosition_OnContract employeePosition, DateTime startOfContract, DateTime endOfContract, int numberOfClassesWeekly)
        {
            foreach (Employee x in _listOfAllEmployees)
            {
                if (x.IDnumber == IDnumber)
                    throw new ArgumentException("There is already person with the same ID number in the system");
            }

            int employeeID = employee_ID_start;
            employee_ID_start += 1;

            employeeDEFINITEContract input = new employeeDEFINITEContract(name, surname, dateOfBirth, IDnumber, employeeID, employeePosition, startOfContract, endOfContract, numberOfClassesWeekly);
            _listOfDefiniteContractEmployees.Add(input);
            _listOfAllEmployees.Add(input);
            _expenditure += input.Salary;
            balanceRefresh();
            if (_balance < 0)
                _flag = accountBalance.negative;
            else
                _flag = accountBalance.pozitive;
        }

        public void AddIndefiniteEmployee(string name, string surname, DateTime dateOfBirth, string IDnumber, employmentPosition_indefinitePeriod employeePosition, double norm, string jobQualification, string title)
        {
            foreach (Employee x in _listOfAllEmployees)
            {
                if (x.IDnumber == IDnumber)
                    throw new ArgumentException("There is already person with the same ID number in the system");
            }

            int employeeID = employee_ID_start;
            employee_ID_start += 1;

            employeeINDEFINITEContract input = new employeeINDEFINITEContract(name, surname, dateOfBirth, IDnumber, employeeID, employeePosition, norm, jobQualification, title);
            _listOfIndefiniteContractEmployees.Add(input);
            _listOfAllEmployees.Add(input);
            _expenditure += input.Salary;
            balanceRefresh();
            if (_balance < 0)
                _flag = accountBalance.negative;
            else
                _flag = accountBalance.pozitive;
        }

        public bool deleteStudentByID(string ID)
        {
            foreach(Student x in ListOfAllStudent)
            {
                if (x.IDnumber == ID)
                {
                    ListOfAllStudent.Remove(x);
                    if(x is bachelorStudent)
                    {
                        foreach(bachelorStudent y in ListOfBachelorStudents)
                        {
                            if (y.IDnumber == ID)
                            {
                                ListOfBachelorStudents.Remove(y);
                                break;
                            }
                        }
                    }
                    else if (x is masterStudent)
                    {
                        foreach (masterStudent y in ListOfMasterStudents)
                        {
                            if (y.IDnumber == ID)
                            {
                                ListOfMasterStudents.Remove(y);
                                break;
                            }
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public bool deleteStudentByIndex(string index)
        {
            foreach (Student x in ListOfAllStudent)
            {
                if (x.IndexIDNumber == index)
                {
                    ListOfAllStudent.Remove(x);
                    if (x is bachelorStudent)
                    {
                        foreach (bachelorStudent y in ListOfBachelorStudents)
                        {
                            if (y.IndexIDNumber == index)
                            {
                                ListOfBachelorStudents.Remove(y);
                                break;
                            }
                        }
                    }
                    else if (x is masterStudent)
                    {
                        foreach (masterStudent y in ListOfMasterStudents)
                        {
                            if (y.IndexIDNumber == index)
                            {
                                ListOfMasterStudents.Remove(y);
                                break;
                            }
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public bool deleteEmployeeByID(string ID)
        {
            foreach (Employee x in ListOfEmployees)
            {
                if (x.IDnumber == ID)
                {
                    ListOfEmployees.Remove(x);
                    if (x is employeeDEFINITEContract)
                    {
                        foreach (employeeDEFINITEContract y in ListOfDefiniteContractEmployees)
                        {
                            if (y.IDnumber == ID)
                            {
                                ListOfDefiniteContractEmployees.Remove(y);
                                break;
                            }
                        }
                    }
                    else if (x is employeeINDEFINITEContract)
                    {
                        foreach (employeeINDEFINITEContract y in ListOfIndefiniteContractEmployees)
                        {
                            if (y.IDnumber == ID)
                            {
                                ListOfIndefiniteContractEmployees.Remove(y);
                                break;
                            }
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public List<employeeDEFINITEContract> ListOfDefiniteContractEmployees
        {
            get { return _listOfDefiniteContractEmployees; }
            set { _listOfDefiniteContractEmployees = value;  }
        }

        public List<employeeINDEFINITEContract> ListOfIndefiniteContractEmployees
        {
            get { return _listOfIndefiniteContractEmployees; }
            set { _listOfIndefiniteContractEmployees = value; }
        }

        public List<bachelorStudent> ListOfBachelorStudents
        {
            get { return _listOfBachelorStudents; }
            set { throw new ArgumentException("List of bachelor students cannot be assigned"); }
        }

        public List<masterStudent> ListOfMasterStudents
        {
            get { return _listOfMasterStudents; }
            set { throw new ArgumentException("List of master students cannot be assigned"); }
        }

        public List<Student> ListOfAllStudent
        {
            get { return _listOfAllStudents; }
            set { throw new ArgumentException("List of students cannot be assigned"); }
        }

        public List<Course> ListOfCourses
        {
            get { return _courses; }
            set { throw new ArgumentException("List of courses cannot be assigned"); }
        }

        public List<Employee> ListOfEmployees
        {
            get { return _listOfAllEmployees; }
            set { throw new ArgumentException("List of employees cannot be assigned"); }
        }
    }
}
