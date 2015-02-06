namespace InterestCalculator
{
    using System;
    using System.Runtime.InteropServices;

    public class InterestCalculator
    {
        private readonly Func<decimal, float, int, decimal> getSimpleInterest =
            (sum, interest, years) => sum * (decimal)(1 + (interest * years / 100));

        private readonly Func<decimal, float, int, decimal> getCompoundInterest =
            (sum, interest, years) => sum * (decimal)Math.Pow(1 + (interest / 12 / 100), years * 12);

        private decimal money;
        private float interest;
        private int years;
        private InterestType interestType;
        private Func<decimal, float, int, decimal> calcInterest;

        public InterestCalculator(decimal money, float interest, int years, InterestType interestType)
        {
            this.Money = money;
            this.Interest = interest;
            this.Years = years;
            this.InterestType = interestType;
        }

        public int Years
        {
            get
            {
                return this.years;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Years", "Years cannot be less than 1");
                }

                this.years = value;
            }
        }

        public float Interest
        {
            get
            {
                return this.interest;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest", "Interest rate cannot be negative");
                }

                this.interest = value;
            }
        }

        public decimal Money
        {
            get
            {
                return this.money;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Money", "Cannot have negative money");
                }

                this.money = value;
            }
        }

        public InterestType InterestType
        {
            get
            {
                return this.interestType;
            }

            private set
            {
                this.interestType = value;

                switch (value)
                {
                    case InterestType.simple:
                        this.calcInterest = this.getSimpleInterest;
                        break;
                    case InterestType.compound:
                        this.calcInterest = this.getCompoundInterest;
                        break;
                }
            }
        }

        public decimal CalcInterest
        {
            get
            {
                return this.calcInterest(this.Money, this.Interest, this.Years);
            }
        }
    }
}
