using System;
using CashMachine.Entities;
namespace CashMachine.Interfaces
{
    public interface ICashCalculator
    {
        WithdrawalResult GetWithdrawalResult(decimal amountRequested);
    }
}
