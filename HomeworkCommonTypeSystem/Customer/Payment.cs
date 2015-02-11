namespace Customer
{
    using System;

    public class Payment
    {
        private string productName;
        private decimal price;

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Product name", "Product name cannot be empty");
                }

                this.productName = value;
            }
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
                    throw new ArgumentOutOfRangeException("Price", "Price cannot be negative");
                }

                this.price = value;
            }
        }
    }
}
