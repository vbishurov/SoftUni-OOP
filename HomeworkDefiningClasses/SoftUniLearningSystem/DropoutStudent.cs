namespace SoftUniLearningSystem
{
    using System;
    using System.Text;

    internal class DropoutStudent : Student
    {
        private string dropoutReason;

        public DropoutStudent(string firstName, string lastName, int studentNumber, float averageGrade, string dropoutReason, byte age = 0)
            : base(firstName, lastName, studentNumber, averageGrade, age)
        {
            this.DropoutReason = dropoutReason;
        }

        public string DropoutReason
        {
            get
            {
                return this.dropoutReason;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Trim() == string.Empty)
                {
                    throw new ArgumentNullException("Dropout reason cannot be empty.");
                }

                this.dropoutReason = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine("Trying to reapply student:");
            b.AppendLine(base.ToString());
            b.AppendFormat("Dropout reason: {0}", this.DropoutReason);
            return b.ToString();
        }

        public void Reapply()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
