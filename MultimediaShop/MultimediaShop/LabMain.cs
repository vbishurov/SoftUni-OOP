﻿namespace MultimediaShop
{
    using System;
    using System.Collections.Generic;
    using CoreLogic;
    using Models;
    using Models.Enums;
    using Models.Items;

    internal static class LabMain
    {
        private static void Main()
        {
            Item sallingerBook = new Book("4adwlj4", "Catcher in the Rye", 20.00m, "J. D. Salinger", "fiction");
            Item threeManBook = new Book("84djesd", "Three Men in a Boat", 39.99m, "Jerome K. Jerome", new List<string> { "comedy" });
            Item acGame = new Game("9gkjdsa", "AC Revelations", 78.00m, "historical", AgeRestriction.Teen);
            Item bubbleSplashGame = new Game("r8743jf", "Bubble Splash", 7.80m, new List<string> { "child", "fun" });
            Item godfatherMovie = new Movie("483252j", "The Godfather", 99.00m, 178, "crime");
            Item dieHardMovie = new Movie("9853kfds", "Die Hard 4", 9.90m, 144, new List<string> { "action", "crime", "thriller" });

            var today = DateTime.Now;
            var fiveYearsAgo = today.AddYears(-5);
            var dieHardSale = new Sale(dieHardMovie, fiveYearsAgo);
            Console.WriteLine(dieHardSale.SaleDate); // 1/30/2015 2:31:55 PM (today)
            var acSale = new Sale(acGame);
            Console.WriteLine(acSale.SaleDate); // 1/30/2010 2:31:55 PM

            var afterOneWeek = today.AddDays(30);
            var bookRent = new Rent(sallingerBook, today, afterOneWeek);
            Console.WriteLine(bookRent.RentState); // Pending

            var lastMonth = today.AddDays(-34);
            var lastWeek = today.AddDays(-8);
            var movieRent = new Rent(godfatherMovie, lastMonth, lastWeek);
            Console.WriteLine(movieRent.RentState); // Overdue

            movieRent.ReturnItem();
            Console.WriteLine(movieRent.RentState); // Returned
            Console.WriteLine(movieRent.ReturnDate); // 1/30/2015 2:41:53 PM
            Console.WriteLine(movieRent.RentFine); // 7.9200

            Engine engine = new Engine();
            engine.Run();
        }
    }
}