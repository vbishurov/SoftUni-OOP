namespace MultimediaShop.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Exceptions;
    using Interfaces;
    using Models.Enums;
    using Models.Items;

    internal class Engine
    {
        private static readonly Dictionary<IItem, int> ItemSupplies = new Dictionary<IItem, int>();

        public static IItem GetItemById(string id)
        {
            return Engine.ItemSupplies.FirstOrDefault(p => p.Key.Id == id).Key;
        }

        public void Run()
        {
            while (true)
            {
                var command = Console.ReadLine();
                var commandSplitted = command.Split(new [] { ' ' }, 4);
                switch (commandSplitted[0])
                {
                    case "supply": Engine.Supply(commandSplitted[1], commandSplitted[2], commandSplitted[3]);
                        break;
                    case "sell": Engine.Sell(commandSplitted[1], commandSplitted[2]);
                        break;
                    case "rent": Engine.Rent(commandSplitted[1], commandSplitted[2], commandSplitted[3]);
                        break;
                    case "return": Engine.Return(commandSplitted[1]);
                        break;
                    case "report":
                        Engine.Report(commandSplitted);
                        break;
                }
            }
        }

        private static void Report(string[] commandSplitted)
        {
            switch (commandSplitted[1])
            {
                case "rents":
                    Engine.ReportRents();
                    break;
                case "sales":
                    Engine.ReportTotalSaleAmount(commandSplitted[2]);
                    break;
            }
        }

        private static void ReportTotalSaleAmount(string startDate)
        {
            decimal sum = 0;
            var salesAfterDate = SaleManager.GetSalesAfter(DateTime.Parse(startDate));
            salesAfterDate.ForEach(p => sum += p.Item.Price);
            Console.WriteLine(sum.ToString(new CultureInfo("en-US")));
        }

        private static void ReportRents()
        {
            Console.WriteLine();
            RentManager.GetOverdueRents().ForEach(p => Console.WriteLine(p + Environment.NewLine));
        }

        private static void Supply(string type, string quantity, string parameters)
        {
            var keyValuePairs = Engine.ExtractKeyValuePairs(parameters);
            switch (type)
            {
                case "book": Engine.SupplyBooks(int.Parse(quantity), keyValuePairs);
                    break;
                case "game": Engine.SupplyGames(int.Parse(quantity), keyValuePairs);
                    break;
                case "movie":
                case "video": Engine.SupplyMovies(int.Parse(quantity), keyValuePairs);
                    break;
            }
        }

        private static void Sell(string id, string saleDate)
        {
            var key = Engine.ItemSupplies.Keys.FirstOrDefault(p => p.Id == id);
            if (Engine.ItemSupplies[key] < 1)
            {
                throw new InsufficientSuppliesException();
            }

            SaleManager.AddItem(id, saleDate);
            Engine.ItemSupplies[key]--;
        }

        private static void Rent(string id, string rentDate, string deadline)
        {
            var key = Engine.GetItemById(id);
            if (Engine.ItemSupplies[key] < 1)
            {
                throw new InsufficientSuppliesException();
            }

            RentManager.AddRent(id, rentDate, deadline);
            Engine.ItemSupplies[key]--;
        }

        private static void Return(string id)
        {
            var key = Engine.GetItemById(id);
            Engine.ItemSupplies[key]++;
        }

        private static void SupplyMovies(int quantity, Dictionary<string, string> keyValuePairs)
        {
            var id = keyValuePairs["id"];
            var title = keyValuePairs["title"];
            var price = decimal.Parse(keyValuePairs["price"], NumberFormatInfo.InvariantInfo);
            var length = double.Parse(keyValuePairs["length"], NumberFormatInfo.InvariantInfo);
            var genre = keyValuePairs["genre"];
            Engine.ItemSupplies.Add(
                new Movie(id, title, price, length, genre), quantity);
        }

        private static void SupplyGames(int quantity, Dictionary<string, string> keyValuePairs)
        {
            var id = keyValuePairs["id"];
            var title = keyValuePairs["title"];
            var price = decimal.Parse(keyValuePairs["price"], NumberFormatInfo.InvariantInfo);
            var genre = keyValuePairs["genre"];
            var ageRestrictionString = keyValuePairs["ageRestriction"];
            var ageRestriction = AgeRestriction.Minor;
            switch (ageRestrictionString)
            {
                case "minor": ageRestriction = AgeRestriction.Minor;
                    break;
                case "teen": ageRestriction = AgeRestriction.Teen;
                    break;
                case "adult": ageRestriction = AgeRestriction.Adult;
                    break;
            }

            Engine.ItemSupplies.Add(
                new Game(id, title, price, genre, ageRestriction), quantity);
        }

        private static void SupplyBooks(int quantity, Dictionary<string, string> keyValuePairs)
        {
            var id = keyValuePairs["id"];
            var title = keyValuePairs["title"];
            var price = decimal.Parse(keyValuePairs["price"], NumberFormatInfo.InvariantInfo);
            var author = keyValuePairs["author"];
            var genre = keyValuePairs["genre"];
            Engine.ItemSupplies.Add(
                new Book(id, title, price, author, genre), quantity);
        }

        private static Dictionary<string, string> ExtractKeyValuePairs(string query)
        {
            var paramsString = query.Split('&');
            var pairs = paramsString.Select(pair => pair.Split('='));
            return pairs.ToDictionary(keyValuePair => keyValuePair[0], keyValuePair => keyValuePair[1]);
        }
    }
}