namespace CompanyHierarchy.People
{
    public abstract class RegularEmployee : Employee
    {
        protected RegularEmployee(string firstName, string lastName, string id, decimal salary, string department)
            : base(firstName, lastName, id, salary, department)
        {
        }
    }
}
