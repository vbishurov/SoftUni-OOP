namespace Infestation.Models.Supplements
{
    class Catalyst : Supplement
    {
        protected Catalyst(int powerEffect, int healthEffect, int aggressionEffect)
            : base(powerEffect, healthEffect, aggressionEffect)
        {
        }
    }
}
