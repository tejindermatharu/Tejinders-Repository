using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMachine.Entities.Extensions;
using CashMachine.Interfaces;

namespace CashMachine.Repository
{
    public class CashRepository : ICashRepository
    {
        private Dictionary<int, int> _cashItems;

        public Dictionary<int, int> CashItems
        {
            get { return this._cashItems; }
            private set { this._cashItems = value;}
        }

        public CashRepository()
        {
            _cashItems = new Dictionary<int, int>()
            {
                {1, 100},
                {2, 100},
                {5, 100},
                {10, 100},
                {20, 100},
                {50, 100},
                {100, 100},
                {200, 100},
                {500, 10},
                {1000, 10},
                {2000, 20},
                {5000, 50}
            };
        }

        public void updateCashMachine(int key, int value)
        {
            if (_cashItems.ContainsKey(key))
	        {
                _cashItems[key] = value;
	        }
        }

        public decimal getBalance()
        {
           var sum = _cashItems.Sum(x => x.Key * x.Value);
           return sum.ToPounds();
        }

    }
}
