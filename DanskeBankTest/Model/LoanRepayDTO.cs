namespace DanskeBankTest.Model
{
    public class LoanRepayDTO
    {
        public decimal AmountRepaid { get; set; }
        public int LoanTerm { get; set; } 
        public decimal TotalDebt { get; set; }
    }
}