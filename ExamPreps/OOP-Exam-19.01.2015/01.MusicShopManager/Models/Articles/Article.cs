namespace MusicShopManager.Models.Articles
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Article : IArticle
    {
        private const string RequiredArgumentExceptionMessage = "The {0} is required.";
        private const string InvalidOperationExceptionMessage = "The {0} must be positive.";

        private string make;
        private string model;
        private decimal price;

        protected Article(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
        }

        public string Make
        {
            get
            {
                return this.make;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(Article.RequiredArgumentExceptionMessage, "Make"));
                }

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(Article.RequiredArgumentExceptionMessage, "Model"));
                }

                this.model = value;
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
                if (value <= 0)
                {
                    throw new InvalidOperationException(string.Format(Article.InvalidOperationExceptionMessage, "Price"));
                }

                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder article = new StringBuilder();

            article.AppendFormat("= {0} {1} =", this.Make, this.Model).AppendLine();
            article.AppendFormat("Price: ${0:F2}", this.Price).AppendLine();

            return article.ToString();
        }
    }
}
