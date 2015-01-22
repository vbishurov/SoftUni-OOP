using System;

namespace SoftUniLearningSystem
{
    class SeniorTrainer : Trainer
    {
        public SeniorTrainer(string firstName, string lastName, byte age = 0)
            : base(firstName, lastName, age)
        {

        }

        public void DeleteCourse(string courseName)
        {
            Console.WriteLine("Course {0} deleted successfully.", courseName);
        }
    }
}
