namespace SoftUniLearningSystem
{
    using System;
    using System.Text;

    public abstract class Person
    {
        private string firstName;
        private string lastName;
        private byte age;

        protected Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        protected Person(string firstName, string lastName, byte age)
            : this(firstName, lastName)
        {
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Trim() == string.Empty)
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
                if (string.IsNullOrEmpty(value) || value.Trim() == string.Empty)
                {
                    throw new ArgumentNullException("Last name cannot be empty.");
                }

                this.lastName = value;
            }
        }

        public byte Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age must be between [0...100]");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("Name: " + this.FirstName + " " + this.LastName);
            if (this.Age != 0)
            {
                b.AppendLine();
                b.Append("Age: " + this.Age);
            }

            return b.ToString();
        }
    }
}
