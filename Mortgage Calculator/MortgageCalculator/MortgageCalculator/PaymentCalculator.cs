using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator
{
    public static class PaymentCalculator
    {
        //need the mortgage length, the loan amount, with insurance, HOA fees, homeowners inssurance, property tax w/ property value increase
        public static double PreMonthlyPayment(double mortgageLength, double loanValue, double loanInsurance, double hoaFees, double interestRate, double marketValue, double purchasePrice, double downPayment)
        {
            interestRate = (interestRate / 100);
            //P * (r / n) * [(1 + r / n) ^ n(t)] / [(1 + r / n) ^ n(t) - 1]
            //P: Principle(loan amount)
            //r: Annual Interest Rate
            //n: Number of payments per year
            //t: Term(number of years for the loan)
            double paymentTotal = (purchasePrice - downPayment) * (((interestRate / 12) * Math.Pow(1 + (interestRate / 12), (12 * mortgageLength))) / (Math.Pow(1 + (interestRate / 12), (12 * mortgageLength)) - 1));
            //Console.WriteLine($"PAY ATTENTION TO THIS LINE!!! {paymentTotal}");
            return paymentTotal;
        }


        public static double MonthlyPayment(double mortgageLength, double loanValue, double loanInsurance, double hoaFees, double interestRate, double marketValue, double purchasePrice, double downPayment)
        {
            
            interestRate = (interestRate / 100);
            double paymentTotal = (purchasePrice - downPayment) * (((interestRate / 12) * Math.Pow(1 + (interestRate / 12), (12 * mortgageLength))) / (Math.Pow(1 + (interestRate / 12), (12 * mortgageLength)) - 1));
            Console.WriteLine($"The total amount due for your mortgage is {(paymentTotal * (12 * mortgageLength)):c}.");
            Console.WriteLine($"Before added values (tax, home insurance, HOA fees) your monthly payment will be {(paymentTotal):c}");
            // .02 is from porperty tax and home insurance combined
            Console.WriteLine($"After added values, your monthly payment will be {(paymentTotal + hoaFees + ((purchasePrice * .02) / 12)):c}.");
            Console.WriteLine(" ");
            return paymentTotal;
        }
    }
}
