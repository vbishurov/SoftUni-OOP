namespace BankOfKurtovoKunare.Accounts
{
    using System;
    using Interfaces;

    public class Deposit : Account, IWithdraw
    {
        public Deposit(ICustumer custumer, decimal balance, double interestRate)
            : base(custumer, balance, interestRate)
        {
        }

        public override void DepositMoney(decimal amount)
        {
            if (amount < 10)
            {
                throw new ArgumentOutOfRangeException("Amount", "Cannot deposit less than 10лв.");
            }

            this.Balance += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentOutOfRangeException("Amount", "You have insufficient funds");
            }

            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return this.Balance;
            }

            return this.Balance * (decimal)(1 + (this.InterestRate * months));
        }
    }
}
