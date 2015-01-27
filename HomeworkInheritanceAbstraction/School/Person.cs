namespace School
{
    using System;
    using System.Text;

    internal abstract class Person : IDetailable
    {
        private string name;

        protected Person(string name, string details = null)
        {
            this.Name = name;
            this.Details = details;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public string Details { get; set; }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append(string.Format("Name: {0}", this.Name));
            if (!string.IsNullOrEmpty(this.Details))
            {
                b.AppendLine();
                b.Append(string.Format("Details: {0}", this.Details));
            }

            return b.ToString();
        }
    }
}
