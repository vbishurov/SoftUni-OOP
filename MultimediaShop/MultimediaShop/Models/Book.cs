namespace MultimediaShop.Models
{
    using System;
    using System.Collections.Generic;

    internal class Book : Item
    {
        private string author;

        public Book(string id, string title, decimal price, string author, List<string> genres)
            : base(id, title, price, genres)
        {
            this.Author = author;
        }

        public Book(string id, string title, decimal price, string author, string genre)
            : this(id, title, price, author, new List<string>() { genre })
        {
        }

        public string Author
        {
            get
            {
                return this.author;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentNullException("Author", "Author must be at least 3 characters long.");
                }

                this.author = value;
            }
        }
    }
}
