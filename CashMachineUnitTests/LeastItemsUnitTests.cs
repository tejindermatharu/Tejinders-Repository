using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CashMachine.Services.Calculators;

namespace CashMachineUnitTests
{
    [TestFixture]
    public class LeastItemsUnitTests
    {
        private LeastItemsCalculator _sut;

        [TestFixtureSetUp]
        public void TestInitialise()
        {
            _sut = new LeastItemsCalculator();
        }

        [Test]
        public void GivenWithdrawalRequestReturn()
        {
            var test = 110 % 50;
            var calculator = new LeastItemsCalculator();

            var result =  calculator.CalculateWithdralResult(110);
            var testing = result.GetFormatedCashList();

            var expected = "£100 x 1,10p x 1";
            Assert.That(testing, Is.EqualTo(expected));
        }

    }
}
