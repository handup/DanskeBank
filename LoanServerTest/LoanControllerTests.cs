using LoanServer.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace LoanServerTest
{
    [TestFixture]
    public class LoanControllerTests
    {
        [Test]
        public void Repay_WithZeroLoanTerm_BadRequest()
        {
            // ARRANGE
            decimal totalAmountRepaid = 3000;
            int loanTerm = 0;
            decimal totalDebt = 9000;
            
            var controller = new LoanController();
            
            // ACT
            var result = controller.Repay(totalAmountRepaid, loanTerm, totalDebt);

            // ASSERT
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
        
        [Test]
        public void Repay_WithNegativeDebt_BadRequest()
        {
            // ARRANGE
            decimal totalAmountRepaid = 3000;
            int loanTerm = 0;
            decimal totalDebt = 9000;
            
            var controller = new LoanController();
            
            // ACT
            var result = controller.Repay(totalAmountRepaid, loanTerm, totalDebt);

            // ASSERT
            Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
        }
        
        [Test]
        public void Repay_WithHappyPathOKWithDecisionYes()
        {
            // ARRANGE
            decimal totalAmountRepaid = 6000;
            int loanTerm = 3;
            decimal totalDebt = 9000;
            
            decimal expected = 7.78815m;
            
            var controller = new LoanController();
            
            // ACT
            var result = controller.Repay(totalAmountRepaid, loanTerm, totalDebt);
            var response = result.Value;

            // ASSERT
            // ASSERT
            Assert.AreEqual(true, response.Decision);
            Assert.AreEqual(expected, response.InterestRatePercentage);
        }
        
        [Test]
        public void Repay_WithHappyPath_OKWithDecisionNo()
        {
            // ARRANGE
            decimal totalAmountRepaid = 70000;
            int loanTerm = 6;
            decimal totalDebt = 90000;
            
            decimal expected = 27.87590505523809523809523809m;
            
            var controller = new LoanController();
            
            // ACT
            var result = controller.Repay(totalAmountRepaid, loanTerm, totalDebt);
            var response = result.Value;
            
            // ASSERT
            Assert.AreEqual(false, response.Decision);
            Assert.AreEqual(expected, response.InterestRatePercentage);
        }
    }
}