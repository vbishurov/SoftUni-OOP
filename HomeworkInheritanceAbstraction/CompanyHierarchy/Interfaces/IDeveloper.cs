namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;
    using Models;

    public interface IDeveloper : IEmployee
    {
        List<Project> Projects { get; }
    }
}