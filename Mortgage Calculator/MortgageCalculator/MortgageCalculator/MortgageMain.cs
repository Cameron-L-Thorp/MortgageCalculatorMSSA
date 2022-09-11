
namespace MortgageCalculator
{
    internal class MortgageMain
    {
        static void Main(string[] args)
        {

            double marketValue = 0;
            double purchasePrice = 0;
            double downPayment = 0;
            double loanInterestRate = 0;
            int mortgageLength = 0;
            double monthlyIncome = 0;
            double loanValue = 0;
            double hoaFees = 0;
            double homeEquity = 0;
            MarketAssigner(out marketValue);
            PurchaseAssigner(out purchasePrice);
            DownPaymentAssigner(out downPayment);
            LoanInterestRateAssigner(out loanInterestRate);
            MortgageLength(out mortgageLength);
            HomeEquityAssigner(marketValue, purchasePrice, downPayment, out homeEquity);
            LoanValueAssigner(purchasePrice, downPayment, out loanValue);
            double loanInsuranceTotal = LoanInsurance.LoanInsuranceCalculator(purchasePrice, marketValue, loanValue, downPayment, mortgageLength, homeEquity);
            HOAFeesAssigner(out hoaFees);
            IncomeAssigner(out monthlyIncome);
           
            double preMonthlyPayment = PaymentCalculator.PreMonthlyPayment(mortgageLength, loanValue, loanInsuranceTotal, hoaFees, loanInterestRate, marketValue, purchasePrice, downPayment);
            if ((monthlyIncome * .25) < preMonthlyPayment)
            {
                Console.WriteLine($"Loan is denyed due to comparison of monthly income: {monthlyIncome:c} to estimated monthly payment: {preMonthlyPayment:c}.");
                Console.WriteLine("Please investigate placing a larger down payment, or buying a more affordable home.");
            }
            else
            {
                Console.WriteLine("Loan approved!");
                PaymentCalculator.MonthlyPayment(mortgageLength, loanValue, loanInsuranceTotal, hoaFees, loanInterestRate, marketValue, purchasePrice, downPayment);
            }

        }

        public static void MarketAssigner(out double marketValue)
        {
            double enteredMarketValue = 0;
            bool validInput = false;
            Console.WriteLine("Please enter the market value of the house you wish to purchase (in dollars).");
            while (!validInput)
            {
                validInput = true;
                try
                {
                    enteredMarketValue = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Market value entered: {enteredMarketValue:c}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The enterd value of the house is not valid. Please enter an amount in dollars. " + ex.Message);
                    validInput = false;
                }
            }
            marketValue = enteredMarketValue;
            Console.WriteLine(" ");
        }

        public static void PurchaseAssigner(out double purchasePrice)
        {
            double enteredPurchasePrice = 0;
            bool validInput = false;
            Console.WriteLine("Please enter the purchase price of the house you wish to purchase (in dollars).");
            while (!validInput)
            {
                validInput = true;
                try
                {
                    enteredPurchasePrice = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Purchase price entered: {enteredPurchasePrice:c}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The enterd purchase price of the house is not valid. Please enter an amount in dollars. " + ex.Message);
                    validInput = false;
                }
            }
            purchasePrice = enteredPurchasePrice;
            Console.WriteLine(" ");
        }

        public static void LoanValueAssigner(double enteredPurchasePrice, double enteredDownPayment,  out double loanValue)
        {
            double prePercentFeeValue = enteredPurchasePrice - enteredDownPayment;
            prePercentFeeValue += (prePercentFeeValue * .01) + 2500;
            loanValue = prePercentFeeValue;
            Console.WriteLine($"Your loan value is {loanValue:c}.");
            Console.WriteLine(" ");
        }

        public static void DownPaymentAssigner(out double downPayment)
        {
            double enteredDownPayment = 0;
            bool validInput = false;
            Console.WriteLine("Please enter the down payment (in dollars). (if none, enter 0)");
            while (!validInput)
            {
                validInput = true;
                try
                {
                    enteredDownPayment = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Down payment value entered: {enteredDownPayment:c}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The enterd value of the down payment is not valid. Please enter an amount in dollars. " + ex.Message);
                    validInput = false;
                }
            }
            downPayment = enteredDownPayment;
            Console.WriteLine(" ");
        }

        public static void LoanInterestRateAssigner(out double loanInterestRate)
        {
            double enteredLoanInterestRate = 0;
            bool validInput = false;
            Console.WriteLine("Please enter the annual interest percentage on your loan. (if none, enter 0)");
            while (!validInput)
            {
                validInput = true;
                try
                {
                    enteredLoanInterestRate = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Interest rate percentage enterd: {enteredLoanInterestRate}%");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The enterd value of the interest percentage is not valid. " + ex.Message);
                    validInput = false;
                }
            }
            loanInterestRate = enteredLoanInterestRate;
            Console.WriteLine(" ");
        }

        public static void MortgageLength(out int mortgageLength)
        {
            int enteredLength = 0;
            bool validInput = false;
            Console.WriteLine("Please enter how long your mortgage will be [15 or 30].");
            while (!validInput)
            {
                try
                {
                    while (!validInput)
                    {
                        enteredLength = Convert.ToInt32(Console.ReadLine());
                        if (enteredLength == 15 || enteredLength == 30)
                        {
                            Console.WriteLine($"You have selected a {enteredLength} year loan ({enteredLength * 12} payments).");
                            validInput = true;
                        }

                        else
                            Console.WriteLine($"You entered {enteredLength}, please enter 15 or 30 years.");

                        continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The year value entered was not valid." + ex.Message);
                    validInput = false;
                }
            }
            mortgageLength = enteredLength;
            Console.WriteLine(" ");
        }

        public static void IncomeAssigner(out double monthlyIncome)
        {
            double enteredMonthlyIncome = 0;
            bool validInput = false;
            Console.WriteLine("Please enter your monthly income (in dollars).");
            while (!validInput)
            {
                validInput = true;
                try
                {
                    enteredMonthlyIncome = double.Parse(Console.ReadLine());
                    Console.WriteLine($"Monthly income entered: {enteredMonthlyIncome:c}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("The enterd monthly income is not valid. Please enter an amount in dollars. " + ex.Message);
                    validInput = false;
                }
            }
            monthlyIncome = enteredMonthlyIncome;
            Console.WriteLine(" ");
        }

        public static void HOAFeesAssigner(out double homeOwnerAssociationFees)
        {
            double enteredHOAFees = 0;
            bool isValidInput = false;
            Console.WriteLine("Enter monthly HOA fees for the area, in dollars. (if none, enter 0)");
            while (!isValidInput)
            {
                isValidInput = true;
                try
                {
                    enteredHOAFees = double.Parse(Console.ReadLine());
                    Console.WriteLine($"You entered {enteredHOAFees:c} as HOA fees.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Value of HOA fees was invalid." + ex.Message);
                    isValidInput = false;
                }
            }
            Console.WriteLine(" ");
            homeOwnerAssociationFees = enteredHOAFees;
        }

        public static void HomeEquityAssigner(double marketValue, double purchasePrice, double downPayment, out double homeEquity)
        {
            homeEquity = (((marketValue - purchasePrice) + downPayment) / purchasePrice) * 100;
            homeEquity = Math.Round(homeEquity, 2);
            Console.WriteLine($"Your starting equity will be {homeEquity}% ({(downPayment + (marketValue - purchasePrice)):c}) at the inception of the loan.");
        }
    }
}