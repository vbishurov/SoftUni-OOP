using System;
using System.Text;

namespace Persons
{
    class Person
    {
        private string name;
        private byte age;
        private string email;

        public Person(string name, byte age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Person(string name, byte age) : this(name, age, null) { }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public byte Age
        {
            get { return this.age; }
            private set
            {
                if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age must be between [0...100]");
                }
                this.age = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            private set
            {
                if (!(value == null || value.Contains("@")))
                {
                    throw new ArgumentException("Email can be null or must contain @");
                }
                this.email = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendFormat("I am {0}. I am {1} years old.", this.Name, this.Age);
            if (!string.IsNullOrEmpty(this.email))
            {
                b.AppendFormat("My email is: {0}", this.Email);
            }
            return b.ToString();
        }
    }

}
