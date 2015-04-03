using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joasd.DomainConcepts.Financial
{
    public class ToCurrencyConverter : ICurrencyConverter
    {
        private readonly Currency _toCurrency;
        private readonly IDictionary<Currency, decimal> _rates;

        public ToCurrencyConverter(Currency toCurrency, IDictionary<Currency, decimal> rates)
        {
            _toCurrency = toCurrency;
            _rates = rates;
        }

        public Money ConvertTo(Money from)
        {
            if (!_rates.ContainsKey(from.Currency))
            {
                throw new InvalidOperationException(string.Format("Could not find rate from currency: {0} to: {1}", from.Currency, _toCurrency));
            }

            decimal rate = _rates[from.Currency];
            return new Money(from.Amount * rate, _toCurrency);
        }
    }
}
