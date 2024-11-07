using AutoFixture;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenApp.Tests
{
    [TestFixture]
    internal class AppLogicTests
    {
        private Fixture fixture = new Fixture();

        [Test]
        public void AddAirport_NameEmpty_AirportNotAdded()
        {
            // Arrange
            ILuchthavenRepository luchthavenRepository = Substitute.For<ILuchthavenRepository>();
            AppLogic sut = new AppLogic(luchthavenRepository);

            Luchthaven luchthaven = fixture.Build<Luchthaven>().With(lh => lh.Name, "").Create<Luchthaven>();

            // Act
            bool result = sut.AddAirport(luchthaven);

            // Assert
            Assert.That(result, Is.False);
            luchthavenRepository.DidNotReceive().AddLuchthaven(luchthaven);
        }

        [Test]
        public void AddAirport_AllDataCorrect_AirportAdded()
        {
            // Arrange
            ILuchthavenRepository luchthavenRepository = Substitute.For<ILuchthavenRepository>();
            AppLogic sut = new AppLogic(luchthavenRepository);

            Luchthaven luchthaven = fixture.Create<Luchthaven>();

            // Act
            bool result = sut.AddAirport(luchthaven);

            // Assert
            Assert.That(result, Is.True);
            luchthavenRepository.Received().AddLuchthaven(luchthaven);
        }

        // extra testen voor de andere velden

        [Test]
        public void AddAirport_CodeAlreadyExists_AirportNotAdded()
        {
            // Arrange
            List<Luchthaven> luchthavens = fixture.Build<Luchthaven>().With(lh => lh.Code, "BRU").CreateMany<Luchthaven>(2).ToList();
            ILuchthavenRepository luchthavenRepository = Substitute.For<ILuchthavenRepository>();
            luchthavenRepository.GetAllLuchthavens().Returns(new List<Luchthaven>() { luchthavens[0] });
            AppLogic sut = new AppLogic(luchthavenRepository);

            // Act
            bool result = sut.AddAirport(luchthavens[1]);

            // Assert
            Assert.That(result, Is.False);
            luchthavenRepository.DidNotReceive().AddLuchthaven(luchthavens[1]);
        }
    }
}
