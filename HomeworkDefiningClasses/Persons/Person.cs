using System;

namespace Persons
{
    class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age, string email)
        {
            this.Name = name;
            this.Age = age;
            this.Email = email;
        }

        public Person(string name, int age) : this(name, age, null) { }

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

        public int Age
        {
            get { return this.age; }
            private set
            {
                if ((value < 0) || (value > 100))
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
            if (!string.IsNullOrEmpty(this.email))
            {
                return "I am " + this.Name + ". I am " + this.Age + " years old. My email is: " + this.Email;
            }
            return "I am " + this.Name + ". I am " + this.Age + " years old.";
        }
    }

}
