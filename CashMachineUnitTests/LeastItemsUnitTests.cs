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
    public class LeastItemsUnitTests
    {
        private LeastItemsCalculator _sut;
        private const int intialBalance = UnitTestsHelper.InitialBalance;
        private Mock<ICashRepository> cashRepositoryMock;
        private Dictionary<int, int> CashList;               
       
        [SetUp]
        public void TestInitialise()
        {
            cashRepositoryMock = new Mock<ICashRepository>();
            cashRepositoryMock.Setup(m => m.CashItems).Returns(UnitTestsHelper.CashItems);
           
            _sut = new LeastItemsCalculator(cashRepositoryMock.Object);
        }

        [TestCase(30, "£20 x 1,£10 x 1")]
        [TestCase(40, "£20 x 2")]
        [TestCase(90, "£50 x 1,£20 x 2")]
        [TestCase(110, "£50 x 2,£10 x 1")]
        [TestCase(240, "£50 x 4,£20 x 2")]
        public void GivenPoundsOnlyWithdrawalRequest_ThenReturnCorrectCashBreakdown(int cash, string expected)
        {
            var result =  _sut.GetWithdrawalResult(cash);
            var actual = result.FormatedCashList;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(13.07, "£10 x 1,£2 x 1,£1 x 1,5p x 1,2p x 1")]
        [TestCase(1.53, "£1 x 1,50p x 1,2p x 1,1p x 1")]
        [TestCase(92.41, "£50 x 1,£20 x 2,£2 x 1,20p x 2,1p x 1")]
        [TestCase(170.35, "£50 x 3,£20 x 1,20p x 1,10p x 1,5p x 1")]
        [TestCase(240.50, "£50 x 4,£20 x 2,50p x 1")]
        public void GivenPoundAndPenniesWithdrawalRequest_ThenReturnCorrectCashBreakdown(decimal cash, string expected)
        {
            var result = _sut.GetWithdrawalResult(cash);
            var actual = result.FormatedCashList;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
