namespace MultimediaShop.Models.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Movie : Item
    {
        private double length;

        public Movie(string id, string title, decimal price, double length, List<string> genres)
            : base(id, title, price, genres)
        {
            this.Length = length;
        }

        public Movie(string id, string title, decimal price, double length, string genre)
            : this(id, title, price, length, new List<string>() { genre })
        {
        }

        private double Length
        {
            get
            {
                return this.length;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException("Length", "Length cannot be negative.");
                }

                this.length = value;
            }
        }

        public override string ToString()
        {
            var b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.Append("Length: " + this.Length);
            return b.ToString();
        }
    }
}