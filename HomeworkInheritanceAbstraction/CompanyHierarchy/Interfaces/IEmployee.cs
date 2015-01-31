namespace CompanyHierarchy.Interfaces
{
    public interface IEmployee : IPerson
    {
        string Department { get; set; }

        decimal Salary { get; set; }
    }
}