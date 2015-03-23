namespace Estates.Data.Estates
{
    using System;
    using Interfaces;

    public class House : Estate, IHouse
    {
        private int floors;

        public House()
        {
            this.Type = EstateType.House;
        }

        public int Floors
        {
            get
            {
                return this.floors;
            }

            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Floors", "Floors must be in range [0...10].");
                }

                this.floors = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Floors: {0}", this.Floors);
        }
    }
}
