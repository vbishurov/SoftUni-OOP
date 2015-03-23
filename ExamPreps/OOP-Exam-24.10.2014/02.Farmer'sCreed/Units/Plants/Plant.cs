namespace FarmersCreed.Units.Plants
{
    using System;
    using System.Text;

    public abstract class Plant : FarmUnit
    {
        protected Plant(string id, int health, int productionQuantity, int growTime)
            : base(id, health, productionQuantity)
        {
            this.GrowTime = growTime;
        }

        public bool HasGrown
        {
            get
            {
                return this.GrowTime <= 0;
            }
        }

        private int GrowTime { get; set; }

        public virtual void Water()
        {
            this.Health += 2;
        }

        public virtual void Wither()
        {
            this.Health--;
        }

        public virtual void Grow()
        {
            if (!this.HasGrown)
            {
                this.GrowTime--;
            }
        }

        public override string ToString()
        {
            StringBuilder plantInformation = new StringBuilder();

            if (this.IsAlive)
            {
                plantInformation.AppendFormat(", Grown: {0}",
                    this.HasGrown ? "Yes" : "No");

            }

            return base.ToString() + plantInformation;
        }
    }
}
