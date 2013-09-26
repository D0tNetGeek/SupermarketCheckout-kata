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
