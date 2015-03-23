namespace FarmersCreed.Units
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Animals;
    using Interfaces;
    using Plants;
    using Products;

    public class Farm : GameObject, IFarm
    {
        public Farm(string id)
            : base(id)
        {
            this.Plants = new List<Plant>();
            this.Animals = new List<Animal>();
            this.Products = new List<Product>();
        }

        public List<Plant> Plants { get; private set; }

        public List<Animal> Animals { get; private set; }

        public List<Product> Products { get; private set; }

        public void AddProduct(Product product)
        {
            if (this.Products.Any(p => p.Id == product.Id))
            {
                this.Products.Find(p => p.Id == product.Id).Quantity += product.Quantity;
            }
            else
            {
                this.Products.Add(product);
            }
        }

        public virtual void Exploit(IProductProduceable productProducer)
        {
            var product = productProducer.GetProduct();
            this.AddProduct(product);
        }

        public void Feed(Animal animal, IEdible edibleProduct, int productQuantity)
        {
            //edibleProduct.Quantity -= productQuantity;
            animal.Eat(edibleProduct, productQuantity);
        }

        public void Water(Plant plant)
        {
            plant.Water();
        }

        public void UpdateFarmState()
        {
            foreach (Plant plant in this.Plants)
            {
                if (!plant.HasGrown)
                {
                    plant.Grow();
                }
                else
                {
                    plant.Wither();
                }
            }

            foreach (Animal animal in this.Animals)
            {
                animal.Starve();
            }
        }

        public override string ToString()
        {
            StringBuilder farmInfo = new StringBuilder();
            farmInfo.AppendLine();

            var sortedAnimals = this.Animals
                .Where(a => a.IsAlive)
                .OrderBy(a => a.Id);

            var sortedPlants = this.Plants
                .Where(p => p.IsAlive)
                .OrderBy(p => p.Health)
                .ThenBy(p => p.Id);

            var sortedProducts = this.Products
                .OrderBy(p => p.ProductType.ToString())
                .ThenByDescending(p => p.Quantity)
                .ThenBy(p => p.Id);

            foreach (var animal in sortedAnimals)
            {
                farmInfo.AppendLine(animal.ToString());
            }

            foreach (var plant in sortedPlants)
            {
                farmInfo.AppendLine(plant.ToString());
            }

            foreach (var product in sortedProducts)
            {
                farmInfo.AppendLine(product.ToString());
            }

            return base.ToString() + farmInfo;
        }
    }
}
