namespace MultimediaShop.Interfaces
{
    using System.Collections.Generic;

    internal interface IItem
    {
        string Id { get; }

        string Title { get; }

        decimal Price { get; }

        List<string> Genres { get; }
    }
}
