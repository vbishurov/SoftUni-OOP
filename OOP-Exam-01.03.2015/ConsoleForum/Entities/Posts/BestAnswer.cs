namespace ConsoleForum.Entities.Posts
{
    using System.Text;
    using Contracts;

    public class BestAnswer : Answer
    {
        private static readonly string BestAnswerHeaderFooter = new string('*', 20);

        public BestAnswer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            StringBuilder bestAnswer = new StringBuilder();

            bestAnswer.AppendLine(BestAnswer.BestAnswerHeaderFooter);
            bestAnswer.AppendLine(base.ToString());
            bestAnswer.Append(BestAnswer.BestAnswerHeaderFooter);
            bestAnswer.Replace("BestAnswer", "Answer");

            return bestAnswer.ToString();
        }
    }
}
