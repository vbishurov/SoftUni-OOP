namespace CompanyHierarchy
{
    using System.Collections.Generic;

    internal interface ISalesEmployee
    {
        List<Sale> Sales { get; set; }
    }
}