using AutoFixture;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenApp.Tests
{
    [TestFixture]
    internal class LuchthavenRepositoryTests
    {
        private DbContextOptions<LuchthavenDbContext> _options;
        private Fixture _fixture = new Fixture();

        // Het werken met de sqlite database is ENKEL nodig bij repository testen
        public LuchthavenRepositoryTests()
        {
            // in-memory db maken
            DbConnection connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            // options ophalen voor de connection
            _options = new DbContextOptionsBuilder<LuchthavenDbContext>().UseSqlite(connection).Options;

            LuchthavenDbContext dbContext = CreateDbContext();
            dbContext.Database.EnsureCreated();
        }

        private LuchthavenDbContext CreateDbContext()
        {
            return new LuchthavenDbContext(_options);
        }

        private void SeedDatabase(LuchthavenDbContext context, List<Luchthaven> luchthavens)
        {
            context.Luchthavens.AddRange(luchthavens);
            context.SaveChanges();
        }

        // na deze code staat onze repository klasse klaar om te gebruiken

        [Test]
        public void GetAllLuchthavens_WithDataInDb_ReturnsAll()
        {
            // Arrange
            LuchthavenDbContext context = CreateDbContext();
            List<Luchthaven> luchthavens = _fixture.Build<Luchthaven>().With(lh => lh.Code, "BRU").CreateMany<Luchthaven>(10).ToList();

            SeedDatabase(context, luchthavens);
            LuchthavenRepository sut = new LuchthavenRepository(context);

            // Act
            List<Luchthaven> result = sut.GetAllLuchthavens();

            // Assert
            Assert.That(result, Is.EquivalentTo(luchthavens));
        }

        // Test voor update

        // Test voor Add

        // Test voor delete
    }
}
