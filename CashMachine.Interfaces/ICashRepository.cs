﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine.Interfaces
{
    public interface ICashRepository
    {
        Dictionary<int, int> CashItems { get; }
        decimal getBalance();
        void updateCashMachine(int key, int value);
    }
}
