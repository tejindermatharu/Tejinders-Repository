using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Entities.Extensions
{
    public static class CashExtensions
    {
        public static int ToPennies(this decimal amount)
        {
            return Decimal.ToInt32(amount) * 100;
        }

        public static decimal ToPounds(this int pennies)
        {
           if (pennies == 0)
           {
               throw new ArgumentException("Cannot convert 0 pennies to pounds.");
           }

           return Convert.ToDecimal(pennies) / 100;
        }
    }
}
