using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using CashMachine.DependencyResolver;
using CashMachine.Interfaces;
using CashMachine.Entities;

namespace CashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = LoadModules();

            var machineService = kernel.Get<ICashMachineService>();

            int choice;
            decimal withdraw;

            while (true)
            {
                Console.WriteLine("\n ENTER THE AMOUNT TO WITHDRAW: ");
                Console.WriteLine(); // Empty line.
                withdraw = decimal.Parse(Console.ReadLine());

                var withdrawalResult = machineService.GetCashAndBalance(withdraw);

                switch (withdrawalResult.status)
                {
                    case CashStatus.HaveCash:
                         Console.WriteLine(string.Format("\n {0} ", withdrawalResult.FormatedCashList));
                         Console.WriteLine(string.Format("\n {0} ", withdrawalResult.balance));
                         Console.WriteLine();
                        break;
                    case CashStatus.NotEnoughtCash:
                        Console.WriteLine();
                        Console.WriteLine("Cash machine does not have enought cash for your request.");
                        break;
                    case CashStatus.OutOfCash:
                        Console.WriteLine();
                        Console.WriteLine("Cash machine does not have any cash.");
                        break;
                    default:
                        break;
                }
            }
        }

        private static IKernel LoadModules()
        {
            IKernel kernel = new StandardKernel(new ConsoleModule());

            var modules = new List<INinjectModule>
            {
                new ServiceModule()
            };
            kernel.Load(modules);
            return kernel;
        }
    }
}
