using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuchthavenApp.Tests
{
    [TestFixture]
    internal class LuchthavenTests
    {
        [Test]
        public void Ctor_WithValues_ObjectCreated()
        {
            // Arrange

            // Act
            Luchthaven sut = new Luchthaven(0, "Brussels airport", "Belgie", "Brussel", "BRU");

            // Assert
            Assert.That(sut, Is.Not.Null);
            Assert.That(sut.Id, Is.EqualTo(0));
            Assert.That(sut.Name, Is.EqualTo("Brussels airport"));
            Assert.That(sut.Country, Is.EqualTo("Belgie"));
            Assert.That(sut.City, Is.EqualTo("Brussel"));
            Assert.That(sut.Code, Is.EqualTo("BRU"));
        }
    }
}
