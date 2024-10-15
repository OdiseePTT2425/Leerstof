using Absence.Tests.Testdoubles;

namespace Absence.Tests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetPresencePercentageForStudent_AllStudentsPresent_Returns1()
        {
            // Arrange
            AbsenceTrackerStub stub = new AbsenceTrackerStub();
            AbsenceHelper sut = new AbsenceHelper(stub);
            Student student1 = new Student("R1", "John", "Doe");

            // Act
            double result = sut.GetPresencePercentageForStudent(student1);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void GetPresencePercentageForStudent_Student2HalfOfTheTimePresent_Returns50Percent()
        {
            // Arrange
            AbsenceTrackerStub stub = new AbsenceTrackerStub();
            AbsenceHelper sut = new AbsenceHelper(stub);
            Student student = new Student("R2", "Jane", "Doe");

            // Act
            double result = sut.GetPresencePercentageForStudent(student);

            // Assert
            Assert.That(result, Is.EqualTo(0.5));
        }

        [Test]
        public void CreateAbsenceChecks_With1StudentPresentAnd1StudentAbsent_ReturnsCorrectAbsenceCheck()
        {
            // Arrange
            AbsenceTrackerFake fake = new AbsenceTrackerFake();
            // voor deze fake-testdouble overloop je de functionaliteit in de te testen functie
            // alle functies die werken op de absence-tracker moeten geimplementeerd zijn
            AbsenceHelper sut = new AbsenceHelper(fake);
            Student student1 = new Student("R1", "John", "Doe");
            Student student2 = new Student("R2", "Jane", "Doe");
            sut.AddNewStudent(student1);
            sut.AddNewStudent(student2);

            List<Student> present = new List<Student>() { student1};
            List<Student> excused = new List<Student>();

            // Act
            AbsenceCheck? result = sut.CreateAbsenceCheck(present, excused);

            // Assert
            Assert.That(result.PresentStudents, Is.EquivalentTo(new List<Student> { student1 }));
            Assert.That(result.ExcusedStudents, Is.Empty);
            Assert.That(result.AbsentStudents, Is.EquivalentTo(new List<Student> { student2 }));
        }

        [Test]
        public void AddNewStudent_WithExistingAbsenceCheck_CallsAddStudentAsAbsentToDay()
        {
            // Arrange
            AbsenceTrackerMock mock = new AbsenceTrackerMock(); 
            AbsenceHelper sut = new AbsenceHelper(mock);
            Student student = new Student("R1", "John", "Doe");

            // Act
            sut.AddNewStudent(student);

            // Assert
            // Hier moeten we niets zetten -> toch niet als we werken met een mock
            // De assert staat in de test-double klasse
            // Als er toch een neveneffect moet gecontroleerd worden, dan kan dit wel
        }

        [Test]
        public void AddNewStudent_WithExistingAbsenceCheck_CallsAddStudentAsAbsentToDay_WithSpy()
        {
            // Spy variant van de test hierboven
            // Vind ik persoonlijk leesbaarder want de asserts staan in de test
            // Arrange
            AbsenceTrackerSpy_AddNewStudent spy = new AbsenceTrackerSpy_AddNewStudent();
            AbsenceHelper sut = new AbsenceHelper(spy);
            Student student = new Student("R1", "John", "Doe");

            // Act
            sut.AddNewStudent(student);

            // Assert
            Assert.That(spy.IsAddStudentAsAbsentToDay, Is.True);
        }

        [Test]
        public void AddNewStudent_FromConsole_WithExistingAbsenceCheck_CallsAddStudentAsAbsentToDay_WithSpy()
        {
            // Spy variant van de test hierboven
            // Vind ik persoonlijk leesbaarder want de asserts staan in de test
            // Arrange
            ViewSpy viewSpy = new ViewSpy();
            AbsenceTrackerSpy_AddNewStudent spy = new AbsenceTrackerSpy_AddNewStudent();
            AbsenceHelper sut = new AbsenceHelper(spy, viewSpy);
            Student student = new Student("R1", "John", "Doe");

            // Act
            sut.AddNewStudent(student);

            // Assert
            Assert.That(viewSpy.IsAskForStudentCalled, Is.True);
            Assert.That(spy.IsAddStudentAsAbsentToDay, Is.True);
        }

        [Test]
        public void RemoveStudent_WithStudentInAbsenceChecks_CallsExpectedMethods()
        {
            // Arrange
            AbsenceTrackerSpy spy = new AbsenceTrackerSpy();
            AbsenceHelper sut = new AbsenceHelper(spy);
            Student student = new Student("R2", "Jane", "Doe");
            List<(Student, DateOnly)> expectedAbsent = new List<(Student, DateOnly)>()
            {
                (student, new DateOnly(2023,1,1))
            };
            List<(Student, DateOnly)> expectedExcused = new List<(Student, DateOnly)>()
            {
                (student, new DateOnly(2023,1,3))
            };
            List<(Student, DateOnly)> expectedPresent = new List<(Student, DateOnly)>()
            {
                (student, new DateOnly(2023,1,2)),
                (student, new DateOnly(2023,1,4))
            };

            // Act
            sut.RemoveStudent(student);

            // Assert
            Assert.That(spy.RemovedAbsentStudentWithDate, Is.EquivalentTo(expectedAbsent));
            Assert.That(spy.RemovedExcusedStudentWithDate, Is.EquivalentTo(expectedExcused));
            Assert.That(spy.RemovedPresentStudentWithDate, Is.EquivalentTo(expectedPresent));
        }

        // Dummy -> is eigenlijk heel simplistisch = hardcorded waarden
        [Test]
        public void CreateAbsenceCheck_WithNonExisting_ThrowsStudentNotFoundException()
        {
            // Arrange
            IAbsenceTracker dummy = null;
            AbsenceHelper sut = new AbsenceHelper(dummy);
            Student student1 = new Student("R1", "John", "Doe");
            Student student2 = new Student("R2", "Jane", "Doe");
            List<Student> present = new List<Student>() { student1 };
            List<Student> excused = new List<Student>();

            // Act

            // Assert
            var ex = Assert.Throws<StudentNotFoundException>(() => sut.CreateAbsenceCheck(present, excused));
            Assert.That(ex.NotFoundStudents, Is.EquivalentTo(present));
        }
    }
}