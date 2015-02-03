namespace MultimediaShop.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models;

    public static class SaleManager
    {
        private static readonly HashSet<ISale> ItemSales = new HashSet<ISale>();

        public static void AddItem(string id, string saleDate)
        {
            SaleManager.ItemSales.Add(new Sale(Engine.GetItemById(id), DateTime.Parse(saleDate)));
        }

        public static List<ISale> GetSalesAfter(DateTime startDate)
        {
            return SaleManager.ItemSales.Where(p => p.SaleDate >= startDate).ToList();
        }
    }
}