using System;

namespace SoftUniLearningSystem
{
    class Trainer : Person
    {
        public Trainer(string firstName, string lastName, byte age = 0)
            : base(firstName, lastName, age)
        {

        }

        public void CreateCourse(string courseName)
        {
            Console.WriteLine("Course {0} created successfully.", courseName);
        }
    }
}
