using System;
using LoanServer.Logic;
using NUnit.Framework;

namespace LoanServerTest
{
    [TestFixture]
    public class LoanCalculatorTests
    {
        [Test]
        public void CalculateInterestPaidPercentage_WithZeroLoanTerm_Exception()
        {
            // ARRANGE
            decimal totalAmountRepaid = 3000;
            int loanTerm = 0;
            decimal totalDebt = 9000;
            
            // ACT
            
            // ASSERT
            Assert.Throws<ArgumentException>(() =>
                LoanCalculator.InterestPaidPercentage(totalAmountRepaid, loanTerm, totalDebt));
        }
        
        [Test]
        public void CalculateInterestPaidPercentage_WithOneMonthLoanTerm_ReturnsZero()
        {
            // ARRANGE
            decimal totalAmountRepaid = 9000;
            int loanTerm = 1;
            decimal totalDebt = 9000;
            
            // ACT
            var interestPercent =LoanCalculator.InterestPaidPercentage(totalAmountRepaid, loanTerm, totalDebt);
            
            // ASSERT
            Assert.AreEqual(interestPercent, 0);
        }
        
        [Test]
        public void CalculateInterestPaidPercentage_WithMultipleMonthsLoanTerm_ReturnsPercent()
        {
            // ARRANGE
            decimal totalAmountRepaid = 7000;
            int loanTerm = 6;
            decimal totalDebt = 9000;

            const decimal expected = 13.90854463515m;
            
            // ACT
            var interestPercent =LoanCalculator.InterestPaidPercentage(totalAmountRepaid, loanTerm, totalDebt);
            
            // ASSERT
            Assert.AreEqual(interestPercent, expected);
        }
    }
}