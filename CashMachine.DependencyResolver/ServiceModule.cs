using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using CashMachine.Interfaces;
using CashMachine.Repository;
using CashMachine.Services;

namespace CashMachine.DependencyResolver
{

    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //Since we are not using a persistence store for the repository, we'll use singletonscope to maintain the state of the repository
            Bind<ICashRepository>().To<CashRepository>().InSingletonScope();
        }
    }
}

