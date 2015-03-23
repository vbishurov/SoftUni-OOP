namespace Estates.Data.Offers
{
    using System;
    using Interfaces;

    class Sale : Offer, ISaleOffer
    {
        private decimal price;

        public Sale()
        {
            this.Type = OfferType.Sale;
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price", "Price cannot be negative.");
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Price = {0}", this.Price);
        }
    }
}
