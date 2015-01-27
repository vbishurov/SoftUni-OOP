namespace CompanyHierarchy
{
    using System.Collections.Generic;
    using System.Text;

    internal class Manager : Employee, IManager
    {
        public Manager(string firstName, string lastName, string id, decimal salary, string department, List<Employee> employees)
            : base(firstName, lastName, id, salary, department)
        {
            this.Employees = employees;
        }

        public List<Employee> Employees { get; set; }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.Append("Employees:");
            foreach (Employee employee in this.Employees)
            {
                b.AppendLine();
                b.Append(employee);
            }

            return b.ToString();
        }
    }
}
