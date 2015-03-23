namespace FarmersCreed.Units.Plants
{
    using Products;
    using Products.Edibles;

    class CherryTree : FoodPlant
    {
        private const int CherryTreeBasehealth = 14;
        private const int CherryTreeGrowTime = 3;
        private const int CherryTreeProductionQuantity = 4;
        private const ProductType CherryTreeProductType = ProductType.Cherry;
        private const FoodType CherryTreeFoodType = FoodType.Organic;
        private const int CherryTreeProductHealthEffect = 2;

        public CherryTree(string id)
            : base(id, CherryTree.CherryTreeBasehealth, CherryTree.CherryTreeProductionQuantity, CherryTree.CherryTreeGrowTime)
        {
        }

        public override Product GetProduct()
        {
            return new Food(
                this.Id + FarmUnit.ProductIdSuffix, 
                CherryTree.CherryTreeProductType,
                CherryTree.CherryTreeFoodType,
                this.ProductionQuantity,
                CherryTree.CherryTreeProductHealthEffect);
        }
    }
}
