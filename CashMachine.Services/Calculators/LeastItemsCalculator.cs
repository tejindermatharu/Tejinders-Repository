using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMachine.Entities;
using CashMachine.Entities.Extensions;

namespace CashMachine.Services.Calculators
{
    public class LeastItemsCalculator
    {
        private Dictionary<int, int> CashList;
        private WithdrawalResult result;

        public LeastItemsCalculator()
        {
            CashList = new Dictionary<int, int>();
            result = new WithdrawalResult();

            CashList.Add(1, 100);
            CashList.Add(2, 100);
            CashList.Add(5, 100);
            CashList.Add(10, 100);
            CashList.Add(20, 100);
            CashList.Add(50, 100);
            CashList.Add(100, 100);
            CashList.Add(200, 100);
            CashList.Add(500, 10);
            CashList.Add(1000, 10);
            CashList.Add(2000, 20);
            CashList.Add(5000, 50);
        }

        public WithdrawalResult CalculateWithdralResult(decimal amountRequested)
        {
            var pennies = amountRequested.ToPennies();
            var remainingCash = pennies;

            var maxCashAmt = CashList.Where(x => x.Key <= pennies && x.Value != 0).Max(x => x.Key);
            var numberOfAvailableUnits = CashList.SingleOrDefault(x => x.Key == maxCashAmt).Value;
            var unitsNeeded = pennies / maxCashAmt;

            if (numberOfAvailableUnits >= unitsNeeded)
            {
                GetHighestCashAmountAndWithdraw(maxCashAmt, numberOfAvailableUnits, unitsNeeded);
                remainingCash = remainingCash - (maxCashAmt * unitsNeeded);
            }
            else
            {
                GetHighestCashAmountAndWithdraw(maxCashAmt, numberOfAvailableUnits, numberOfAvailableUnits);
                remainingCash = remainingCash - (maxCashAmt * numberOfAvailableUnits);
            }

            if (remainingCash != 0)
            {
                CalculateWithdralResult(remainingCash.ToPounds());
            }

            return result;
                   //}
               //catch (DivideByZeroException e)
               //{
               //    throw new DivideByZeroException();
               //}
               //catch (Exception ex)
               //{
               //    throw new Exception("There was a error", ex);
               //}


           //} while (remainingCash != 0);
        }

        private void GetHighestCashAmountAndWithdraw(int maxCashAmt, int numberOfAvailableUnits, int unitsNeeded)
        {
            result.CashList.Add(maxCashAmt, unitsNeeded);
            CashList[maxCashAmt] = numberOfAvailableUnits - unitsNeeded;
        }
    }
}
