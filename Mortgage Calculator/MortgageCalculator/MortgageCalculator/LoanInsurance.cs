using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    public static class LoanInsurance
    {
        public static double LoanInsuranceCalculator(double purchasePrice, double marketValue, double loanValue, double downPayment, double mortgageLength, double equity)
        {
            double addedLoanInsuranceT = 0;
            double remainingAmountNeeded = (purchasePrice * 1.01) / (mortgageLength * 12);
            double remainingPercentage;

            if (equity >= 10)
                Console.WriteLine("Loan insurance is not required.");
            else
            {
                remainingPercentage = 10 - equity;
                Console.WriteLine($"Your loan will require loan insurance unless {Math.Round(remainingPercentage, 2)}% ({(remainingPercentage * (loanValue / 100)):c}) of the loan value is added to the down payment.");
                Console.WriteLine($"The cost of loan insurance for your loan is {(remainingAmountNeeded * (12 * mortgageLength)):c} ({remainingAmountNeeded:c} monthly).");
                addedLoanInsuranceT = (remainingAmountNeeded * (12 * mortgageLength));
            }
            Console.WriteLine(" ");
            return addedLoanInsuranceT;
        }
    }
    
}
