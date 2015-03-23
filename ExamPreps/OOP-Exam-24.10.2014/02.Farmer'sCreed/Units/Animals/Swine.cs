namespace FarmersCreed.Units.Animals
{
    using System;
    using Interfaces;
    using Products;
    using Products.Edibles;

    class Swine : Animal
    {
        private const int SwineBasehealth = 20;
        private const int SwineProductionQuantity = 1;
        private const ProductType SwineProductType = ProductType.PorkMeat;
        private const FoodType SwineFoodType = FoodType.Meat;
        private const int SwineProductHealthEffect = 5;

        public Swine(string id)
            : base(id, Swine.SwineBasehealth, Swine.SwineProductionQuantity)
        {
        }

        public override void Eat(IEdible food, int quantity)
        {
            if (food.FoodType == FoodType.Organic || food.FoodType == FoodType.Meat)
            {
                this.Health += 2 * food.HealthEffect * quantity;
            }

            base.Eat(food, quantity);
        }

        public override void Starve()
        {
            base.Starve();
            base.Starve();
            base.Starve();
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("You cannot exploit dead swines!");
            }

            this.Die();

            return new Food(
                this.Id + FarmUnit.ProductIdSuffix, Swine.SwineProductType, Swine.SwineFoodType, Swine.SwineProductionQuantity, Swine.SwineProductHealthEffect);
        }
    }
}
