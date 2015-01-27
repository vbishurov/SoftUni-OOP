namespace CompanyHierarchy
{
    using System.Collections.Generic;
    using System.Text;

    internal class Developer : RegularEmployee, IDeveloper
    {
        public Developer(string firstName, string lastName, string id, decimal salary, string department, List<Project> projects)
            : base(firstName, lastName, id, salary, department)
        {
            this.Projects = projects;
        }

        public List<Project> Projects { get; set; }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.Append("Projects:");
            foreach (Project project in this.Projects)
            {
                b.AppendLine();
                b.Append(project);
            }

            return b.ToString();
        }
    }
}
