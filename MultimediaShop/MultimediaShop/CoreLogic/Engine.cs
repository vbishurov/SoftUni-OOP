﻿using System.Globalization;
using System.Linq;
using MultimediaShop.Models;

namespace MultimediaShop.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    internal class Engine
    {
        private static readonly Dictionary<IItem, int> itemSupplies = new Dictionary<IItem, int>();

        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                string[] commandSplitted = command.Split(new char[] { ' ' }, 4);
                switch (commandSplitted[0])
                {
                    case "supply": Supply(commandSplitted[1], commandSplitted[2], commandSplitted[3]);
                        break;
                    case "sell": Sell(commandSplitted[1], commandSplitted[2]);
                        break;
                    case "rent": Rent(commandSplitted[1], commandSplitted[2], commandSplitted[3]);
                        break;
                    case "return": Return(commandSplitted[1]);
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
                case "movie":
                case "video": SupplyMovies(int.Parse(quantity), keyValuePairs);
                    break;
            }
        }

        private void Sell(string id, string saleDate)
        {
            IItem key = Engine.itemSupplies.Keys.First(p => p.Id == id);
            if (Engine.itemSupplies[key] < 1)
            {
                throw new InsufficientSuppliesException();
            }

            SaleManager.AddItem(id, saleDate);
            Engine.itemSupplies[key]--;
            if (Engine.itemSupplies[key] == 0)
            {
                Engine.itemSupplies.Remove(key);
            }
        }

        private void Rent(string id, string rentDate, string deadline)
        {
            IItem key = Engine.itemSupplies.Keys.First(p => p.Id == id);
            if (Engine.itemSupplies[key] < 1)
            {
                throw new InsufficientSuppliesException();
            }

            RentManager.AddRent(id, rentDate, deadline);
            Engine.itemSupplies[key]--;
            if (Engine.itemSupplies[key] == 0)
            {
                Engine.itemSupplies.Remove(key);
            }
        }

        private void Return(string id)
        {
            IItem key = Engine.itemSupplies.Keys.First(p => p.Id == id);
            Engine.itemSupplies[key]++;
        }

        private void SupplyMovies(int quantity, Dictionary<string, string> keyValuePairs)
        {
            string id = keyValuePairs["id"];
            string title = keyValuePairs["title"];
            decimal price = decimal.Parse(keyValuePairs["price"], NumberFormatInfo.InvariantInfo);
            double length = double.Parse(keyValuePairs["length"], NumberFormatInfo.InvariantInfo);
            string genre = keyValuePairs["genre"];
            Engine.itemSupplies.Add(
                new Movie(id, title, price, length, genre), quantity);
        }

        private void SupplyGames(int quantity, Dictionary<string, string> keyValuePairs)
        {
            string id = keyValuePairs["id"];
            string title = keyValuePairs["title"];
            decimal price = decimal.Parse(keyValuePairs["price"], NumberFormatInfo.InvariantInfo);
            string genre = keyValuePairs["genre"];
            string ageRestrictionString = keyValuePairs["ageRestriction"];
            AgeRestriction ageRestriction = AgeRestriction.Minor;
            switch (ageRestrictionString)
            {
                case "minor": ageRestriction = AgeRestriction.Minor;
                    break;
                case "teen": ageRestriction = AgeRestriction.Teen;
                    break;
                case "adult": ageRestriction = AgeRestriction.Adult;
                    break;
            }
            Engine.itemSupplies.Add(
                new Game(id, title, price, genre, ageRestriction), quantity);
        }

        private void SupplyBooks(int quantity, Dictionary<string, string> keyValuePairs)
        {
            string id = keyValuePairs["id"];
            string title = keyValuePairs["title"];
            decimal price = decimal.Parse(keyValuePairs["price"], NumberFormatInfo.InvariantInfo);
            string author = keyValuePairs["author"];
            string genre = keyValuePairs["genre"];
            Engine.itemSupplies.Add(
                new Book(id, title, price, author, genre), quantity);
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

        public static IItem GetItemById(string id)
        {
            return Engine.itemSupplies.FirstOrDefault(p => p.Key.Id == id).Key;
        }
    }
}
