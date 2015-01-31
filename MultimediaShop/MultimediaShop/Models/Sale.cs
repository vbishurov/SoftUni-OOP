namespace MultimediaShop.Models
{
    using System;
    using Interfaces;

    internal class Sale : ISale
    {
        private Item item;

        public Sale(Item item, DateTime saleDate)
        {
            this.Item = item;
            this.SaleDate = saleDate;
        }

        public Sale(Item item)
            : this(item, DateTime.Now)
        {
        }

        public Item Item
        {
            get
            {
                return this.item;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Item", "Item cannot be null");
                }

                this.item = value;
            }
        }

        public DateTime SaleDate { get; private set; }
    }
}
