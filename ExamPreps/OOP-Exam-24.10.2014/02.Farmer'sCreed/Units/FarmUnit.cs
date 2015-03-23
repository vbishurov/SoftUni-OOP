namespace FarmersCreed.Units
{
    using System;
    using Interfaces;
    using Products;

    public abstract class FarmUnit : GameObject, IProductProduceable
    {
        protected const string ProductIdSuffix = "Product";

        private int productionQuantity;

        protected FarmUnit(string id, int health, int productionQuantity)
            : base(id)
        {
            this.Health = health;
            this.ProductionQuantity = productionQuantity;
        }

        public int Health { get; protected set; }

        public bool IsAlive
        {
            get
            {
                return this.Health > 0;
            }
        }

        public int ProductionQuantity
        {
            get
            {
                return this.productionQuantity;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("ProductionQuantity","Prodction quantity cannot be less than 1.");
                }

                this.productionQuantity = value;
            }
        }

        public abstract Product GetProduct();

        public override string ToString()
        {
            return base.ToString() +
                (this.IsAlive ? String.Format(", Health: {0}", this.Health) : ", DEAD");
        }

        protected void Die()
        {
            this.Health = 0;
        }
    }
}
