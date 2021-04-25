using LoanServer.Model;
using LoanServer.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        [HttpPost("repay")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RepayResponseDTO> Repay(decimal totalAmountRepaid, int loanTerm, decimal totalDebt)
        {
            if (loanTerm < 1 || totalAmountRepaid < 1)
                return BadRequest("Both the term and the amount must be positive");
            
            if (totalAmountRepaid > totalDebt)
                return BadRequest("The amount repaid cannot be higher");
            
            return new RepayResponseDTO()
            {
                InterestRatePercentage = LoanCalculator.InterestPaidPercentage(totalAmountRepaid, loanTerm, totalDebt), 
                Decision = MakeDecision(totalAmountRepaid)
            };
            
            // TODO: Refactor so it's more obvious what the method does and possibly move it to Logic namespace
            bool MakeDecision (decimal amount) => amount > 2000 && amount < 69000;
        }
    }
}