namespace Infestation.Models.Supplements.Catalists
{
    class HealthCatalyst : Catalyst
    {
        private const int CatalystPowerEffect = 0;
        private const int CatalystHealthEffect = 3;
        private const int CatalystAggresionEffect = 0;

        public HealthCatalyst()
            : base(HealthCatalyst.CatalystPowerEffect, HealthCatalyst.CatalystHealthEffect, HealthCatalyst.CatalystAggresionEffect)
        {
        }
    }
}
