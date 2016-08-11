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

        [TestCase(30, "£20 x 1,£10 x 1")]
        [TestCase(40, "£20 x 2")]
        [TestCase(90, "£50 x 1,£20 x 2")]
        [TestCase(110, "£50 x 2,£10 x 1")]
        [TestCase(240, "£50 x 4,£20 x 2")]
        public void GivenPoundsOnlyWithdrawalRequest_ThenReturnCorrectCashBreakdown(int cash, string expected)
        {
            var calculator = new LeastItemsCalculator();

            var result =  calculator.CalculateWithdralResult(cash);
            var testing = result.GetFormatedCashList();

            //var expected = "£100 x 1,10p x 1";
            Assert.That(testing, Is.EqualTo(expected));
        }

    }
}
