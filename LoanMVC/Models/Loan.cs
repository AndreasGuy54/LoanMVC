namespace LoanMVC.Models
{
    public class Loan
    {
        public decimal Amount { get; set; }
        public double Rate { get; set; }
        public int Term { get; set; }
        public decimal Payment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalCost { get; set; }
        public List<LoanPayment> Payments { get; set; } = new List<LoanPayment>();
    }
}
    