using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joasd.DomainConcepts.Financial
{
    public class Currency : IEquatable<Currency>
    {
        public Currency(string code, int decimalPlaces, string description)
        {
            Code = code;
            DecimalPlaces = decimalPlaces;
            Description = description;
        }

        public string Code { get; private set; }
        public int DecimalPlaces { get; private set; }
        public string Description { get; private set; }

        public bool Equals(Currency other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Code.Equals(other.Code) &&
                   DecimalPlaces.Equals(other.DecimalPlaces) &&
                   Description.Equals(other.Description);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var converted = obj as Currency;
            return converted != null &&
                   Equals(converted);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash ^= Code.GetHashCode();
            hash ^= DecimalPlaces.GetHashCode();
            hash ^= Description.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return Code;
        }
    }
}
