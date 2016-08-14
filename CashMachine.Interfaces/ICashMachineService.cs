using System;
using CashMachine.Entities;

namespace CashMachine.Interfaces
{
    public interface ICashMachineService
    {
        WithdrawalResult GetCashAndBalance(decimal amount);
    }
}
