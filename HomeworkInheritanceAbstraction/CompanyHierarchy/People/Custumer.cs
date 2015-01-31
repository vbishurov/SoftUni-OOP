namespace CompanyHierarchy.People
{
    using System;
    using System.Text;
    using Interfaces;

    internal class Custumer : Person, ICustumer
    {
        private decimal netPurchaseAmount;

        public Custumer(string firstName, string lastName, string id, decimal netPurchaseAmount)
            : base(firstName, lastName, id)
        {
            this.NetPurchaseAmount = netPurchaseAmount;
        }

        public decimal NetPurchaseAmount
        {
            get
            {
                return this.netPurchaseAmount;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Net purchase amount cannot be negative.");
                }

                this.netPurchaseAmount = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.Append("Net purchase amount: " + this.NetPurchaseAmount);
            return b.ToString();
        }
    }
}
