using System.Linq;
using MultimediaShop.Models;

namespace MultimediaShop.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    internal class Engine
    {
        private Dictionary<IItem, int> itemSupplies = new Dictionary<IItem, int>();

        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                string[] commandSpitted = command.Split(' ');
                switch (commandSpitted[0])
                {
                    case "supply": Supply(commandSpitted[1], commandSpitted[2], commandSpitted[3]);
                        break;
                    case "sell": Sell(commandSpitted[1]);
                        break;
                    case "rent": Rent(commandSpitted[1], commandSpitted[2], commandSpitted[3]);
                        break;
                    case "return": Return(commandSpitted[1]);
                        break;
                }
            }
        }

        private void Supply(string type, string quantity, string parameters)
        {
            Dictionary<string, string> keyValuePairs = ExtractKeyValuePairs(parameters);
            switch (type)
            {
                case "book": SupplyBooks(int.Parse(quantity), keyValuePairs);
                    break;
                case "game": SupplyGames(int.Parse(quantity), keyValuePairs);
                    break;
                case "movie": SupplyMovies(int.Parse(quantity), keyValuePairs);
                    break;
            }
        }

        private void Sell(string id)
        {
            IItem key = this.itemSupplies.Keys.First(p => p.Id == id);
            this.itemSupplies[key]--;
            if (this.itemSupplies[key] == 0)
            {
                this.itemSupplies.Remove(key);
            }
        }

        private void Rent(string id, string rentDate, string deadline)
        {
            IItem key = this.itemSupplies.Keys.First(p => p.Id == id);
            this.itemSupplies[key]--;
            if (this.itemSupplies[key] == 0)
            {
                this.itemSupplies.Remove(key);
            }
        }

        private void Return(string id)
        {
            IItem key = this.itemSupplies.Keys.First(p => p.Id == id);
            this.itemSupplies[key]++;
        }

        private void SupplyMovies(int quantity, Dictionary<string, string> keyValuePairs)
        {
            string id;
            string title;
            string price;
            string length;
            string genre;
            keyValuePairs.TryGetValue("id", out id);
            keyValuePairs.TryGetValue("title", out title);
            keyValuePairs.TryGetValue("price", out price);
            keyValuePairs.TryGetValue("length", out length);
            keyValuePairs.TryGetValue("genre", out genre);
            this.itemSupplies.Add(
                new Movie(id, title, decimal.Parse(price), double.Parse(length), genre),
                quantity);
        }

        private void SupplyGames(int quantity, Dictionary<string, string> keyValuePairs)
        {
            string id;
            string title;
            string price;
            string genre;
            keyValuePairs.TryGetValue("id", out id);
            keyValuePairs.TryGetValue("title", out title);
            keyValuePairs.TryGetValue("price", out price);
            keyValuePairs.TryGetValue("genre", out genre);
            this.itemSupplies.Add(
                new Game(id, title, decimal.Parse(price), genre),
                quantity);
        }

        private void SupplyBooks(int quantity, Dictionary<string, string> keyValuePairs)
        {
            string id;
            string title;
            string price;
            string author;
            string genre;
            keyValuePairs.TryGetValue("id", out id);
            keyValuePairs.TryGetValue("title", out title);
            keyValuePairs.TryGetValue("price", out price);
            keyValuePairs.TryGetValue("author", out author);
            keyValuePairs.TryGetValue("genre", out genre);
            this.itemSupplies.Add(
                new Book(id, title, decimal.Parse(price), author, genre),
                quantity);
        }

        private Dictionary<string, string> ExtractKeyValuePairs(string query)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            string[] paramsString = query.Split('&');
            foreach (string pair in paramsString)
            {
                string[] keyValuePair = pair.Split('=');
                keyValuePairs.Add(keyValuePair[0], keyValuePair[1]);
            }

            return keyValuePairs;
        }
    }
}
