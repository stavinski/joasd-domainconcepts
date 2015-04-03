using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Joasd.DomainConcepts.Financial.Test
{
    [TestClass]
    public class MoneyOperations
    {
        [TestMethod]
        public void AddingSameCurrencyShouldIncreaseAmount()
        {
            Money sut = new Money(10, Currencies.GBP);
            Money other = new Money(20, Currencies.GBP);
            Money result = sut + other;
            Assert.AreEqual(30, result.Amount);
        }

        [TestMethod]
        public void AddingSameCurrencyShouldHaveSameCurrency()
        {
            Money sut = new Money(10, Currencies.GBP);
            Money other = new Money(20, Currencies.GBP);
            Money result = sut + other;
            Assert.AreEqual(Currencies.GBP, result.Currency);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingDifferentCurrencyShouldRaiseException()
        {
            Money sut = new Money(10, Currencies.EUR);
            Money other = new Money(20, Currencies.GBP);
            Money result = sut + other;
        }

        [TestMethod]
        public void SubtractingSameCurrencyShouldDecreaseAmount()
        {
            Money sut = new Money(30, Currencies.GBP);
            Money other = new Money(10, Currencies.GBP);
            Money result = sut - other;
            Assert.AreEqual(20, result.Amount);
        }

        [TestMethod]
        public void SubtractingSameCurrencyShouldHaveSameCurrency()
        {
            Money sut = new Money(30, Currencies.GBP);
            Money other = new Money(10, Currencies.GBP);
            Money result = sut - other;
            Assert.AreEqual(Currencies.GBP, result.Currency);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SubtractingDifferentCurrencyShouldRaiseException()
        {
            Money sut = new Money(30, Currencies.EUR);
            Money other = new Money(10, Currencies.GBP);
            Money result = sut - other;
        }
    }
}
