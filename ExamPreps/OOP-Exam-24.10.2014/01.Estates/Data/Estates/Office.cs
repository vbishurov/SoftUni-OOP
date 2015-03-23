namespace Estates.Data.Estates
{
    using Interfaces;

    class Office : Building, IOffice
    {
        public Office()
        {
            this.Type = EstateType.Office;
        }
    }
}
