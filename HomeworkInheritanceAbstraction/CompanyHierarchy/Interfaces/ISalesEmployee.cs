namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface ISalesEmployee : IEmployee
    {
        List<Sale> Sales { get; set; }
    }
}