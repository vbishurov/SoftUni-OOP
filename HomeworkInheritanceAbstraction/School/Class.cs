namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Class : IDetailable
    {
        private static List<string> uniqueIdentifiers;

        private string identifier;

        static Class()
        {
            uniqueIdentifiers = new List<string>();
        }

        public Class(string identifier, List<Student> students, List<Teacher> teachers, string details = null)
        {
            this.Identifier = identifier;
            this.Students = students;
            this.Teachers = teachers;
            this.Details = details;
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Class identifier cannot be empty.");
                }

                if (Class.uniqueIdentifiers.Contains(value))
                {
                    throw new ArgumentException("Class identifier is unique.");
                }

                Class.uniqueIdentifiers.Add(value);
                this.identifier = value;
            }
        }

        public List<Student> Students { get; set; }

        public List<Teacher> Teachers { get; set; }

        public string Details { get; set; }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine("Class identifier: " + this.Identifier);
            b.Append("Students:");
            foreach (Student student in this.Students)
            {
                b.AppendLine();
                b.Append(student.ToString());
            }

            b.AppendLine();
            b.Append("Teachers: ");
            foreach (Teacher student in this.Teachers)
            {
                b.AppendLine();
                b.Append(student.ToString());
            }

            if (!string.IsNullOrEmpty(this.Details))
            {
                b.AppendLine();
                b.Append("Class details: " + this.Details);
            }

            return b.ToString();
        }
    }
}
