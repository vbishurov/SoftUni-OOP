namespace MultimediaShop.Models.Items
{
    using System.Collections.Generic;
    using System.Text;
    using Enums;

    internal class Game : Item
    {
        public Game(string id, string title, decimal price, List<string> genres, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : base(id, title, price, genres)
        {
            this.AgeRestriction = ageRestriction;
        }

        public Game(string id, string title, decimal price, string genre, AgeRestriction ageRestriction = AgeRestriction.Minor)
            : this(id, title, price, new List<string>() { genre }, ageRestriction)
        {
        }

        private AgeRestriction AgeRestriction { get; set; }

        public override string ToString()
        {
            var b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.Append("Age Restriction: " + this.AgeRestriction);
            return b.ToString();
        }
    }
}