namespace Absence
{
    // Dit kan je wat zien als de CRUD-operaties van een repository
    public interface IAbsenceTracker
    {
        // voeg student toe als present op een bepaalde dag
        void AddStudentAsPresentToDay(Student s, DateOnly date);
        // voeg student toe als present op vandaag
        void AddStudentAsPresentToToday(Student s);
        void AddStudentAsAbsentToDay(Student s, DateOnly date);
        void AddStudentAsAbsentToToday(Student s);
        void AddStudentAsExcusedToDay(Student s, DateOnly date);
        void AddStudentAsExcusedToToday(Student s);
        void RemovePresentStudentFromDay(Student s, DateOnly date);
        void RemoveAbsentStudentFromDay(Student s, DateOnly date);
        void RemoveExcusedStudentFromDay(Student s, DateOnly date);
        List<AbsenceCheck> GetAbsenceChecks();
        void RemoveAbsenceCheck(DateOnly date);
        AbsenceCheck? GetAbsenceCheckOnDate(DateOnly date);
    }
}
