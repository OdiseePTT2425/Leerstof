using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Tests.Testdoubles
{
    internal class AbsenceTrackerSpy_AddNewStudent : IAbsenceTracker
    {
        public bool IsAddStudentAsAbsentToDay { get; set; }
        public AbsenceTrackerSpy_AddNewStudent() {
            IsAddStudentAsAbsentToDay = false;
        }

        public void AddStudentAsAbsentToDay(Student s, DateOnly date)
        {
            IsAddStudentAsAbsentToDay = true;
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
            return new List<AbsenceCheck>() { new AbsenceCheck() };
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
