namespace Estates.Data
{
    using System.Linq;
    using Engine;
    using Interfaces;

    class ImprovedEngine : EstateEngine
    {
        public override string ExecuteCommand(string cmdName, string[] cmdArgs)
        {
            switch (cmdName)
            {
                case "find-rents-by-location":
                    return this.ExecuteFindRentsByLocationCommand(cmdArgs[0]);
                case "find-rents-by-price":
                    return this.ExecuteFindRentsByPriceCommand(cmdArgs[0], cmdArgs[1]);
                default:
                    return base.ExecuteCommand(cmdName, cmdArgs);
            }
        }

        private string ExecuteFindRentsByLocationCommand(string location)
        {
            var offers = this.Offers
                .Where(o => o.Estate.Location == location && o.Type == OfferType.Rent)
                .OrderBy(o => o.Estate.Name);
            return this.FormatQueryResults(offers);
        }
        private string ExecuteFindRentsByPriceCommand(string minPrice, string maxPrice)
        {
            var offers = this.Offers
                .Where(o => o.Type == OfferType.Rent)
                .Cast<IRentOffer>()
                .Where(o => o.PricePerMonth >= decimal.Parse(minPrice) && o.PricePerMonth <= decimal.Parse(maxPrice))
                .OrderBy(o => o.PricePerMonth)
                .ThenBy(o => o.Estate.Name);
            return this.FormatQueryResults(offers);
        }
    }
}
