using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using CashMachine.Interfaces;
using CashMachine.Services;
using CashMachine.Services.Calculators;

namespace CashMachine
{
    public class ConsoleModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<ICashCalculator>().To<LeastItemsCalculator>();
            Bind<ICashCalculator>().To<MaxPerItemCalculator>();
            Bind<ICashMachineService>().To<CashMachineService>();
        }
    }
}
