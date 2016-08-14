using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CashMachine.Services.Calculators;
using CashMachine.Interfaces;
using CashMachine.TestCommon;
using Moq;

namespace CashMachineUnitTests
{
    [TestFixture]
    public class MaxPerItemUnitTests
    {
        private MaxPerItemCalculator _sut;
        private const int intialBalance = UnitTestsHelper.InitialBalance;
        private Mock<ICashRepository> cashRepositoryMock;
        private Dictionary<int, int> CashList;

        [SetUp]
        public void TestInitialise()
        {
            cashRepositoryMock = new Mock<ICashRepository>();
            cashRepositoryMock.Setup(m => m.CashItems).Returns(UnitTestsHelper.CashItems);

            _sut = new MaxPerItemCalculator(cashRepositoryMock.Object);
        }

        [TestCase(30, "£20 x 1,£10 x 1")]
        [TestCase(40, "£20 x 2")]
        [TestCase(90, "£20 x 4,£10 x 1")]
        [TestCase(110, "£20 x 5,£10 x 1")]
        [TestCase(240, "£20 x 12")]
        public void GivenPoundsOnlyWithdrawalRequest_ThenReturnCorrectCashBreakdown(int cash, string expected)
        {
            var result = _sut.GetWithdrawalResult(cash);
            var actual = result.FormatedCashList;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(13.07, "£10 x 1,£2 x 1,£1 x 1,5p x 1,2p x 1")]
        [TestCase(1.53, "£1 x 1,50p x 1,2p x 1,1p x 1")]
        [TestCase(92.41, "£20 x 4,£10 x 1,£2 x 1,20p x 2,1p x 1")]
        [TestCase(170.35, "£20 x 8,£10 x 1,20p x 1,10p x 1,5p x 1")]
        [TestCase(240.50, "£20 x 12,50p x 1")]
        public void GivenPoundAndPenniesWithdrawalRequest_ThenReturnCorrectCashBreakdown(decimal cash, string expected)
        {
            var result = _sut.GetWithdrawalResult(cash);
            var actual = result.FormatedCashList;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
