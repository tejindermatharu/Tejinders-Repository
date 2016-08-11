using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Entities
{
    public class WithdrawalResult
    {
        public decimal balance { get; set; }        
        public Dictionary<int, int> CashList { get; set; }

        public WithdrawalResult()
        {
            CashList = new Dictionary<int, int>();
        }

        public string GetFormatedCashList()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var cashItem in CashList.OrderByDescending(x => x.Key))
            {
                var cash = cashItem.Key >= 100 ? string.Format("£{0}", cashItem.Key) : string.Format("{0}p", cashItem.Key);

                builder.Append(string.Format("{0} x {1},",  cash, cashItem.Value.ToString()));
            }

            return builder.ToString().TrimEnd(',');
        }
    }
}
