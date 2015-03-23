namespace MusicShopManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public class MusicShop : IMusicShop
    {
        private const string RequiredArgumentExceptionMessage = "The {0} is required.";

        private string name;

        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(MusicShop.RequiredArgumentExceptionMessage, "Name"));
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles { get; private set; }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder shop = new StringBuilder();
            shop.AppendFormat("===== {0} =====", this.Name).AppendLine();
            if (!this.Articles.Any())
            {
                shop.AppendLine("The shop is empty. Come back soon.");
                return shop.ToString();
            }

            var microphones = this.Articles.Where(a => a is IMicrophone).OrderBy(a => a.Make + " " + a.Model).ToList();

            this.AppendArticles(microphones, shop, "Microphones");

            var drums = this.Articles.Where(a => a is IDrums).OrderBy(a => a.Make + " " + a.Model).ToList();
            this.AppendArticles(drums, shop, "Drums");

            var electricGuitars = this.Articles.Where(a => a is IElectricGuitar).OrderBy(a => a.Make + " " + a.Model).ToList();
            this.AppendArticles(electricGuitars, shop, "Electric guitars");

            var acousticGuitars = this.Articles.Where(a => a is IAcousticGuitar).OrderBy(a => a.Make + " " + a.Model).ToList();
            this.AppendArticles(acousticGuitars, shop, "Acoustic guitars");

            var bassGuitars = this.Articles.Where(a => a is IBassGuitar).OrderBy(a => a.Make + " " + a.Model).ToList();
            this.AppendArticles(bassGuitars, shop, "Bass guitars");

            return shop.ToString();
        }

        private void AppendArticles(List<IArticle> collection, StringBuilder builder, string type)
        {
            if (!collection.Any())
            {
                return;
            }

            builder.AppendFormat("----- {0} -----", type).AppendLine();
            collection.ForEach(m => builder.Append(m.ToString()));
        }
    }
}
