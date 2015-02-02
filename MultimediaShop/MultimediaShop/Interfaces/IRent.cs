namespace MultimediaShop.Interfaces
{
    using System;

    internal interface IRent
    {
        IItem Item { get; }

        RentState RentState { get; }

        DateTime RentDate { get; }

        DateTime Deadline { get; }

        DateTime ReturnDate { get; }

        decimal CalculateRentFine();
    }
}
