using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet.Interfaces
{
    public interface ICourse
    {
        string generalInformation();
        IList<Employee> teachingEnsamble();
        double ECTSinHours();

    }
}
