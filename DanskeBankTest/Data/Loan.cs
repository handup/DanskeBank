using System;

namespace DanskeBankTest.Data
{
    public class Loan
    {
        public Loan(decimal totalAmountRepaid, int loanTerm, decimal totalDebt)
        {
            
        }
        
        public bool Decision { get; set; }
        
        public int TermLengthInMonths { get; set; }
        
        public decimal CurrentDebt { get; set; }
        
        public decimal FutureDebt { get; set; }

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
        
        // TODO: Refactor so it's more obvious what the method does
        private static bool MakeDecision (decimal amount)
        {
            return amount > 2000 && amount < 69000;
        } 
    }
}