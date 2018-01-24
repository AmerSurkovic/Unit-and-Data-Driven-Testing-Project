using Fakultet.Interfaces;
using Fakultet.Mock_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultet
{
    public class Course // Predmet
    {

        private int _courseCode; // sifra predmeta
        private string _courseName; // naziv predmeta
        private studyLevel _level; // studij kojem pripada (bachelor ili master)
        private int _numberOfLectures; // broj predavanja
        private int _numberOfExercises; // broj vjezbi
        private int _ECTS; // broj ECTS kredita
        private List<Employee> _teachingEnsamble; // nastavni ansambl

        private string _description;
        public string Description { get { return _description; } set { _description = value; } }

        public int CourseCode { get { return _courseCode; } set { _courseCode = value; } }
        public string CourseName { get { return _courseName; } set { _courseName = value; } }
        public studyLevel Level { get { return _level; } set { _level = value; } }
        public int NumberOfLectures { get { return _numberOfLectures; } set { _numberOfLectures = value; } }
        public int NumberOfExercises { get { return _numberOfExercises; } set { _numberOfExercises = value; } }
        public int ECTS { get { return _ECTS; } set { _ECTS = value; } }

        public Course(int courseCode, string courseName, studyLevel level, int numberOfLectures, int numberOfExercies, int ECTS, List<Employee> teachingEnsamble)
        {
            _courseCode = courseCode;
            _courseName = courseName;
            _level = level;
            _numberOfLectures = numberOfLectures;
            _numberOfExercises = numberOfExercies;
            _ECTS = ECTS;
            _teachingEnsamble = teachingEnsamble;
        }

        string _generalInformation;
        public string generalInformation { get { return _generalInformation; } set { _generalInformation = value; } }
  /*      public string generalInformation() // generalne informacije
        {
            /*   string info = "Kod kursa: " + _courseCode + "\n"
                           + "Ime kursa: " + _courseName + "\n"
                           + "Nivo studija: " + _level.ToString() + "\n"
                           + "Broj predavanja: " + _numberOfLectures + "\n"
                           + "Broj vjezbi " + _numberOfExercises + "\n"
                           + "Broj ECTS kredita: " + _ECTS + "\n"
                           + "Nastavni ansambl: ";
               for(int i=0; i<_teachingEnsamble.Count; i++)
               {
                   info = _teachingEnsamble[i].Name + " " + _teachingEnsamble[i].Surname + "\n";
               }

               return info;
            return "";
        }*/
    

        public List<Employee> TeachingEnsamble
        {
            get { return _teachingEnsamble; }
            set { _teachingEnsamble = value; }
        }

        public double ECTSinHours() // broj sati koje je potrebno uloziti za polaganje predmeta
        {
            return _ECTS * 25;
        }
    }
}
