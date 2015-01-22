using System;
using System.Text;

namespace SoftUniLearningSystem
{
    class CurrentStudent : Student
    {
        private string currentCourse;

        public CurrentStudent(string firstName, string lastName, int studentNumber, float averageGrade, string currentCourse, byte age = 0)
            : base(firstName, lastName, studentNumber, averageGrade, age)
        {
            this.CurrentCourse = currentCourse;
        }

        public string CurrentCourse
        {
            get { return this.currentCourse; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Trim() == "")
                {
                    throw new ArgumentNullException("Current course cannot be empty.");
                }
                this.currentCourse = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.AppendFormat("Current course: {0}", this.CurrentCourse);
            return b.ToString();
        }
    }
}
