using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    [TestFixture]
    internal class CalculatorTests
    {
        // Beginsituatie is: je hebt een project dat je wil testen (in dit geval is dat het calculator project)
        // Stap 1: Test project maken -> ofwel class library ofwel nunit test project (laatste is het eenvoudigst)
        // Stap 2: Installeer de nodige nuget packages NUnit en NunitTestAdapter
        // Stap 3: Rechtsklik project -> Add -> project reference -> leg een link naar het project dat je gaat testen (in dit geval calculator)

        // Stap 4: Maak een testklasse aan, let op naamgeving: project is Calculator -> typisch noemt het testproject Calculator.Tests
                    // Noemt de klasse Calculator -> noemt de testklasse CalculatorTests

        // Voeg aan een testklasse het attribuut [TestFixture] toe
        // Eerste unit test kan geschreven worden -> maak een functie aan en voeg het [Test] attribuut toe
                    // Let op naamgeving: {Methode}_{Precondities}_{Resultaat}
                    // 3 delen zijn in een unit test -> arrange - act - assert (given - when - then)

        // Uitvoeren unit tests -> Rechtsklikken testproject -> run tests
            // Geslaagde tests in het groen/falende testen in het rood

        [Test]
        public void Sum_10en5_resultaat15()
        {
            // Arrange
            Calculator sut = new Calculator();  // sut staat voor system under test

            // Act
            int result = sut.Sum(10, 5);  // best altijd maar 1 lijn code

            // Assert
            Assert.That(result, Is.EqualTo(15));
        }
    }
}
