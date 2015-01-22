using System;
using System.Text;

namespace SoftUniLearningSystem
{
    class Student : Person
    {
        private int studentNumber;
        private float averageGrade;

        public Student(string firstName, string lastName, int studentNumber, float averageGrade, byte age = 0)
            : base(firstName, lastName, age)
        {
            this.StudentNumber = studentNumber;
            this.AverageGrade = averageGrade;
        }

        public int StudentNumber
        {
            get { return this.studentNumber; }
            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Student number must be in range [10000...99999]");
                }
                this.studentNumber = value;
            }
        }

        public float AverageGrade
        {
            get { return this.averageGrade; }
            set
            {
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("Average grade must be in range [2...6]");
                }
                this.averageGrade = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.AppendLine("Student number: " + this.StudentNumber);
            b.Append("Average grade: " + this.AverageGrade);
            return b.ToString();
        }
    }
}
