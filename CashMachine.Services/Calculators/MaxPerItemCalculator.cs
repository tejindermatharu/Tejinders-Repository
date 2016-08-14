using CashMachine.Interfaces;
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
    public class MaxPerItemCalculator : CalculatorBase, ICashCalculator
    {
        private ICashRepository _cashRepository;

        //Required max number of 20 pounds in pennies
        private const int maxCashAmountRequired = 2000;

        public MaxPerItemCalculator(ICashRepository cashRepository)
            :base(cashRepository)
        {
            _cashRepository = cashRepository;            
        }

        protected override void CalculateWithdralResult(decimal amountRequested)
        {
            var penniesRequested = amountRequested.ToPennies();
            var remainingCash = penniesRequested;
            int maxCashAmt;
            int numberOfAvailableUnits;

            //Let see if there are any of the max required cash unit ie £20
            if (penniesRequested >= maxCashAmountRequired)
            {
                TryGetCashItemsBasedOnMaxRequestedCashItem(penniesRequested, out maxCashAmt, out numberOfAvailableUnits);
            }
            else
            {
                GetCashItemsBasedonLeastCashAmounts(penniesRequested, out maxCashAmt, out numberOfAvailableUnits);
            }
            
            var unitsNeeded = penniesRequested / maxCashAmt;

            int units = numberOfAvailableUnits >= unitsNeeded ? unitsNeeded : numberOfAvailableUnits;

            remainingCash = GetHighestCashAmountAndWithdraw(remainingCash, maxCashAmt, numberOfAvailableUnits, units);

            if (remainingCash != 0)
            {
                CalculateWithdralResult(remainingCash.ToPounds());
            }
        }

        private void TryGetCashItemsBasedOnMaxRequestedCashItem(int penniesRequested, out int maxCashAmt, out int numberOfAvailableUnits)
        {
            var cashItem = CashList.SingleOrDefault(x => x.Key == maxCashAmountRequired && x.Value != 0);
            if (cashItem.Key != null && cashItem.Value != 0)
            {
                maxCashAmt = cashItem.Key;
                numberOfAvailableUnits = cashItem.Value;
            }
            else
            {
                GetCashItemsBasedonLeastCashAmounts(penniesRequested, out maxCashAmt, out numberOfAvailableUnits);

            }
        }

        private void GetCashItemsBasedonLeastCashAmounts(int penniesRequested, out int maxCashAmt, out int numberOfAvailableUnits)
        {
            if (CashList.Any(x => x.Key <= penniesRequested && x.Value != 0))
            {
                maxCashAmt = CashList.Where(x => x.Key <= penniesRequested && x.Value != 0).Max(x => x.Key);
                var cashAmt = maxCashAmt;
                numberOfAvailableUnits = CashList.SingleOrDefault(x => x.Key == cashAmt).Value;
            }
            else
            {
                maxCashAmt = 0;
                numberOfAvailableUnits = 0;
            }
        }

    }
}
