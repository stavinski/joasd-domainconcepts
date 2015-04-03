using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Joasd.DomainConcepts.Financial.Test
{
    [TestClass]
    public class CurrencyConversion
    {
        private IDictionary<Currency, decimal> rates = new Dictionary<Currency, decimal>();

        [TestInitialize]
        public void Setup()
        {
            rates.Add(Currencies.EUR, 0.733028m);
        }

        [TestMethod]
        public void ConvertingToGBPShouldReturnCorrectAmount()
        {
            ICurrencyConverter sut = new ToCurrencyConverter(Currencies.GBP, rates);
            Money from = new Money(100, Currencies.EUR);
            Money result = sut.ConvertTo(from);
            Assert.AreEqual(73.302800m, result.Amount);
        }

        [TestMethod]
        public void ConvertingToGBPShouldReturnGBPCurrency()
        {
            ICurrencyConverter sut = new ToCurrencyConverter(Currencies.GBP, rates);
            Money from = new Money(100, Currencies.EUR);
            Money result = sut.ConvertTo(from);
            Assert.AreEqual(Currencies.GBP, result.Currency);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ConvertingWithUnknownRateShouldRaiseException()
        {
            ICurrencyConverter sut = new ToCurrencyConverter(Currencies.GBP, rates);
            Money from = new Money(100, Currencies.YEN);
            Money result = sut.ConvertTo(from);
        }
    }
}
