using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashMachine.Repository;
using CashMachine.Interfaces;
using CashMachine.Entities;
using CashMachine.Services.Calculators;

namespace CashMachine.Services
{
    public class CashMachineService : ICashMachineService
    {
        private ICashRepository _cashRepository;
        private ICashCalculator _calculator;

        public CashMachineService(ICashRepository cashRepository, ICashCalculator calculator)
        {
            _cashRepository = cashRepository;
            _calculator = calculator;
        }

        public WithdrawalResult GetCashAndBalance(decimal amount)
        {
            var balance = _cashRepository.getBalance();

            if (balance == 0)
            {
                return new WithdrawalResult { status = CashStatus.OutOfCash};
            }

            if (amount > _cashRepository.getBalance())
            {
                return new WithdrawalResult { status = CashStatus.NotEnoughtCash};
            }

            return _calculator.GetWithdrawalResult(amount);
        }

    }
}
