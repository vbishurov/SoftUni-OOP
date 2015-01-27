namespace CompanyHierarchy
{
    using System.Collections.Generic;

    internal interface IDeveloper
    {
        List<Project> Projects { get; set; }
    }
}