using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests
{
    [TestFixture]
    class PersonTests
    {
        private Person person;

        [Test]
        [TestCase(18)]
        [TestCase(42)]
        [TestCase(70)]
        public void Ctor_AgeBetween18And70_ObjectCreated(int age)
        {
            // Arrange

            // Act
            person = new Person("John", "Doe", age);

            // Assert
            Assert.That(person, Is.Not.Null);
        }

        [Test]
        [TestCase(17)]
        [TestCase(71)]
        [TestCase(-42)]
        public void Ctor_AgeNotBetween18And70_ExceptionThrown(int age)
        {
            // Arrange

            // Act

            // Assert
            Assert.That(() => person = new Person("Jane", "Doe", age), Throws.Exception);
        }

        // Probleem: eigenlijk hebben we twee keer de randvoorwaarden van de age-validator getest
        // Als de grenzen in age validator aangepast worden moeten de testen van alle klassen die het gebruiken ook aangepast worden

        // Oplossing: Dependency injection om de link tussen Person en Age validator te doorbreken
        // Om dependency injection toe te voegen -> maak een interface aan van de klasse met welke je communiceert
        // Maak het mogelijk om een object mee te geven van het type van de interface aan de contructor
        // Gebruik eventueel een tweede constructor om het standaard gedrag in te stellen zonder dit type van parameter (zie person klasse)
        // Nu kan je in het testproject testdoubles maken van dit type interface om het gedrag te controleren

        // Betere testen
        [Test]
        public void Ctor_AgeValid_ObjectCreated()
        {
            // Arrange
            AgeValidatorTestdouble testDouble = new AgeValidatorTestdouble(true);

            // Act
            person = new Person(testDouble, "John", "Doe", 0);

            // Assert
            Assert.That(person, Is.Not.Null);
        }

        [Test]
        public void Ctor_AgeInvalid_ExceptionThrown()
        {
            // Arrange
            AgeValidatorTestdouble testDouble = new AgeValidatorTestdouble(false);

            // Act

            // Assert
            Assert.That(() => person = new Person(testDouble, "Jane", "Doe", 42), Throws.Exception);
        }

    }
}
