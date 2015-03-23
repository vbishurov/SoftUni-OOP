namespace Estates.Data.Offers
{
    using System;
    using Interfaces;

    class Rent : Offer, IRentOffer
    {
        private decimal pricePerMonth;

        public Rent()
        {
            this.Type = OfferType.Rent;
        }

        public decimal PricePerMonth
        {
            get
            {
                return this.pricePerMonth;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("PricePerMonth", "Price per month cannot be negative");
                }

                this.pricePerMonth = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Price = {0}", this.PricePerMonth);
        }
    }
}
