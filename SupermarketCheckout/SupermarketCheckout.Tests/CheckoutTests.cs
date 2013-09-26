using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace SupermarketCheckout.Tests
{
    [TestFixture]
    public class CheckoutTests
    {
        [TestCase('A', 50.0)]
        [TestCase('B', 30.0)]
        [TestCase('C', 20.0)]
        [TestCase('D', 15.0)]
        public void ScanningSingleItemReturnsCorrectPrice(char item, decimal expectedPrice)
        {
            var checkout = CreateCheckout();

            checkout.Scan(item);

            var actualPrice = checkout.CalculateTotal();

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [TestCase(new[] { 'A', 'B' }, 80.0)]
        [TestCase(new[] { 'A', 'C' }, 70.0)]
        [TestCase(new[] { 'A', 'D' }, 65.0)]
        [TestCase(new[] { 'B', 'C' }, 50.0)]
        [TestCase(new[] { 'B', 'D' }, 45.0)]
        [TestCase(new[] { 'C', 'D' }, 35.0)]
        public void ScanningMultipleSingleItemsReturnsCorrectPrice(char[] items, decimal expectedPrice)
        {
            var checkout = CreateCheckout();

            foreach (var item in items)
            {
                checkout.Scan(item);               
            }

            var actualPrice = checkout.CalculateTotal();

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void ScanningThreeAItemsReturnsCorrectPrice()
        {
            const decimal expectedPrice = 130.0m;
            var checkout = CreateCheckout();

            checkout.Scan('A');
            checkout.Scan('A');
            checkout.Scan('A');
            
            var actualPrice = checkout.CalculateTotal();

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        public void ScanningTwoBItemsReturnsCorrectPrice()
        {
            const decimal expectedPrice = 45.0m;
            var checkout = CreateCheckout();

            checkout.Scan('B');
            checkout.Scan('B');

            var actualPrice = checkout.CalculateTotal();

            Assert.AreEqual(expectedPrice, actualPrice);
        }

        [Test]
        [ExpectedException]
        public void ScanningAnInvalidItemThrowsExceptionOnCalculateTotal()
        {
            var checkout = CreateCheckout();

            checkout.Scan('Z');

            checkout.CalculateTotal();
        }



        private static ICheckout CreateCheckout()
        {
            return new Checkout();
        }
    }
}
