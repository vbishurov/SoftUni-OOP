namespace CompanyHierarchy.People
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private string id;

        protected Person(string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be empty.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be empty.");
                }

                this.lastName = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Id cannot be empty.");
                }

                this.id = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(string.Format("Name: {0} {1}", this.FirstName, this.LastName));
            b.Append("Id: " + this.Id);
            return b.ToString();
        }
    }
}
