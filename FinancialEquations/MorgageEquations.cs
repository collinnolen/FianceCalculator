using System;

namespace FinancialEquations
{
    public class MorgageEquations
    {
        public static decimal MorgagePayment(decimal initialLoanAmount, int remainingPayments, double interestRate, int paymentsPerYear = 12)
        {
            double interestPerPayment = interestRate / paymentsPerYear;

            decimal first = initialLoanAmount * Convert.ToDecimal(interestPerPayment);
            decimal second = Convert.ToDecimal(Math.Pow(1 + interestPerPayment, remainingPayments));
            decimal third = second - 1;

            return (first * second) / third;
        }

        public static decimal InterestDue(decimal loanAmount, double interestRate, int paymentsPerYear = 12)
        {
            return loanAmount * Convert.ToDecimal(interestRate / paymentsPerYear);
        }

        public static decimal TotalPayement(decimal initialLoanAmount, decimal morgagePayment, double interestRate, int payementsToCalculate, int paymentsPerYear = 12)
        {
            decimal loanAmount = initialLoanAmount;
            decimal amountPaid = 0;
            int counter = 0;

            while (loanAmount > 0 && counter != payementsToCalculate)
            { 
                if (loanAmount > morgagePayment)
                {
                    amountPaid += morgagePayment;
                    loanAmount -= morgagePayment - InterestDue(loanAmount, interestRate, paymentsPerYear);
                }
                else
                {
                    amountPaid += loanAmount + InterestDue(loanAmount, interestRate, paymentsPerYear);
                    break;
                }

                counter++;
            }

            return amountPaid;
        }
    }
}
