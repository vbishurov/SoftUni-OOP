namespace BankOfKurtovoKunare.Accounts
{
    using System;
    using Custumers;
    using Interfaces;

    public class Loan : Account
    {
        public Loan(ICustumer custumer, decimal balance, double interestRate)
            : base(custumer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Custumer is Individual && months <= 3)
            {
                return months <= 3 ? this.Balance : this.Balance * (decimal)(1 + (this.InterestRate * (months - 3)));
            }

            return months <= 2 ? this.Balance : this.Balance * (decimal)(1 + (this.InterestRate * (months - 2)));
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