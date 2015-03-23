namespace Infestation.Models.Units.Biological
{
    using System.Collections.Generic;
    using System.Linq;
    using Supplements;

    class Marine : Human
    {
        private const int BasePower = 25;
        private const int BaseHealth = 20;
        private const int BaseAggresion = 25;
        private const UnitClassification UnitClass = UnitClassification.Biological;

        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            return attackableUnits.Where(u => u.Power <= this.Aggression).OrderByDescending(u => u.Health).FirstOrDefault();
        }
    }
}
