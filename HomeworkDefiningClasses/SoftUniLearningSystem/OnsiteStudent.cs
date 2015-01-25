namespace SoftUniLearningSystem
{
    using System;
    using System.Text;

    internal class OnsiteStudent : CurrentStudent
    {
        private int numberOfVisits;

        public OnsiteStudent(string firstName, string lastName, int studentNumber, float averageGrade, string currentCourse, int numberOfVisits, byte age = 0)
            : base(firstName, lastName, studentNumber, averageGrade, currentCourse, age)
        {
            this.NumberOfVisits = numberOfVisits;
        }

        public int NumberOfVisits
        {
            get
            {
                return this.numberOfVisits;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Number of visits cannot be empty.");
                }

                this.numberOfVisits = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.AppendFormat("Number of visits: {0}", this.NumberOfVisits);
            return b.ToString();
        }
    }
}
