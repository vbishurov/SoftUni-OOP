namespace HumanStudentWorker
{
    using System;
    using System.Text;

    internal class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentOutOfRangeException("Faulty number must be between 5 and 10 characters long.");
                }

                foreach (char c in value)
                {
                    if (char.IsLetterOrDigit(c))
                    {
                        continue;
                    }
                    else
                    {
                        throw new ArgumentException("Faulty number must contain only letters and numbers.");
                    }
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.Append("Faculty number: " + this.FacultyNumber);
            return b.ToString();
        }
    }
}
