namespace Infestation.Models.Units.Biological
{
    class Parasite : InfestorUnit
    {
        private const int BasePower = 1;
        private const int BaseHealth = 1;
        private const int BaseAggresion = 1;
        private const UnitClassification UnitClass = UnitClassification.Biological;

        public Parasite(string id)
            : base(id, Parasite.UnitClass, Parasite.BaseHealth, Parasite.BasePower, Parasite.BaseAggresion)
        {
        }
    }
}
