using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Tests.Testdoubles
{
    internal class AbsenceTrackerFake : IAbsenceTracker
    {
        private AbsenceCheck _check = new AbsenceCheck();
        public void AddStudentAsAbsentToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsAbsentToToday(Student s)
        {
            _check.AbsentStudents.Add(s);
        }

        public void AddStudentAsExcusedToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsExcusedToToday(Student s)
        {
            _check.ExcusedStudents.Add(s);
        }

        public void AddStudentAsPresentToDay(Student s, DateOnly date)
        {
            throw new NotImplementedException();
        }

        public void AddStudentAsPresentToToday(Student s)
        {
            _check.PresentStudents.Add(s);
        }

        public AbsenceCheck? GetAbsenceCheckOnDate(DateOnly date)
        {
            return _check;
        }

        public List<AbsenceCheck> GetAbsenceChecks()
        {
            return new List<AbsenceCheck>();
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
