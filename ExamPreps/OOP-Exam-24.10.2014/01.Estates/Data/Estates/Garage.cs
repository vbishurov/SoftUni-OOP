namespace Estates.Data.Estates
{
    using System;
    using Interfaces;

    public class Garage : Estate, IGarage
    {
        private int width;
        private int height;

        public Garage()
        {
            this.Type = EstateType.Garage;
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("Width", "Width must be in range [0...500].");
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value < 0 || value > 500)
                {
                    throw new ArgumentOutOfRangeException("Height", "Height must be in range [0...500].");
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", Width: {0}, Height: {1}", this.Width, this.Height);
        }
    }
}
