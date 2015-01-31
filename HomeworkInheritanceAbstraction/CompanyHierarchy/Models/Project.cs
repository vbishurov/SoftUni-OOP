namespace CompanyHierarchy.Models
{
    using System;
    using System.Text;
    using global::CompanyHierarchy.Interfaces;

    public class Project : IProject
    {
        private string projectName;
        private string details;
        private string state;

        public Project(string projectName, DateTime projectStartDate, string details, string state)
        {
            this.ProjectName = projectName;
            this.ProjectStartDate = projectStartDate;
            this.Details = details;
            this.State = state;
        }

        public string ProjectName
        {
            get
            {
                return this.projectName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Project name cannot be empty.");
                }

                this.projectName = value;
            }
        }

        public DateTime ProjectStartDate { get; set; }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Details cannot be empty.");
                }

                this.details = value;
            }
        }

        public string State
        {
            get
            {
                return this.state;
            }

            set
            {
                if (value.ToLower() != "open" && value.ToLower() != "closed")
                {
                    throw new ArgumentException("Project state can only be open or closed.");
                }

                this.state = value;
            }
        }

        public void CloseProject()
        {
            if (this.State.ToLower() == "open")
            {
                this.State = "Closed";
            }
            else
            {
                Console.WriteLine("Project is already closed.");
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine("Project name " + this.ProjectName);
            b.AppendLine("Project started: " + this.ProjectStartDate);
            b.AppendLine("Project state: " + this.State);
            b.Append("Details: " + this.Details);
            return b.ToString();
        }
    }
}
