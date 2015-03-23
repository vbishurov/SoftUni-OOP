namespace Estates.Data.Estates
{
    using Interfaces;

    public class Apartment : Building, IApartment
    {
        public Apartment()
        {
            this.Type = EstateType.Apartment;
        }
    }
}
