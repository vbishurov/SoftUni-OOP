namespace Infestation.Models.Supplements.Catalists
{
    class AggressionCatalyst : Catalyst
    {
        private const int CatalystPowerEffect = 0;
        private const int CatalystHealthEffect = 0;
        private const int CatalystAggresionEffect = 3;

        public AggressionCatalyst()
            : base(AggressionCatalyst.CatalystPowerEffect, AggressionCatalyst.CatalystHealthEffect, AggressionCatalyst.CatalystAggresionEffect)
        {
        }
    }
}
