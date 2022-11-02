using LoanMVC.Models;

namespace LoanMVC.Helpers
{
    public class LoanHelper
    {
        public Loan GetPayments(Loan loan)
        {

            //Calculate my Monthly Payment
            loan.Payment = CalcPayment(loan.Amount, loan.Rate, loan.Term);
            var monthlyPayment = loan.Payment;
            var term = loan.Term;
            
            loan.TotalCost = TotalCost(loan.Amount, loan.Rate);
            loan.TotalInterest = TotalInterest(loan.Amount, loan.Rate);

            decimal balance = loan.TotalCost;

            //Create Loop from 1 to the term
            //loop over each month until we reach the term of the loan
            for (int month = 1; month <= term; month++)
            {
                balance -= monthlyPayment;

                LoanPayment loanPayment = new();

                loanPayment.Month = month;
                loanPayment.Payment = loan.Payment;
                loanPayment.Balance = balance;

                //push the object into the loan model
                loan.Payments.Add(loanPayment);
            }

            //return the loan to the view
            return loan;
        }

        private static decimal CalcPayment(decimal amount, decimal rate, int term)
        {
            double rateD = Convert.ToDouble(rate);
            double amountD = Convert.ToDouble(amount);

            double paymentD = (amountD * (1 + rateD/100)) / term;


            return Convert.ToDecimal(paymentD);
        }

        private static decimal TotalInterest(decimal amount, decimal rate)
        {
            double rateD = Convert.ToDouble(rate);
            double amountD = Convert.ToDouble(amount);

            double totalInterest = amountD * rateD/100;
            return Convert.ToDecimal(totalInterest);
        }

        private static decimal TotalCost(decimal amount, decimal rate)
        {
            double rateD = Convert.ToDouble(rate);
            double amountD = Convert.ToDouble(amount);

            double totalCost = amountD * (1 + rateD / 100);
            return Convert.ToDecimal(totalCost);
        }

    }
}