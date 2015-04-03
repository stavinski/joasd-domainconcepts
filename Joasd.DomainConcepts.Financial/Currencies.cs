using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joasd.DomainConcepts.Financial
{
    public class Currencies
    {
        public static readonly Currency GBP = new Currency("GBP", 2, "Pound Sterling");
        public static readonly Currency EUR = new Currency("EUR", 2, "Euro");
        public static readonly Currency YEN = new Currency("YEN", 0, "Japanese Yen");
    }
}
