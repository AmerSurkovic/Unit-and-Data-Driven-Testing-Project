using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet.Interfaces
{
    public interface ICourse_Associate : ICourse // Vanredni predmet
    {
        double ECTS_ProjectValue();
        double ECTS_SeminarValue();
        double ECTS_HomeworkValue();
        double ECTS_ExamValue();
    }
}
