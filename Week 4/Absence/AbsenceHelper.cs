
using System.Data;
using System.Numerics;

namespace Absence
{
    public class AbsenceHelper
    {
        List<Student> _students = new List<Student>();

        // Dit zou je gedaan hebben voor testdoubles
        /* IAbsenceTracker _absenceTracker = new AbsenceTracker();
         public AbsenceHelper() { 
         }*/

        // Om de dependency naar absencetracker te doorbreken
        // hebben we niet het voorgaande nodig maar de twee constructors die hieronder staan
        private IAbsenceTracker _absenceTracker;
        private IView _view;
        public AbsenceHelper(): this(new AbsenceTracker(), new View())
        {
            // Deze ctor is het voor het standaard gedrag
            // In de normale werking gebruik je de normale tracker
        }
        public AbsenceHelper(IAbsenceTracker absenceTracker) : this(absenceTracker, new View())
        {
        }

        public AbsenceHelper(IAbsenceTracker absenceTracker, IView view)
        {
            _absenceTracker = absenceTracker;
            _view = view;
            // Dit is voor te testen en maakt het mogelijk om de dependency te doorbreken
        }

        public void AddNewStudent()
        {
            /*
            // Wat als we met input van een user zitten
            Console.WriteLine("Geef een studentid in");
            string? id = Console.ReadLine();
            Console.WriteLine("Geef een voornaam in");
            string? voornaam = Console.ReadLine();
            Console.WriteLine("Geef een achternaam in");
            string? achternaam = Console.ReadLine();

            Student student = new Student(id, voornaam, achternaam);
            */
            // Bovenstaande code bevat een dependency op de console klasse
            // Haal deze uit de te testen klasse en plaats deze in een view klasse
            // Gebruik een interface om deze toe te voegen hieraan zodat het gedrag gecontroleerd kan worden

            Student s = _view.AskForStudent();
            this.AddNewStudent(s);
        }

        /// <summary>
        /// Voegt een nieuwe student toe. De student wordt als afwezig ingesteld voor alle vorige aanwezigheden.
        /// </summary>
        /// <param name="student"></param>
        public void AddNewStudent(Student student)
        {
            _students.Add(student);

            List<AbsenceCheck> checks = _absenceTracker.GetAbsenceChecks();

            foreach (AbsenceCheck check in checks)
            {
                _absenceTracker.AddStudentAsAbsentToDay(student, check.Day);
            }
        }

        /// <summary>
        /// Verwijdert een student uit de lijst. De student wordt verwijderd uit alle vorige aanwezigheden.
        /// </summary>
        /// <param name="student"></param>
        public void RemoveStudent(Student student)
        {
            _students.Remove(student);

            List<AbsenceCheck> checks = _absenceTracker.GetAbsenceChecks();

            foreach (AbsenceCheck check in checks)
            {
                switch (GetStateForStudent(check, student))
                {
                    case PresenceState.Present:
                        _absenceTracker.RemovePresentStudentFromDay(student, check.Day);
                        break;
                    case PresenceState.Absent:
                        _absenceTracker.RemoveAbsentStudentFromDay(student, check.Day);
                        break;
                    case PresenceState.Excused:
                        _absenceTracker.RemoveExcusedStudentFromDay(student, check.Day);
                        break;
                    case null:
                        break;
                }
            }
        }

        /// <summary>
        /// Creëert een aanwezigheid voor de aangegeven studenten, studenten die niet in een van deze lijsten zitten worden als afwezig aangeduid.
        /// </summary>
        /// <param name="presentStudents">Aanwezige studenten</param>
        /// <param name="excusedStudent">Verontschuldigde studenten</param>
        /// <exception cref="StudentNotFoundException">Wanneer een student niet in de bestaande lijst aanwezig is.</exception>
        /// <exception cref="ArgumentException">Wanneer een student zowel in presentStudent zit als in excusedstudent.</exception>
        /// <returns>Newly created AbsenseCheck</returns>
        public AbsenceCheck? CreateAbsenceCheck(List<Student> presentStudents, List<Student> excusedStudent)
        {
            CheckStudents(presentStudents, excusedStudent);

            foreach (Student student in presentStudents)
            {
                _absenceTracker.AddStudentAsPresentToToday(student);
            }

            foreach(Student student in excusedStudent)
            {
                _absenceTracker.AddStudentAsExcusedToToday(student);
            }

            IEnumerable<Student> absentStudents = _students.Where(student => !presentStudents.Contains(student) && !excusedStudent.Contains(student));
          
            foreach(Student student in absentStudents)
            {
                _absenceTracker.AddStudentAsAbsentToToday(student);
            }
            
            return _absenceTracker.GetAbsenceCheckOnDate(DateOnly.FromDateTime(DateTime.Now));
        }

        /// <summary>
        /// Deze methode berekent het percentage aanwezigheid van een student.
        /// </summary>
        /// <param name="student"></param>
        /// <returns>percentage aanwezigheid van student</returns>
        public double GetPresencePercentageForStudent(Student student)
        {
            IEnumerable<PresenceState?> states = _absenceTracker.GetAbsenceChecks()
                .Select(check => GetStateForStudent(check, student));

            double average = states.Average(state => state == PresenceState.Present ? 1 : 0);
            return average;

        }

        /// <summary>
        /// Deze methode berekent het percentage aanwezigen op 1 dag ten opzichte van alle studenten.
        /// </summary>
        /// <param name="date"></param>
        /// <returns>percentage aanwezigen</returns>
        public double CountPercentageOfPresentStudentsOnDay(DateOnly date)
        {
            AbsenceCheck? check = _absenceTracker.GetAbsenceCheckOnDate(date);

            if (check == null)
            {
                return 0.0;
            }
            
            double numberOfPresentStudents = check.PresentStudents.Count;
            double numberOfAbsentStudents = check.AbsentStudents.Count;
            double numberOfExcusedStudents = check.ExcusedStudents.Count;

            return numberOfPresentStudents / (numberOfPresentStudents + numberOfAbsentStudents + numberOfExcusedStudents);
        }


        private void CheckStudents(List<Student> presentStudents, List<Student> excusedStudents)
        {
            IEnumerable<Student> notFoundPresentStudents = GetNotFoundStudents(presentStudents);
            IEnumerable<Student> notFoundExcusedStudents = GetNotFoundStudents(excusedStudents);

            IEnumerable<Student> notFoundStudents = notFoundExcusedStudents.Concat(notFoundPresentStudents);

            if(notFoundStudents.Any())
            {
                throw new StudentNotFoundException(notFoundStudents);
            }

            if(excusedStudents.Any( student  => presentStudents.Contains(student))) {
                throw new ArgumentException("Student duplicated in both lists");
            }
        }

        private IEnumerable<Student> GetNotFoundStudents(List<Student> students)
        {
            return students.Where(student => !_students.Contains(student));
        }

        private PresenceState? GetStateForStudent(AbsenceCheck check, Student s)
        {
            if (check.AbsentStudents.Contains(s))
            {
                return PresenceState.Absent;
            }
            else if (check.PresentStudents.Contains(s))
            {
                return PresenceState.Present;
            }
            else if (check.ExcusedStudents.Contains(s))
            {
                return PresenceState.Excused;
            }

            return null;
        }
    }
}
