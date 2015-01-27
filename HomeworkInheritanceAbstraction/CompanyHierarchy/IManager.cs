namespace CompanyHierarchy
{
    using System.Collections.Generic;

    internal interface IManager
    {
        List<Employee> Employees { get; set; }
    }
}