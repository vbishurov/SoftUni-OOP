namespace CompanyHierarchy.Interfaces
{
    internal interface ICustumer : IPerson
    {
        decimal NetPurchaseAmount { get; set; }
    }
}