﻿namespace MultimediaShop.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    internal abstract class Item : IItem
    {
        private string id;
        private string title;
        private decimal price;

        protected Item(string id, string title, decimal price, List<string> genres)
            : this(id, title, price)
        {
            this.Genres = genres;
        }

        private Item(string id, string title, decimal price)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentNullException("ID", "Id cannot be less than 4 characters long.");
                }

                this.id = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title", "Title cannot be empty");
                }

                this.title = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price", "Price cannot be negative.");
                }

                this.price = value;
            }
        }

        public List<string> Genres { get; private set; }
    }
}
