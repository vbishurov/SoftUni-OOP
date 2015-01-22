namespace SoftUniLearningSystem
{
    class GraduateStudent : Student
    {
        public GraduateStudent(string firstName, string lastName, int studentNumber, float averageGrade, byte age = 0)
            : base(firstName, lastName, studentNumber, averageGrade, age)
        {

        }
    }
}
