namespace PersonAgeValidator.Tests
{
    [TestFixture]
    public class Tests
    {
        private AgeValidator validator;

        [SetUp]
        public void Setup()
        {
            validator = new AgeValidator();
        }

        [Test]
        [TestCase(18)]
        [TestCase(42)]
        [TestCase(70)]
        public void IsValidAge_AgeBetween18And70_ReturnsTrue(int age)
        {
            // Arrange

            // Act
            bool result = validator.IsValidAge(age);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        [TestCase(17)]
        [TestCase(71)]
        [TestCase(-42)]
        public void IsValidAge_AgeNotBetween18And70_ReturnsFalse(int age)
        {
            // Arrange

            // Act
            bool result = validator.IsValidAge(age);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}