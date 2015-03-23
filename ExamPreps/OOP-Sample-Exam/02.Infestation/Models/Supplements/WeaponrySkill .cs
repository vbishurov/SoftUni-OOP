namespace Infestation.Models.Supplements
{
    class WeaponrySkill : Supplement
    {
        private const int WeaponryPowerEffect = 0;
        private const int WeaponryHealthEffect = 0;
        private const int WeaponryAggresionEffect = 0;

        public WeaponrySkill()
            : base(WeaponrySkill.WeaponryPowerEffect, WeaponrySkill.WeaponryHealthEffect, WeaponrySkill.WeaponryAggresionEffect)
        {
        }
    }
}
