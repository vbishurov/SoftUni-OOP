namespace CompanyHierarchy.Interfaces
{
    using System.Collections.Generic;
    using global::CompanyHierarchy.People;

    internal interface IManager : IEmployee
    {
        List<Employee> Employees { get; set; }
    }
}