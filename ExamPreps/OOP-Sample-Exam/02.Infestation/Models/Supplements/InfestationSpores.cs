namespace Infestation.Models.Supplements
{
    class InfestationSpores : Supplement
    {
        private const int SporesPowerEffect = -1;
        private const int SporesHealthEffect = 0;
        private const int SporesAggresionEffect = 20;

        private const int MultipleSporesPowerEffect = 0;
        private const int MultipleSporesAggressionEffect = 0;

        public InfestationSpores()
            : base(InfestationSpores.SporesPowerEffect, InfestationSpores.SporesHealthEffect, InfestationSpores.SporesAggresionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (!(otherSupplement is InfestationSpores))
            {
                return;
            }

            this.PowerEffect = InfestationSpores.MultipleSporesPowerEffect;
            this.AggressionEffect = InfestationSpores.MultipleSporesAggressionEffect;
        }
    }
}
