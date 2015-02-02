namespace MultimediaShop.Interfaces
{
    using System;
    using Models;

    public interface ISale
    {
        IItem Item { get; }

        DateTime SaleDate { get; }
    }
}
