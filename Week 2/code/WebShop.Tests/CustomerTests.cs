using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Tests
{
    [TestFixture]
    internal class CustomerTests
    {
        private Store store;
        private Customer customer;

        // Gebruik van constructor niet goed om algemene arrange code in te voeren
            // Slechts 1 keer voor de hele klasse opgeroepen
            // Gevolg dat de ene test de andere beinvloedt en je wilt dat je testen los staan van elkaar
        // Beter:
            // Gebruik de SetUp functie met [SetUp] attribuut
            // Gebruik factory methods

        public CustomerTests() { 
            /*store = new Store();
            store.AddInventory(Product.Shampoo, 10);
            
            customer = new Customer();*/  // dit willen we niet
        }

        [SetUp]
        /*[OneTimeSetUp]  -> 1 keer voor alle testen
        [TearDown]          -> na elke test
        [OneTimeTearDown] -> 1 keer na alle testen
        */
        public void SetUp()
        {
            // dit is beter -> setup wordt namelijk voor elke test uitgevoerd
            store = new Store();
            customer = new Customer();
        }

        public void makeStoreWithShampoo10()
        {
            // dit is een factory method
            store.AddInventory(Product.Shampoo, 10);
        }

        [Test]
        public void _v3_Purchase_Buy5ShampooFrom10Inventory_BasketContains5InventoryContains5()
        {
            // Arrange
            Dictionary<Product, int> expectedBasket = new Dictionary<Product, int>() { { Product.Shampoo, 5 } };
            makeStoreWithShampoo10(); // met gebruik van factory method

            // Act
            bool result = customer.Purchase(store, Product.Shampoo, 5);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(customer.Basket, Is.EqualTo(expectedBasket));
            Assert.That(store.GetInventory(Product.Shampoo), Is.EqualTo(5));
        }


        [Test]
        public void _v2_Purchase_Buy5ShampooFrom10Inventory_BasketContains5InventoryContains5()
        {
            // Arrange
            Dictionary<Product, int> expectedBasket = new Dictionary<Product, int>() { { Product.Shampoo, 5 } };

            // Act
            bool result = customer.Purchase(store, Product.Shampoo, 10);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(customer.Basket, Is.EqualTo(expectedBasket));
            Assert.That(store.GetInventory(Product.Shampoo), Is.EqualTo(5));
        }


        [Test]
        public void _v2_1_Purchase_Buy5ShampooFrom10Inventory_BasketContains5InventoryContains5()
        {
            // Arrange
            Dictionary<Product, int> expectedBasket = new Dictionary<Product, int>() { { Product.Shampoo, 5 } };

            // Act
            bool result = customer.Purchase(store, Product.Shampoo, 10);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(customer.Basket, Is.EqualTo(expectedBasket));
            Assert.That(store.GetInventory(Product.Shampoo), Is.EqualTo(5));
        }


        [Test]
        public void _v1_Purchase_Buy5ShampooFrom10Inventory_BasketContains5InventoryContains5()
        {
            // Arrange
            Store store = new Store();
            store.AddInventory(Product.Shampoo, 10);
            Customer sut = new Customer();
            Dictionary<Product, int> expectedBasket = new Dictionary<Product, int>() { { Product.Shampoo, 5 } };

            // Act
            bool result = sut.Purchase(store, Product.Shampoo, 5);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(sut.Basket, Is.EqualTo(expectedBasket));
            Assert.That(store.GetInventory(Product.Shampoo), Is.EqualTo(5));
        }
    }
}
