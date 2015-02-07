namespace ExcelExport
{
    public sealed class Student
    {
        public Student(
            int id,
            string firstName,
            string lastName,
            string email,
            Gender gender,
            StudentType studentType,
            int examResult,
            int homeworkSent,
            int homeworkEvaluated,
            float teamworkScore,
            float attendances,
            float bonus)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Gender = gender;
            this.StudentType = studentType;
            this.ExamResult = examResult;
            this.HomeworkSent = homeworkSent;
            this.HomeworkEvaluated = homeworkEvaluated;
            this.TeamworkScore = teamworkScore;
            this.Attendances = attendances;
            this.Bonus = bonus;
            this.Result = this.CalculateResult();
        }

        public float Result { get; private set; }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public Gender Gender { get; private set; }

        public StudentType StudentType { get; private set; }

        public int ExamResult { get; private set; }

        public int HomeworkSent { get; private set; }

        public int HomeworkEvaluated { get; private set; }

        public float TeamworkScore { get; private set; }

        public float Attendances { get; private set; }

        public float Bonus { get; private set; }

        public float CalculateResult()
        {
            return (this.ExamResult + this.HomeworkEvaluated + this.HomeworkSent + this.TeamworkScore + this.Attendances) / 5;
        }

        public override string ToString()
        {
            return string.Format(
                "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}",
                this.Id,
                this.FirstName,
                this.LastName,
                this.Email,
                this.Gender,
                this.StudentType,
                this.ExamResult,
                this.HomeworkSent,
                this.HomeworkEvaluated,
                this.TeamworkScore,
                this.Attendances,
                this.Bonus,
                this.CalculateResult());
        }
    }
}
