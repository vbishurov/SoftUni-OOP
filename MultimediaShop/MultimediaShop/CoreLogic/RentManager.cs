namespace MultimediaShop.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models;

    internal static class RentManager
    {
        private static readonly HashSet<IRent> ItemRents = new HashSet<IRent>();

        public static void AddRent(string id, string rentDate, string deadline)
        {
            ItemRents.Add(new Rent(Engine.GetItemById(id), DateTime.Parse(rentDate), DateTime.Parse(deadline)));
        }
    }
}
