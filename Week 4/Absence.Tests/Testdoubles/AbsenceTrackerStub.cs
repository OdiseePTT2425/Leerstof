using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Tests.Testdoubles
{
    internal class AbsenceTrackerStub : IAbsenceTracker
    {
        public void AddStudentAsAbsentToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsAbsentToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToToday(Student s)
        {
            throw new NotImplementedException();
        }

        public AbsenceCheck? GetAbsenceCheckOnDate(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public List<AbsenceCheck> GetAbsenceChecks()
        {
            // student 1 altijd aanwezig en student 2 altijd afwezig
            Student student1 = new Student("R1", "John", "Doe");
            Student student2 = new Student("R2", "Jane", "Doe");

            return new List<AbsenceCheck>(){
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{student1},
                    AbsentStudents = new List<Student>{student2}
                },
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{student1, student2}
                },
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{student1},
                    AbsentStudents = new List<Student>{student2}
                },
                new AbsenceCheck() {
                    PresentStudents = new List<Student>{student1,student2 }
                }
            };
        }

        public void RemoveAbsenceCheck(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemoveAbsentStudentFromDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemoveExcusedStudentFromDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void RemovePresentStudentFromDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }
    }
}
