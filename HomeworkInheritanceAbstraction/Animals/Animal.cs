namespace Animals
{
    using System;
    using System.Text;

    internal abstract class Animal
    {
        private string name;
        private string gender;
        private byte age;

        protected Animal(string name, string gender, byte age)
        {
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
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
                    throw new ArgumentNullException("Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public string Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                if ((value.ToLower() != "male") && (value.ToLower() != "female"))
                {
                    throw new ArgumentException("Gender is either male or female.");
                }

                this.gender = value;
            }
        }

        public byte Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age must be in range [0...100].");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine("Name : " + this.Name);
            b.AppendLine("Gender: " + this.Gender);
            b.Append("Age: " + this.age);
            return b.ToString();
        }
    }
}
