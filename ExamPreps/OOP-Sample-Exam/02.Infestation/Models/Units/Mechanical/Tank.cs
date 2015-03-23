namespace Infestation.Models.Units.Mechanical
{
    class Tank : Unit
    {
        private const int BasePower = 25;
        private const int BaseHealth = 20;
        private const int BaseAggresion = 25;
        private const UnitClassification UnitClass = UnitClassification.Mechanical;

        public Tank(string id)
            : base(id, Tank.UnitClass, Tank.BaseHealth, Tank.BasePower, Tank.BaseAggresion)
        {
        }
    }
}
