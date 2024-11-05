using HigherLowerGameCore;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigherLowerGame.Tests
{
    [TestFixture]
    public class HigherLowerAppTests
    {
        [Test]
        public void GuessGuessNumber_WithGuessToHigh_ReturnsLower()
        {
            // Arrange
            IRandomWrapper testDouble = Substitute.For<IRandomWrapper>();
            testDouble.Next(default).ReturnsForAnyArgs(5);
            HigherLowerApp sut = new HigherLowerApp(10, testDouble);

            // Act
            Result result = sut.GuessNumber(7);

            // Assert
            Assert.That(result, Is.EqualTo(Result.Lower));
           
        }

        [Test]
        public void GuessGuessNumber_WithGuessToLow_ReturnsHigher()
        {

            // Arrange
            IRandomWrapper testDouble = Substitute.For<IRandomWrapper>();
            testDouble.Next(default).ReturnsForAnyArgs(5);
            HigherLowerApp sut = new HigherLowerApp(10, testDouble);

            // Act
            Result result = sut.GuessNumber(3);

            // Assert
            Assert.That(result, Is.EqualTo(Result.Higher));
        }
    }
}
