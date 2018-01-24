using Fakultet.Enumerations;
using Fakultet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet.Stub_Objects
{
    public class stubCourse: ICourse
    {
        public string generalInformation()
        {
            return "infoAboutCourse";
        }
        public IList<Employee> teachingEnsamble()
        {
            IList<Employee> employees = new List<Employee>();   

            for(int i=0; i<10; i++)
            {
                employees.Add(new employeeDEFINITEContract("name", "surname", new DateTime(1970, 1, 1), "5555555555555", i, employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10));
            }

            return employees;
        }
        public double ECTSinHours()
        {
            return 100.5;
        }
    }
}
