namespace MultimediaShop.Models
{
    using System;
    using Interfaces;

    internal class Rent : IRent
    {
        private Item item;

        public Rent(Item item, DateTime rentDate, DateTime deadline)
        {
            this.Item = item;
            this.RentDate = rentDate;
            this.Deadline = deadline;
        }

        public Rent(Item item, DateTime rentDate)
            : this(item, rentDate, rentDate.AddDays(30))
        {
        }

        public Rent(Item item)
            : this(item, DateTime.Now, DateTime.Now.AddDays(30))
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

        public decimal RentFine
        {
            get
            {
                decimal finePerDay = 0.01m * this.Item.Price;
                TimeSpan difference = this.ReturnDate - this.Deadline;
                return difference.Days * finePerDay;
            }
        }

        public RentState RentState
        {
            get
            {
                if (this.ReturnDate > DateTime.MinValue)
                {
                    return RentState.Returned;
                }

                return this.Deadline < DateTime.Now ? RentState.Overdue : RentState.Pending;
            }
        }

        public DateTime RentDate { get; private set; }

        public DateTime Deadline { get; private set; }

        public DateTime ReturnDate { get; private set; }

        public void ReturnItem()
        {
            this.ReturnDate = DateTime.Now;
        }

        public decimal CalculateRentFine()
        {
            if (this.RentState == RentState.Overdue)
            {
                decimal finePerDay = 0.01m * this.Item.Price;
                TimeSpan difference = this.ReturnDate - this.Deadline;
                return difference.Days * finePerDay;
            }
            else
            {
                return 0;
            }
        }
    }
}
