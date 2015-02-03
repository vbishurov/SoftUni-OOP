namespace MultimediaShop.Interfaces
{
    using Models.Enums;

    internal interface IRent
    {
        IItem Item { get; }

        decimal RentFine { get; }

        RentState RentState { get; }
    }
}