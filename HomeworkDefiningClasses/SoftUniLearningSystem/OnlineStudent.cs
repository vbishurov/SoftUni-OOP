namespace SoftUniLearningSystem
{
    internal class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string firstName, string lastName, int studentNumber, float averageGrade, string currentCourse, byte age = 0)
            : base(firstName, lastName, studentNumber, averageGrade, currentCourse, age)
        {
        }
    }
}
