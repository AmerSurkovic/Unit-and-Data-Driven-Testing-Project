using Fakultet.Enumerations;
using Fakultet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet.Mock_Objects
{
    /* Mock objekat za vanredni predmet.
     * Bitno je da implementira specificne navedene metode
     * a kada bi pravili pravi vanredni predmet a ne mock objekat
     * naslijedili bi iz klase Course te naznacili da implementira interfejs ICourse_Associate
     * medjutim to ovdje nije poenta.
     * Pa cemo samo implementirati trazene metode sa instanciranim parametrima potrebnim za te metode.
     */
    public class AssociateCourse_Mock : ICourse_Associate   
    {
        private Course baseCourse; 

        public AssociateCourse_Mock(int courseCode, string courseName, studyLevel level, int numberOfLectures, int numberOfExercies, int ECTS, List<Employee> teachingEnsamble)
        {
            baseCourse = new Course(courseCode, courseName, level, numberOfLectures, numberOfExercies, ECTS, teachingEnsamble);
        }

        public double ECTSinHours()
        {
            return baseCourse.ECTS * 5;
        }

        public double ECTS_ExamValue()
        {
            return baseCourse.ECTS * 0.4;
        }

        public double ECTS_HomeworkValue()
        {
            return baseCourse.ECTS * 0.1;
        }

        public double ECTS_ProjectValue()
        {
            return baseCourse.ECTS * 0.1;
        }

        public double ECTS_SeminarValue()
        {
            return baseCourse.ECTS * 0.1;
        }

        public string generalInformation()
        {
            return "Kod kursa: " + baseCourse.CourseCode + " Naziv kursa: " + baseCourse.CourseName;
        }

        public IList<Employee> teachingEnsamble()
        { 
            for (int i = 0; i < 10; i++)
            {
                baseCourse.TeachingEnsamble.Add(new employeeDEFINITEContract("name", "surname", new DateTime(1970, 1, 1), "5555555555555", i, employmentPosition_OnContract.demonstrator, new DateTime(2017, 1, 1), new DateTime(2019, 1, 1), 10));
            }

            return baseCourse.TeachingEnsamble;
        }

    }
}
