namespace MultimediaShop.CoreLogic
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Models;

    public static class SaleManager
    {
        private static readonly HashSet<ISale> itemSales = new HashSet<ISale>();

        public static void AddItem(string id, string saleDate)
        {
            SaleManager.itemSales.Add(new Sale(Engine.GetItemById(id), DateTime.Parse(saleDate)));
        }
    }
}
