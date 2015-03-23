namespace Estates.Data
{
    using System;
    using Engine;
    using Estates;
    using Interfaces;
    using Offers;

    public static class EstateFactory
    {
        public static IEstateEngine CreateEstateEngine()
        {
            return new ImprovedEngine();
        }

        public static IEstate CreateEstate(EstateType type)
        {
            switch (type)
            {
                case EstateType.Apartment:
                    return new Apartment();
                case EstateType.Office:
                    return new Office();
                case EstateType.House:
                    return new House();
                case EstateType.Garage:
                    return new Garage();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }

        public static IOffer CreateOffer(OfferType type)
        {
            switch (type)
            {
                case OfferType.Sale:
                    return new Sale();
                case OfferType.Rent:
                    return new Rent();
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}
