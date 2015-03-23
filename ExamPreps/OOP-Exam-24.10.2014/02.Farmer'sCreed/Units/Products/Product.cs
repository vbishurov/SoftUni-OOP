namespace FarmersCreed.Units.Products
{
    using System;
    using Interfaces;

    public class Product : GameObject, IProduct
    {
        public Product(string id, ProductType productType, int quantity)
            : base(id)
        {
            this.Quantity = quantity;
            this.ProductType = productType;
        }

        public int Quantity { get; set; }

        public ProductType ProductType { get; set; }

        public override string ToString()
        {
            return base.ToString() + String.Format(", Quantity: {0}, Product Type: {1}",
                this.Quantity, this.ProductType);
        }
    }
}
