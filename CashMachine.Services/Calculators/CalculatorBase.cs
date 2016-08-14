using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMachine.Repository;
using CashMachine.Interfaces;
using CashMachine.Entities;

namespace CashMachine.Services.Calculators
{
    public abstract class CalculatorBase
    {
        private ICashRepository _cashRepository;
        protected WithdrawalResult _result;
        protected Dictionary<int, int> CashList;

        public CalculatorBase(ICashRepository cashRepository)
        {
            _cashRepository = cashRepository;
        }

        public WithdrawalResult GetWithdrawalResult(decimal amountRequested)
        {
            _result = new WithdrawalResult();
            CashList = _cashRepository.CashItems;
            CalculateWithdralResult(amountRequested);

            _result.balance = _cashRepository.getBalance();
            return _result;
        }

        protected abstract void CalculateWithdralResult(decimal amountRequested);
              

        protected int GetHighestCashAmountAndWithdraw(int remainingCash, int maxCashAmt, int numberOfAvailableUnits, int unitsNeeded)
        {
            _result.CashList.Add(maxCashAmt, unitsNeeded);
            _cashRepository.updateCashMachine(maxCashAmt, numberOfAvailableUnits - unitsNeeded);
            remainingCash = remainingCash - (maxCashAmt * unitsNeeded);
            return remainingCash;
        }

    }
}
