namespace MultimediaShop.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;
    using Models.Enums;

    internal static class RentManager
    {
        private static readonly HashSet<IRent> ItemRents = new HashSet<IRent>();

        public static void AddRent(string id, string rentDate, string deadline)
        {
            IRent rent = new Rent(Engine.GetItemById(id), DateTime.Parse(rentDate), DateTime.Parse(deadline));
            RentManager.ItemRents.Add(rent);
        }

        public static List<IRent> GetOverdueRents()
        {
            var overdueRents = RentManager.ItemRents.Where(rent => rent.RentState == RentState.Overdue);
            return overdueRents.OrderBy(p => p.RentFine).ThenBy(p => p.Item.Title).ToList();
        }
    }
}