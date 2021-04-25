using System;

namespace LoanServer.Logic
{
    public static class LoanCalculator
    {
        public static decimal InterestPaidPercentage(decimal totalAmountRepaid, int loanTerm, decimal totalDebt)
        {
            if (loanTerm < 1)
                throw new ArgumentException("Only positive terms allowed");
            
            var amountPerMonth = totalAmountRepaid / loanTerm;
            var sum = totalDebt;
            decimal totalInterest = 0;
            
            for(var i = loanTerm; i > 0; i--)
            {
                sum -= amountPerMonth;
                
                decimal interest = CalculateMonthlyInterestRate(sum) / 100 * sum;
                sum += interest;
                totalInterest += interest;
            }

            var rawPercentage = totalInterest / totalAmountRepaid * 100;

            return rawPercentage > 100 ? 100 : rawPercentage;
        }
        
        private static decimal CalculateMonthlyInterestRate (decimal debt){
            // In the problem description there are f.x. gaps between 39000 and 40000
            // I arbitrarily chose to use the round numbers and close the gap
            if (debt < 0)
                throw new ArgumentException("Argument cannot be negative.");

            if (debt == 0)
                return 0;
            
            if (debt <= 20000)
                return 3;
            
            if (debt <= 40000) 
                return 4;
            
            if (debt <= 60000)
                return 5; 
                
            return 6;
        } 
    }
}