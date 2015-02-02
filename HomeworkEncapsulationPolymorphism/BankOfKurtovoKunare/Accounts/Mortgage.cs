namespace BankOfKurtovoKunare.Accounts
{
    using System;
    using Custumers;
    using Interfaces;

    public class Mortgage : Account
    {
        public Mortgage(ICustumer custumer, decimal balance, double interestRate)
            : base(custumer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Custumer is Individual)
            {
                return months <= 6 ? this.Balance : this.Balance * (decimal)(1 + (this.InterestRate * (months - 6)));
            }

            decimal lessThan12MonthsInterest = (decimal)(0.5 + (this.InterestRate * months));
            decimal first12MonthInterest = (decimal)(0.5 + (this.InterestRate * 12));
            decimal after12MonthInterest = (decimal)(1 + (this.InterestRate * (months - 12)));

            return months <= 12 ? this.Balance * lessThan12MonthsInterest : this.Balance * (first12MonthInterest + after12MonthInterest);
        }

        public override void DepositMoney(decimal amount)
        {
            if (amount < 10)
            {
                throw new ArgumentOutOfRangeException("Amount", "Cannot deposit less than 10лв.");
            }

            this.Balance += amount;
        }
    }
}
