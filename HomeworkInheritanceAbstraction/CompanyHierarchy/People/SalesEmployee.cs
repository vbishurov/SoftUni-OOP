namespace CompanyHierarchy.People
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using Models;

    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        public SalesEmployee(string firstName, string lastName, string id, decimal salary, string department, List<Sale> sales)
            : base(firstName, lastName, id, salary, department)
        {
            this.Sales = sales;
        }

        public List<Sale> Sales { get; set; }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.Append("Sales: ");
            foreach (Sale sale in this.Sales)
            {
                b.AppendLine();
                b.Append(sale);
            }

            return b.ToString();
        }
    }
}
