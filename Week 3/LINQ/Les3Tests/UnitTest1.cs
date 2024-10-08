using Les3;

namespace Les3Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        // Let op: in deze file hou ik geen rekening met naamgeving
        // Jullie moeten dus de naamgeving uit deze file niet gebruiken

        [Test]
        public void Test1()
        {
            //Arrange
            List<int> list = new List<int>() { 1,2,3};
            List<int> expectedList = new List<int>() { 3, 2, 1 };

            //Act
            list.Reverse();

            //Assert
            Assert.That(list, Is.EqualTo(expectedList)); // Dit hebben we tot nu toe gedaan
            // Dit gaat werken als we de elementen in de lijst kunnen vergelijken
            // Waar gaat dit niet werken? Wat als we een lijst met studenten hebben?
            // Hoe oplossen?
                // Implementeer de Equals()
                // EquivalentTo ipv Is Equal To
            Assert.That(list, Is.EquivalentTo(expectedList)); // Dit is beter om te werken met lijsten dan de is equal to
        }

        [Test]
        public void Test2()
        {
            //Arrange
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };

            //Act
            // Hier doen we iets dat iets returned waar minstens 1 waarde in zit dat aan een voorwaarde voldoet
            // bvb returned een lijst waar een getal groter dan 5 in zit

            //Assert
            // Hier willen we dan checken: is er ten minste 1 getal groter dan 5
            bool atLeastOneNumberLargerThan5 = list.Any(x => x > 5);
            Assert.That(atLeastOneNumberLargerThan5, Is.True);
        }

        [Test]
        public void Test3()
        {
            //Arrange
            List<Product> list = new List<Product>() { 
                new Product("1", 0),
                new Product("2", 10),
                new Product("3", 0),
                new Product("4", 20),
                new Product("5", 30),
                new Product("6", 50),
            };

            //Act
            // Hier doen we iets dat iets returned waar alle waarden in zit die aan een voorwaarde voldoet
            // bvb alle producten die op voorraad zijn (waarde groter dan 0)
            IEnumerable<Product> result = list.Where(x => x.Voorraad > 0);

            //Assert
            // Hier willen we dan checken: is er ten minste 1 getal groter dan 5
            bool allVoorradenGroterDan0 = list.All(x => x.Voorraad > 0);
            Assert.That(allVoorradenGroterDan0, Is.True);
        }

        [Test]
        public void TestException()
        {
            // Arrange
            int n1 = 10;
            int n2 = 0;
            Calculator sut = new Calculator();
            /*
            try
            {
                // Act
                sut.Divide(n1, n2);

                //Assert
                Assert.Fail();
            }
            catch (DivideByZeroException ex)
            {
                Assert.Pass();
            }
            */
            //Dit gaat niet werken
            //Assert.That(sut.Divide(n1, n2), ...);
            // sut.Divide wordt eerst berekend en het resultaat dan in de Assert.That meegegeven.
            // Exception kan niet opgevangen worden in Assert.That


            // Dit gaat wel werken
            Assert.That(() => sut.Divide(n1, n2), Throws.Exception.TypeOf<DivideByZeroException>());
            // We geven mee aan de assert.That wat er moet uitgevoerd worden
            // De sut.Divide wordt dus in de Assert.That uitgevoerd
            // Hierin wordt de exception opgevangen

            
        }
    }
}