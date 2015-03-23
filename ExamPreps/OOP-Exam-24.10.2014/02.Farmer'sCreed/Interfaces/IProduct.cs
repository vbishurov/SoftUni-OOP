namespace FarmersCreed.Interfaces
{
    using Units.Products;

    public interface IProduct
    {
        ProductType ProductType { get; set; }

        int Quantity { get; set; }
    }
}
