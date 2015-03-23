namespace FarmersCreed.Interfaces
{
    using System.Collections.Generic;
    using Units.Animals;
    using Units.Plants;
    using Units.Products;

    public interface IFarm 
    {
        List<Plant> Plants { get; }

        List<Animal> Animals { get; }

        List<Product> Products { get; }

        void AddProduct(Product product);

        void Exploit(IProductProduceable productProducer);

        void Feed(Animal animal, IEdible edibleProduct, int productQuantity);

        void Water(Plant plant);

        void UpdateFarmState();
    }
}
