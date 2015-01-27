namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Student : Person
    {
        private static List<uint> uniqueClassNumbers;

        private uint classNumber;

        static Student()
        {
            uniqueClassNumbers = new List<uint>();
        }

        public Student(string name, uint classNumber, string details = null)
            : base(name, details)
        {
            this.ClassNumber = classNumber;
        }

        public uint ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            set
            {
                if (Student.uniqueClassNumbers.Contains(value))
                {
                    throw new ArgumentException("Student class number is unique.");
                }

                Student.uniqueClassNumbers.Add(value);
                this.classNumber = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.Append(string.Format("Unique class number: {0}", this.ClassNumber));
            return b.ToString();
        }
    }
}
