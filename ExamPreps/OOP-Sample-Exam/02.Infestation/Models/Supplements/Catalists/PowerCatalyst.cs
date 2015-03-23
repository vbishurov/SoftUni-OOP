namespace Infestation.Models.Supplements.Catalists
{
    class PowerCatalyst : Catalyst
    {
        private const int CatalystPowerEffect = 3;
        private const int CatalystHealthEffect = 0;
        private const int CatalystAggresionEffect = 0;

        public PowerCatalyst()
            : base(PowerCatalyst.CatalystPowerEffect, PowerCatalyst.CatalystHealthEffect, PowerCatalyst.CatalystAggresionEffect)
        {
        }
    }
}
