using AutoFixture;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Person.Tests
{
    [TestFixture]
    internal class PersonRepositoryTests
    {
        private DbContextOptions<PersonDbContext> _options;
        private Fixture _fixture = new Fixture();

        public PersonRepositoryTests() {
            // link de _options naar de in-memory sql databank
            //DbConnection conn = new SqliteConnection("filename=:memory:"); 
            // installeer hiervoor de entityframeworkcore.sqllite.core nuget package
            // De connectionstring zegt: werk in het ram-geheugen zonder permanent zaken op te slaan
            //conn.Open();

            //_options = new DbContextOptionsBuilder<PersonDbContext>().UseSqlite(conn).Options;

            // Dit is om ervoor te zorgen dat de database bestaat voor we beginnen te testen
            PersonDbContext context = CreateDbContext();
            context.Database.EnsureCreated();
        }

        private PersonDbContext CreateDbContext()
        {
            return new PersonDbContext();
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
    }
}
