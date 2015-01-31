namespace MultimediaShop.Interfaces
{
    using System;
    using Models;

    internal interface ISale
    {
        Item Item { get; }

        DateTime SaleDate { get; }
    }
}
