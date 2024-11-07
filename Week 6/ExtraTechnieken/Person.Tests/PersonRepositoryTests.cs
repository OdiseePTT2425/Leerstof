using AutoFixture;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Person.Tests
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        private DbContextOptions<PersonDbContext> _options;
        private Fixture _fixture = new Fixture();

        public PersonRepositoryTests() {
            // link de _options naar de in-memory sql databank
            DbConnection conn = new SqliteConnection("Filename=:memory:"); 
            // installeer hiervoor de entityframeworkcore.sqllite nuget package (dus niet sqlite.core)
            // De connectionstring zegt: werk in het ram-geheugen zonder permanent zaken op te slaan
            conn.Open();

            _options = new DbContextOptionsBuilder<PersonDbContext>().UseSqlite(conn).Options;

            // Dit is om ervoor te zorgen dat de database bestaat voor we beginnen te testen
            PersonDbContext context = CreateDbContext();
            context.Database.EnsureCreated();
        }

        private PersonDbContext CreateDbContext()
        {
            return new PersonDbContext(_options); 
        }

        private void SeedDatabaseWithData(PersonDbContext context, List<Person> persons)
        {
            context.Persons.AddRange(persons); // Voeg alle personen toe
            context.SaveChanges();
        }

        [Test]
        public void GetAllPersons_WithItemsInDb_ReturnsListOfPersons()
        {
            // Arrange
            // Maak een dbcontext aanmaken die werkt met een sql-lite databank (in het geheugen)
            PersonDbContext db = CreateDbContext();
            // plaats een aantal objecten in de databank
            Person p1 = new Person("test1", "test1", DateTime.Today);
            Person p2 = new Person("test2", "test2", DateTime.Today);
            Person p3 = new Person("test3", "test3", DateTime.Today);
            db.Persons.Add(p1);
            db.Persons.Add(p2);
            db.Persons.Add(p3);
            db.SaveChanges();
            // geef de dbcontext aan de repository
            PersonRepository sut = new PersonRepository(db);

            // Act
            List<Person> results = sut.GetAllPersons();

            // Assert
            Assert.That(results, Is.EquivalentTo(new List<Person> {p1, p2, p3 }));
        }

        [Test]
        public void GetAllPersons_WithItemsInDb_ReturnsListOfPersons_AutoFixture()
        {
            // Arrange
            // Maak een dbcontext aanmaken die werkt met een sql-lite databank (in het geheugen)
            PersonDbContext db = CreateDbContext();
            // plaats een aantal objecten in de databank
            List<Person> persons = _fixture.Build<Person>().CreateMany(5).ToList();
            SeedDatabaseWithData(db, persons);
            // geef de dbcontext aan de repository
            PersonRepository sut = new PersonRepository(db);

            // Act
            List<Person> results = sut.GetAllPersons();

            // Assert
            Assert.That(results, Is.EquivalentTo(persons));
        }

        [Test]
        public void GetAllPersons_WithItemsInDB_ReturnsListOfPersons()
        {
            // Arrange
            PersonDbContext dbContext = CreateDbContext(); //  test double

            List<Person> persons = _fixture.Build<Person>()
                .With(person => person.Id, 0)
                .With(person => person.BirthDate, new DateTime(1990, 2, 2))
                .CreateMany().ToList();


            SeedDatabaseWithData(dbContext, persons);
            PersonRepository sut = new PersonRepository(dbContext);

            // Act
            List<Person> actualPersons = sut.GetAllPersons();

            // Assert
            Assert.That(actualPersons, Is.EquivalentTo(persons));
        }

        [Test]
        public void GetAllPersonsWithBirthyearBelow_WithBirthYear2010_ReturnsItemsWithBirthYearBelow2010()
        {
            // Arrange
            PersonDbContext dbContext = CreateDbContext(); //  test double

            List<Person> personsWithBirtDateBefore2010 = _fixture.Build<Person>()
           .With(person => person.Id, 0)
           .With(person => person.BirthDate, new DateTime(1990, 2, 2))
           .CreateMany().ToList();

            List<Person> personsWithBirtDateAfter2010 = _fixture.Build<Person>()
           .With(person => person.Id, 0)
           .With(person => person.BirthDate, new DateTime(2020, 2, 2))
           .CreateMany().ToList();


            SeedDatabaseWithData(dbContext, personsWithBirtDateAfter2010);
            SeedDatabaseWithData(dbContext, personsWithBirtDateBefore2010);
            PersonRepository sut = new PersonRepository(dbContext);

            // Act
            List<Person> persons = sut.GetAllPersonsWithBirthyearBelow(2010);

            // Assert
            Assert.That(persons, Is.EquivalentTo(personsWithBirtDateBefore2010));
        }

        [Test]
        public void AddPerson_WithRandomPerson_AddPersonToDb()
        {

            // Arrange
            PersonDbContext context = CreateDbContext();
            PersonRepository sut = new PersonRepository(context);
            DateTime CurrentDate = DateTime.Today;

            // Act
            sut.AddPerson(new Person("Demo", "Demo", CurrentDate));

            // Assert
            Assert.That(context.Persons, Is.EquivalentTo(new List<Person> { new Person("Demo", "Demo", CurrentDate) { Id = 1 } }));
        }


    }
}
