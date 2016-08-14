using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMachine.Entities;
using CashMachine.Entities.Extensions;
using CashMachine.Repository;
using CashMachine.Interfaces;

namespace CashMachine.Services.Calculators
{
    public class LeastItemsCalculator : CalculatorBase, ICashCalculator
    {
        private ICashRepository _cashRepository;

        public LeastItemsCalculator(ICashRepository cashRepository)
            : base(cashRepository)
        {
            _cashRepository = cashRepository;
            CashList = _cashRepository.CashItems;
        }

        public decimal getBalance()
        {
           return _cashRepository.getBalance();
        }

        protected override void CalculateWithdralResult(decimal amountRequested)
        {
            var pennies = amountRequested.ToPennies();
            var remainingCash = pennies;

            var maxCashAmt = CashList.Where(x => x.Key <= pennies && x.Value != 0).Max(x => x.Key);
            var numberOfAvailableUnits = CashList.SingleOrDefault(x => x.Key == maxCashAmt).Value;
            var unitsNeeded = pennies / maxCashAmt;

            int units = numberOfAvailableUnits >= unitsNeeded ? unitsNeeded : numberOfAvailableUnits;

            remainingCash = GetHighestCashAmountAndWithdraw(remainingCash, maxCashAmt, numberOfAvailableUnits, units);

            if (remainingCash != 0)
            {
                CalculateWithdralResult(remainingCash.ToPounds());
            }
        }
    }
}
