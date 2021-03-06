﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMachine.Entities.Extensions;

namespace CashMachine.Entities
{
    public class WithdrawalResult
    {
        public decimal balance { get; set; }        
        public Dictionary<int, int> CashList { get; set; }

        public CashStatus status { get; set; }

        public WithdrawalResult()
        {
            CashList = new Dictionary<int, int>();
            status = CashStatus.HaveCash;
        }

        public string FormatedCashList { get { return GetFormatedCashList(); } }

        private string GetFormatedCashList()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var cashItem in CashList.OrderByDescending(x => x.Key))
            {
                var cash = cashItem.Key > 99 ? string.Format("£{0}", cashItem.Key.ToPounds()) : string.Format("{0}p", cashItem.Key);

                builder.Append(string.Format("{0} x {1},",  cash, cashItem.Value.ToString()));
            }

            return builder.ToString().TrimEnd(',');
        }
    }
}
