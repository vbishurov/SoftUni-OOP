namespace Laptops
{
    using System;
    using System.Text;

    internal class Battery
    {
        private string type;
        private float life;

        public Battery(string type)
        {
            this.Type = type;
        }

        public Battery(string type, float life)
            : this(type)
        {
            this.Life = life;
        }

        public string Type
        {
            get
            {
                return this.type;
            }

            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Battery type cannot be empty.");
                }

                this.type = value;
            }
        }

        public float Life
        {
            get
            {
                return this.life;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery life cannot be negative.");
                }

                this.life = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            if (this.Type != null)
            {
                b.AppendFormat("Battery: {0}", this.Type);
            }

            if (this.Life > 0)
            {
                b.AppendLine();
                b.AppendFormat("Battery Life: {0} hours", this.Life);
            }

            return b.ToString();
        }
    }
}
