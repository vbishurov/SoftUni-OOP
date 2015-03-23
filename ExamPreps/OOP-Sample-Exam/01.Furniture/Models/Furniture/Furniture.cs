namespace FurnitureManufacturer.Models.Furniture
{
    using System;
    using System.Linq;
    using Interfaces;

    public abstract class Furniture : IFurniture
    {
        private const string InvalidArgumentExceptionMessage = "{0} cannot be less than or equal to 0.";

        private string model;
        private decimal price;
        private decimal height;

        protected Furniture(string model, string material, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = material;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3)
                {
                    throw new ArgumentNullException("Model", "Model cannot be empty or less than 3 sumbols.");
                }

                this.model = value;
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
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Price", string.Format(Furniture.InvalidArgumentExceptionMessage, "Price"));
                }

                this.price = value;
            }
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Height", string.Format(Furniture.InvalidArgumentExceptionMessage, "Height"));
                }

                this.height = value;
            }
        }

        public string Material { get; private set; }

        public override string ToString()
        {
            return string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                this.GetType().Name,
                this.Model,
                this.Material.First().ToString().ToUpper() + this.Material.Substring(1),
                this.Price,
                this.Height);
        }
    }
}
