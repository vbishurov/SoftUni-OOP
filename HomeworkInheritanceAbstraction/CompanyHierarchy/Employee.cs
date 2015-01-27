namespace CompanyHierarchy
{
    using System;
    using System.Linq;
    using System.Text;

    internal abstract class Employee : Person, IEmployee
    {
        private static readonly string[] Departments = { "production", "accounting", "sales", "marketing" };

        private decimal salary;
        private string department;

        protected Employee(string firstName, string lastName, string id, decimal salary, string department)
            : base(firstName, lastName, id)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public string Department
        {
            get
            {
                return this.department;
            }

            set
            {
                if (!Departments.Contains(value.ToLower()))
                {
                    throw new ArgumentException("Department must be one of Production, Accounting, Sales, Marketing.");
                }

                this.department = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative.");
                }

                this.salary = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.AppendLine("Salary: " + this.Salary);
            b.Append("Department: " + this.Department);
            return b.ToString();
        }
    }
}
