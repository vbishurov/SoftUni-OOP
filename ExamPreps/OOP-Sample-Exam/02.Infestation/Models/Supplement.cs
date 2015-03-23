﻿namespace Infestation.Models
{
    public abstract class Supplement : ISupplement
    {
        protected Supplement(int powerEffect, int healthEffect, int aggressionEffect)
        {
            this.PowerEffect = powerEffect;
            this.HealthEffect = healthEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public int PowerEffect { get; protected set; }

        public int HealthEffect { get; private set; }

        public int AggressionEffect { get; protected set; }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }

    }
}
