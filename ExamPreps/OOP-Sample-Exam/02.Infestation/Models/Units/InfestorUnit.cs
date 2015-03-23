namespace Infestation.Models.Units
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class InfestorUnit : Unit
    {
        protected InfestorUnit(string id, UnitClassification unitType, int health, int power, int aggression)
            : base(id, unitType, health, power, aggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            var candidateUnits = units.Where((unit) => unit.Id != this.Id && this.UnitClassification == InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification));

            var optimalInfestableUnit = candidateUnits.OrderBy(unit => unit.Health).FirstOrDefault();

            if (optimalInfestableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalInfestableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var optimalAttackableUnit = attackableUnits.OrderBy(unit => unit.Health).FirstOrDefault();

            return optimalAttackableUnit;
        }
    }
}
