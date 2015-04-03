using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joasd.DomainConcepts.Financial
{
    public class Money : IEquatable<Money>, IComparable<Money>
    {
        
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }

        public bool Equals(Money other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Amount.Equals(other.Amount) &&
                   Currency.Equals(other.Currency);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var converted = obj as Money;
            return converted != null &&
                   Equals(converted);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Amount.GetHashCode();
            hash ^= Currency.GetHashCode();
            return hash;
        }

        public static Money operator+(Money left, Money right) 
        {
            SameCurrencyCheck(left, right);
            return new Money(left.Amount + right.Amount, left.Currency);
        }

        public static Money operator-(Money left, Money right)
        {
            SameCurrencyCheck(left, right);
            return new Money(left.Amount - right.Amount, left.Currency);
        }

        public int CompareTo(Money other)
        {
            // makes no sense to compare different currencies
            SameCurrencyCheck(this, other); 
            return Amount.CompareTo(other.Amount);
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Currency, FormatAmount());
        }

        private string FormatAmount()
        {
            decimal val = Amount * (decimal)Math.Pow(10, Currency.DecimalPlaces);
            val = Math.Truncate(val);
            val = val / (decimal)Math.Pow(10, Currency.DecimalPlaces);
            return string.Format("{0:N" + Math.Abs(Currency.DecimalPlaces) + "}", val);
        }

        private static void SameCurrencyCheck(Money first, Money second)
        {
            if (!first.Currency.Equals(second.Currency))
            {
                throw new InvalidOperationException(string.Format("Cannot perform operations against different currencies, Currency: {0} and Currency: {1}", first.Currency, second.Currency));
            }
        }
    }
}
