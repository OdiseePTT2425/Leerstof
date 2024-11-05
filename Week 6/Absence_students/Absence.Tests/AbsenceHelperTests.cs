using NSubstitute;
using NSubstitute.ReceivedExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Absence.Tests
{
    [TestFixture]
    internal class AbsenceHelperTests
    {
        // Vanaf deze week ga ik werken .Net Core projecten -> ik werk met .Net 8

        // Installeer het testing framework -> nsubsitute en nsubstitute.analyzers.csharp
        // Deze worden niet automatisch toegevoegd met het maken van een nunit test project

        Student _student1 = new Student("R1", "John", "Doe");
        Student _student2 = new Student("R2", "Janneke", "Doe");

        private AbsenceCheck GetAbsenceCheckWithEverybodyPresent()
        {
            return new AbsenceCheck()
            {
                PresentStudents = new List<Student>() { _student1, _student2 }
            };
        }

        private AbsenceCheck GetAbsenceCheckWithHalfOfStudentsPresent()
        {
            return new AbsenceCheck()
            {
                PresentStudents = new List<Student>() { _student1 },
                AbsentStudents = new List<Student>() { _student2 }
            };
        }

        private List<AbsenceCheck> GetAbsenceChecks()
        {
            return new List<AbsenceCheck>()
            {
                new AbsenceCheck(){
                    Day= new DateOnly(2023,1,1),
                    PresentStudents = new List<Student>(){ _student1},
                    AbsentStudents = new List<Student>() {_student2}
                },
                new AbsenceCheck(){
                    Day= new DateOnly(2023,1,2),
                    PresentStudents = new List<Student>(){ _student1, _student2}
                },
                new AbsenceCheck(){
                    Day= new DateOnly(2023,1,3),
                    PresentStudents = new List<Student>(){ _student1},
                    AbsentStudents = new List<Student>() {_student2}
                },
                new AbsenceCheck(){
                    Day= new DateOnly(2023,1,4),
                    PresentStudents = new List<Student>(){ _student1, _student2}
                },
            };
        }

        [Test]
        public void GetPresencePercentageForStudent_WithAlwaysPresent_Returns1()
        {
            //Arrange
            // Maak een testdouble aan (stubs/fakes)
            IAbsenceTracker testDouble = Substitute.For<IAbsenceTracker>(); // Dit maakt de testdouble aan
            testDouble.GetAbsenceChecks().Returns(GetAbsenceChecks());  // Wat moet deze test-double returnen voor een functieoproep
//            IAbsenceTracker stub = new AbsenceTrackerStub();  // niet meer nodig door twee voorgaande lijnen
            // Geef de testdouble door aan de absencehelper-klasse
            AbsenceHelper sut = new AbsenceHelper(testDouble);

            //Act
            double result = sut.GetPresencePercentageForStudent(_student1);

            //Assert
            Assert.That(result, Is.EqualTo(1.0));
        }

        [Test]
        public void CountPercentageOfPresentStudentsOnDay_WithDateInChecks_CalculatesCorrectPercentage()
        {
            // Arrange (stubs/fakes)
            IAbsenceTracker testDouble = Substitute.For<IAbsenceTracker>();  // Let op dat je hier de interface erin plaatst
            DateOnly date = new DateOnly(2023, 1, 1);
            DateOnly date2 = new DateOnly(2023, 1, 2);
            testDouble.GetAbsenceCheckOnDate(date).Returns(GetAbsenceCheckWithEverybodyPresent()); // Enkel voor die ene specifieke parameter wordt er een waarde gereturned
            testDouble.GetAbsenceCheckOnDate(date2).Returns(GetAbsenceCheckWithHalfOfStudentsPresent());

            //default-parameters -> als het argument van de functie ons niet interesseert
            testDouble.GetAbsenceCheckOnDate(default).Returns(GetAbsenceCheckWithEverybodyPresent());
            //alternatief voor default
            testDouble.GetAbsenceCheckOnDate(Arg.Any<DateOnly>()).Returns(GetAbsenceCheckWithEverybodyPresent());

            // wat als er bij opeenvolgende oproepen andere waarden moeten gereturned worden?
            testDouble.GetAbsenceCheckOnDate(default).Returns(
                GetAbsenceCheckWithEverybodyPresent(), // Bij de eerste oproep wordt dit gereturned
                GetAbsenceCheckWithHalfOfStudentsPresent() // Bij de tweede oproep van die functie wordt dit gereturned
            ); // de laatste wordt herhaald voor volgende oproepen (3,4,5, ...)

            AbsenceHelper sut = new AbsenceHelper(testDouble);

            // Act
            double result1 = sut.CountPercentageOfPresentStudentsOnDay(date);
            double result2 = sut.CountPercentageOfPresentStudentsOnDay(date2);

            // Assert
            Assert.That(result1, Is.EqualTo(1.0));
            Assert.That(result2, Is.EqualTo(0.5));
        }

        [Test]
        public void RemoveStudent_WithStudentInAbsenceChecks_ExpectedMethodsCalled()
        {
            // Arrange (spies/mocks)
            IAbsenceTracker testDouble = Substitute.For<IAbsenceTracker>();
            testDouble.GetAbsenceChecks().Returns(GetAbsenceChecks());
            AbsenceHelper sut = new AbsenceHelper(testDouble);

            // Act
            sut.RemoveStudent(_student1);

            // Assert
            testDouble.Received(1).RemovePresentStudentFromDay(_student1, new DateOnly(2023, 1, 1));
            //1 is de default bij received
            testDouble.Received().RemovePresentStudentFromDay(_student1, new DateOnly(2023, 1, 2));
            testDouble.Received().RemovePresentStudentFromDay(_student1, new DateOnly(2023, 1, 3));
            testDouble.Received().RemovePresentStudentFromDay(_student1, new DateOnly(2023, 1, 4));

            //alternatieven
            testDouble.Received(4).RemovePresentStudentFromDay(_student1, Arg.Any<DateOnly>());
            // is de funtie RemovePresentStudentFromDay 4 keer opgeroepen voor _student1 op willekeurige datums
            testDouble.ReceivedWithAnyArgs(4).RemovePresentStudentFromDay(default, default);

            testDouble.Received(Quantity.Within(1, 4)).RemovePresentStudentFromDay(default, default); // wordt het 1 tot 4 keer opgeroepen
        }

        [Test]
        public void CreateAbsenceCheck_With1StudentPresent1Absent_ReturnsCorrectCheck()
        {
            // Arrange
            IAbsenceTracker testDouble = Substitute.For<IAbsenceTracker>();
            AbsenceCheck check = new AbsenceCheck();

            Student student1 = new Student("R1", "test_voor", "test_achter");
            Student student2 = new Student("R2", "test_voor2", "test_achter2");

            testDouble.When(d => d.AddStudentAsPresentToToday(Arg.Any<Student>())).Do(info => check.PresentStudents.Add(info.ArgAt<Student>(0)));
            // wat bovenstaande lijn zegt: is als de functie AddStudentAsPresentToToday opgeroepen wordt met argument info -> steek de student in het argument van de functie in de check
            testDouble.When(d => d.AddStudentAsExcusedToToday(Arg.Any<Student>())).Do(info => check.ExcusedStudents.Add(info.ArgAt<Student>(0)));
            testDouble.When(d => d.AddStudentAsAbsentToToday(Arg.Any<Student>())).Do(info => check.AbsentStudents.Add(info.ArgAt<Student>(0)));

            testDouble.GetAbsenceChecks().Returns(new List<AbsenceCheck>());
            testDouble.GetAbsenceCheckOnDate(default).ReturnsForAnyArgs(_ => check); // lambda expressie omdat de check in de act nog aangepast wordt

            AbsenceHelper sut = new AbsenceHelper(testDouble); // let op dat je de testdouble zaken toevoegt voor het door te geven naar het sut
            sut.AddNewStudent(student1);
            sut.AddNewStudent(student2);


            // Act
            AbsenceCheck? result = sut.CreateAbsenceCheck(new List<Student> { student1 }, new List<Student> { }); // student2 zit hier niet in (absent)

            // Assert
            Assert.That(result.PresentStudents, Is.EquivalentTo(new List<Student> { student1 }));
            Assert.That(result.ExcusedStudents, Is.Empty);
            Assert.That(result.AbsentStudents, Is.EquivalentTo(new List<Student> { student2 }));
        }

        [Test]
        public void AddNewStudent_WithNewStudent_UpdatesExistingAbsenceChecks()
        {
            //Test double voor mock (gaan we zelden gebruiken, liever met spy werken)
            // Reden: bij mock staat de assert in de arrange -> dit is niet duidelijk

            // Arrange
            IAbsenceTracker tracker = Substitute.For<IAbsenceTracker>();
            tracker.GetAbsenceChecks().Returns(new List<AbsenceCheck> { new AbsenceCheck() });
            tracker.When(tracker => tracker.AddStudentAsAbsentToDay(Arg.Any<Student>(), Arg.Any<DateOnly>()))
                .Do(_ => Assert.Pass());
            AbsenceHelper sut = new AbsenceHelper(tracker);
            Student s0 = new Student("R0", "John", "Doe");

            // Act
            sut.AddNewStudent(s0);
        }

    }
}
