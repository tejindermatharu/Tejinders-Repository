using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CashMachine.Services;
using CashMachine.Services.Calculators;
using CashMachine.TestCommon;
using CashMachine.Repository;

namespace CashMachine.IntegrationTests
{
    [TestFixture]
    public class CashMachineIntegrationTests
    {

        private CashMachineService _sut;
        private const int intialBalance = UnitTestsHelper.InitialBalance;
        private Dictionary<int, int> CashList;

        [SetUp]
        public void TestInitialise()
        {
            var repository = new CashRepository();
            var calculator = new MaxPerItemCalculator(repository);
            _sut = new CashMachineService(repository, calculator);
        }

        [TestCase(240.50, 3197.5)]
        [TestCase(83.33, 3354.67)]
        [TestCase(1050.65, 2387.35)]
        public void GivenAWithdrawalRequest_ThenReturnCorrectBalance(decimal cash, decimal expectedBalance)
        {
            var result = _sut.GetCashAndBalance(cash);
            Assert.That(result.balance, Is.EqualTo(expectedBalance));
        }

        [Test]
        public void GivenAWithdrawalRequest_WhenMultipleWithdrawalsMade_ThenReturnCorrectBalance()
        {
            var result = _sut.GetCashAndBalance(240.50m);
            var result2 = _sut.GetCashAndBalance(505.32m);

            Assert.That(result2.balance, Is.EqualTo(2692.18));
        }
    }
}
