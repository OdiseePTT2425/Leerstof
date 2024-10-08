namespace FrisdrankAutomaat.Tests
{
    public class Tests
    {
        VendingMachine sut;
        Drink cola = new Drink("cola", 2.0);
        Drink fanta = new Drink("fanta", 1.0);

        [SetUp]
        public void Setup()
        {
            sut = new VendingMachine();
            sut.AddDrink(cola, 0, 1);

            sut.AddDrink(fanta, 0, 2);
            sut.AddDrink(cola, 0, 2);
        }

        [Test]
        public void AddDrinks_EmptyInventory_DrinkAdded()
        {
            // Arrange

            // Act
            sut.AddDrink(cola, 0, 0);

            // Assert
            Assert.That(sut.Inventory[(0, 0)], Is.EqualTo(cola));
        }

        [Test]
        public void AddDrinks_NotEmptyField_DrinkNotAddedInFront()
        {
            // Arrange

            // Act
            sut.AddDrink(cola, 0, 2);

            // Assert
            Assert.That(sut.Inventory[(0, 2)], Is.EqualTo(fanta));
        }

        [Test]
        [TestCase(Coins.TWO_EURO, 2.0)]
        [TestCase(Coins.ONE_EURO, 1.0)]
        [TestCase(Coins.FIFTY_CENTS, 0.5)]
        [TestCase(Coins.TWENTY_CENTS, 0.2)]
        [TestCase(Coins.TEN_CENTS, 0.1)]
        [TestCase(Coins.FIVE_CENTS, 0.05)]
        public void InsertCoins_BudgetZero_ValueEachCoinCorrect(Coins coin, double value)
        {
            // Arrange

            // Act
            sut.InsertCoins(coin);

            // Assert
            Assert.That(sut.Budget, Is.EqualTo(value));
        }

        [Test]
        [TestCase(Coins.TWO_EURO, 4.0)]
        [TestCase(Coins.ONE_EURO, 3.0)]
        [TestCase(Coins.FIFTY_CENTS, 2.5)]
        [TestCase(Coins.TWENTY_CENTS, 2.2)]
        [TestCase(Coins.TEN_CENTS, 2.1)]
        [TestCase(Coins.FIVE_CENTS, 2.05)]
        public void InsertCoins_BudgetIsTwoEuro_ValueEachCoinCorrectlyAdded(Coins coin, double value)
        {
            // Arrange
            sut.InsertCoins(Coins.TWO_EURO);

            // Act
            sut.InsertCoins(coin);

            // Assert
            Assert.That(sut.Budget, Is.EqualTo(value));
        }

        [Test]
        public void Refund_TwoEuroBudget_ReturnedAndBudgetCleared()
        {
            // Arrange
            sut.InsertCoins(Coins.TWO_EURO);

            // Act
            double result = sut.Refund();

            // Assert
            Assert.That(sut.Budget, Is.EqualTo(0));
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [TestCase(11, 4)]
        [TestCase(9, 6)]
        [TestCase(11, 6)]
        public void Buy_RowOrColumnOutOfRange_ExceptionThrown(int row, int col)
        {
            // Arrange

            // Act
            
            // Assert
            Assert.That(() => sut.Buy(row, col), Throws.TypeOf<IndexOutOfRangeException>());
        }

        // check andere exceptions

        [Test]
        public void Buy_DrinkAtPositionWithBudget_DrinkRemovedBudgetLowered()
        {
            // Arrange
            sut.InsertCoins(Coins.TWO_EURO);

            // Act
            Drink result = sut.Buy(0, 2);

            // Assert
            Assert.That(result, Is.EqualTo(fanta));
            Assert.That(sut.Budget, Is.EqualTo(1.0));
            Assert.That(sut.Inventory[(0, 2)], Is.EqualTo(cola));
        }
    }
}