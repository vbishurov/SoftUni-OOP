namespace MultimediaShop.Models
{
    using System;
    using System.Collections.Generic;

    internal class Movie : Item
    {
        private double length;

        public Movie(string id, string title, decimal price, double length, List<string> genres)
            : base(id, title, price, genres)
        {
        }

        public Movie(string id, string title, decimal price, double length, string genre)
            : this(id, title, price, length, new List<string>() { genre })
        {
        }

        public double Length
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
    }
}
