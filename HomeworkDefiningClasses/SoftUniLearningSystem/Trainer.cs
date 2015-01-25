namespace SoftUniLearningSystem
{
    using System;

    internal abstract class Trainer : Person
    {
        protected Trainer(string firstName, string lastName, byte age = 0)
            : base(firstName, lastName, age)
        {
        }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine("Course {0} created successfully.", courseName);
        }
    }
}
