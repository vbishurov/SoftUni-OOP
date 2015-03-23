namespace Estates.Data.Estates
{
    using System;
    using Interfaces;

    public abstract class Estate : IEstate
    {
        private double area;
        private string name;
        private string location;

        public EstateType Type { get; set; }

        public bool IsFurnished { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "Estate name cannot be empty.");
                }

                this.name = value;
            }
        }

        public double Area
        {
            get
            {
                return this.area;
            }

            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentOutOfRangeException("Area", "Area must be in range [0...10000]");
                }

                this.area = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Location", "Location cannot be empty.");
                }

                this.location = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "{0}: Name = {1}, Area = {2}, Location = {3}, Furnitured = {4}",
                this.GetType().Name,
                this.Name,
                this.Area, 
                this.Location,
                this.IsFurnished ? "Yes" : "No");
        }
    }
}
