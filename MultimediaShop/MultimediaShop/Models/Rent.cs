namespace MultimediaShop.Models
{
    using System;
    using System.Text;
    using Enums;
    using Interfaces;

    internal class Rent : IRent
    {
        private IItem item;

        public Rent(IItem item, DateTime rentDate, DateTime deadline)
        {
            this.Item = item;
            this.RentDate = rentDate;
            this.Deadline = deadline;
        }

        public Rent(IItem item, DateTime rentDate)
            : this(item, rentDate, rentDate.AddDays(30))
        {
        }

        public Rent(IItem item)
            : this(item, DateTime.Now, DateTime.Now.AddDays(30))
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

        public decimal RentFine
        {
            get
            {
                var finePerDay = 0.01m * this.Item.Price;
                TimeSpan difference;
                switch (this.RentState)
                {
                    case RentState.Returned:
                        difference = this.ReturnDate - this.Deadline;
                        return difference.Days * finePerDay;
                    case RentState.Overdue:
                        difference = DateTime.Now - this.Deadline;
                        return difference.Days * finePerDay;
                    default:
                        return 0;
                }
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

        public DateTime ReturnDate { get; private set; }

        private DateTime RentDate { get; set; }

        private DateTime Deadline { get; set; }

        public void ReturnItem()
        {
            this.ReturnDate = DateTime.Now;
        }

        public override string ToString()
        {
            var b = new StringBuilder();
            b.AppendLine("Rent: " + this.RentState);
            b.Append(this.Item);
            if (this.RentFine <= 0)
            {
                return b.ToString();
            }

            b.AppendLine();
            b.Append("Rent Fine: " + this.RentFine);
            return b.ToString();
        }
    }
}