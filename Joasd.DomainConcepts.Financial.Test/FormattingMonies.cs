using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Joasd.DomainConcepts.Financial.Test
{
    [TestClass]
    public class Formatting_Monies
    {
        [TestMethod]
        public void GBP()
        {
            Money sut = new Money(10000, Currencies.GBP);
            string expected = "GBP 10,000.00";
            string actual = sut.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EUR()
        {
            Money sut = new Money(10000, Currencies.EUR);
            string expected = "EUR 10,000.00";
            string actual = sut.ToString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void YEN()
        {
            Money sut = new Money(10000, Currencies.YEN);
            string expected = "YEN 10,000";
            string actual = sut.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
