namespace FarmersCreed.Interfaces
{
    using Units.Products.Edibles;

    public interface IEdible : IProduct 
    {
        FoodType FoodType { get; set; }

        int HealthEffect { get; set; }
    }
}
