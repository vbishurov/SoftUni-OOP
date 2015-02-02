namespace BankOfKurtovoKunare.Accounts
{
    using System;
    using Interfaces;

    public abstract class Account : IAccount, IDeposit
    {
        private ICustumer custumer;
        private decimal balance;
        private double interestRate;

        protected Account(ICustumer custumer, decimal balance, double interestRate)
        {
            this.Custumer = custumer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public ICustumer Custumer
        {
            get
            {
                return this.custumer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Custumer", "Custumer cannot be empty.");
                }

                this.custumer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance", "Balance cannot be negative.");
                }

                this.balance = value;
            }
        }

        public double InterestRate
        {
            get
            {
                return this.interestRate;
            }

            private set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Interst rate", "Interest rate must be in range [0...10].");
                }

                this.interestRate = value;
            }
        }

        public abstract decimal CalculateInterest(int months);

        public abstract void DepositMoney(decimal amount);
    }
}
