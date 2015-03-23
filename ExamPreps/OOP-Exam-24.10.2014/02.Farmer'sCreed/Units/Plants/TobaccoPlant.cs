namespace FarmersCreed.Units.Plants
{
    using System;
    using Products;

    class TobaccoPlant : Plant
    {
        private const int TobaccoBasehealth = 12;
        private const int TobaccoGrowTime = 4;
        private const int TobaccoProductionQuantity = 10;
        private const ProductType TobaccoProductType = ProductType.Tobacco;

        public TobaccoPlant(string id)
            : base(id, TobaccoPlant.TobaccoBasehealth, TobaccoPlant.TobaccoProductionQuantity, TobaccoPlant.TobaccoGrowTime)
        {
        }

        public override void Grow()
        {
            base.Grow();
            base.Grow();
        }

        public override Product GetProduct()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException("You cannot exploit dead tobacco plants!");
            }

            if (!this.HasGrown)
            {
                throw new InvalidOperationException("Tobacco cannot be epxloited while growing!");
            }

            return new Product(this.Id + FarmUnit.ProductIdSuffix, TobaccoPlant.TobaccoProductType, this.ProductionQuantity);
        }
    }
}
