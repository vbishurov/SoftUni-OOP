namespace Infestation.Models.Supplements
{
    class Weapon : Supplement
    {
        private const int BaseWeaponPowerEffect = 0;
        private const int BaseWeaponHealthEffect = 0;
        private const int BaseWeaponAggressionEffect = 0;

        private const int MaxWeaponPowerEffect = 10;
        private const int MaxWeaponAggresionEffect = 3;

        public Weapon()
            : base(Weapon.BaseWeaponPowerEffect, Weapon.BaseWeaponHealthEffect, Weapon.BaseWeaponAggressionEffect)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (!(otherSupplement is WeaponrySkill))
            {
                return;
            }

            this.PowerEffect = Weapon.MaxWeaponPowerEffect;
            this.AggressionEffect = Weapon.MaxWeaponAggresionEffect;
        }
    }
}
