namespace RestaurantManager.Interfaces
{
    using RestaurantManager.Models;

    public interface IRecipe
    {
        string Name { get; }

        decimal Price { get; }

        int Calories { get; }

        int QuantityPerServing { get; }

        MetricUnit UnitOfMeasure { get; }

        int TimeToPrepare { get; }
    }
}
