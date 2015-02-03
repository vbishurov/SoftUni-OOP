namespace MultimediaShop.Models
{
    using System;
    using System.Text;
    using Interfaces;
    using Items;

    internal class Sale : ISale
    {
        private IItem item;

        public Sale(IItem item, DateTime saleDate)
        {
            this.Item = item;
            this.SaleDate = saleDate;
        }

        public Sale(Item item)
            : this(item, DateTime.Now)
        {
        }

        public IItem Item
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

        public override string ToString()
        {
            var b = new StringBuilder();
            b.AppendLine("Sale: " + this.SaleDate);
            b.Append(this.Item.ToString());
            return b.ToString();
        }
    }
}