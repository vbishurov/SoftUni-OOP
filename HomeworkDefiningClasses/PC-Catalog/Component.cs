using System;
using System.Text;

namespace PCCatalog
{
    class Component
    {
        private string name;
        private string details;
        private decimal price;

        public Component(string name, decimal price, string details = null)
        {
            this.Name = name;
            this.Price = price;
            this.Details = details;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Component name cannot be empty.");
                }
                this.name = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (value != null)
                {
                    if (value.Trim() == "")
                    {
                        throw new ArgumentNullException("Details cannot be empty.");
                    }
                    if (value.Length > 100)
                    {
                        throw new ArgumentOutOfRangeException("Details cannot be more than 100 characters long.");
                    }
                }

                this.details = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b= new StringBuilder();
            b.AppendFormat("{0}: Price: {1:C}", this.Name.ToLower(), this.Price);

            if (this.Details != null)
            {
                b.AppendFormat(", Details: {0}", this.Details);
            }

            return b.ToString();
        }
    }
}
