using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Tests.Testdoubles
{
    internal class AbsenceTrackerMock : IAbsenceTracker
    {
        public void AddStudentAsAbsentToDay(Student s, DateOnly date)
        {
            Assert.Pass(); // we willen enkel controleren dat die functie opgeroepen is
        }

        public void AddStudentAsAbsentToToday(Student s)
        {
            Assert.Fail(); // Als we niet willen dat deze opgeroepen wordt
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
            Assert.Fail(); // Als we niet willen dat deze opgeroepen wordt
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
            return new List<AbsenceCheck>() { new AbsenceCheck()};
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
