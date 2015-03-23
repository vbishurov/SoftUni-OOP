namespace FarmersCreed.Units.Animals
{
    using System;
    using Interfaces;
    using Products;
    using Products.Edibles;

    class Cow : Animal
    {
        private const int CowBasehealth = 15;
        private const int CowProductionQuantity = 6;
        private const ProductType CowProductType = ProductType.Milk;
        private const FoodType CowFoodType = FoodType.Organic;
        private const int CowProductHealthEffect = 4;
        private const int CowHealthLoss = 2;

        public Cow(string id)
            : base(id, Cow.CowBasehealth, Cow.CowProductionQuantity)
        {
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("You cannot exploit dead cows!");
            }

            this.Health -= Cow.CowHealthLoss;

            return new Food(this.Id + FarmUnit.ProductIdSuffix, Cow.CowProductType, Cow.CowFoodType, Cow.CowProductionQuantity, Cow.CowProductHealthEffect);
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.FoodType == FoodType.Organic)
            {
                this.Health += food.HealthEffect * quantity;
            }

            if (food.FoodType == FoodType.Meat)
            {
                this.Health -= food.HealthEffect * quantity;
            }

            base.Eat(food, quantity);
        }
    }
}
