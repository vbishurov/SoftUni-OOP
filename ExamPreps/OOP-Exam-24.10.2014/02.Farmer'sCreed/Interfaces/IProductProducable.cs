namespace FarmersCreed.Interfaces
{
    using Units.Products;

    public interface IProductProduceable
    {
        int ProductionQuantity { get; set; }

        Product GetProduct();
    }
}
