namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Discipline : IDetailable
    {
        private string name;

        public Discipline(string name, byte numOfLectures, List<Student> students, string details = null)
        {
            this.Name = name;
            this.NumOfLectures = numOfLectures;
            this.Students = students;
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

        public byte NumOfLectures { get; set; }

        public List<Student> Students { get; set; }

        public string Details { get; set; }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(string.Format("Discipline name: {0}", this.Name));
            b.AppendLine(string.Format("Number of lectures: {0}", this.NumOfLectures));
            b.Append("Students:");
            foreach (Student student in this.Students)
            {
                b.AppendLine();
                b.Append(student.ToString());
            }

            if (!string.IsNullOrEmpty(this.Details))
            {
                b.AppendLine();
                b.Append(string.Format("Discipline details: {0}", this.Details));
            }

            return b.ToString();
        }
    }
}
