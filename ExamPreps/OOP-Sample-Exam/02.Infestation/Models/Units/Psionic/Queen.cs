namespace Infestation.Models.Units.Psionic
{
    class Queen : InfestorUnit
    {
        private const int BasePower = 1;
        private const int BaseHealth = 30;
        private const int BaseAggresion = 1;
        private const UnitClassification UnitClass = UnitClassification.Psionic;

        public Queen(string id)
            : base(id, Queen.UnitClass, Queen.BaseHealth, Queen.BasePower, Queen.BaseAggresion)
        {
        }
    }
}
