using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joasd.DomainConcepts.Financial
{
    public interface ICurrencyConverter
    {
        Money ConvertTo(Money from);
    }
}
