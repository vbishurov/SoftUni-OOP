namespace FarmersCreed.Units.Plants
{
    public abstract class FoodPlant : Plant
    {
        private const int FoodPlantHealthLoss = 2;

        protected FoodPlant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity, growTime)
        {
        }

        public override void Water()
        {
            this.Health++;
        }

        public override void Wither()
        {
            this.Health -= FoodPlant.FoodPlantHealthLoss;
        }
    }
}
