namespace MultimediaShop.Interfaces
{
    using System;
    using Models;

    internal interface IRent
    {
        Item Item { get; }

        RentState RentState { get; }

        DateTime RentDate { get; }

        DateTime Deadline { get; }

        DateTime ReturnDate { get; }

        decimal CalculateRentFine();
    }
}
