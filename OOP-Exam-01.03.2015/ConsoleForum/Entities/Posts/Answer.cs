namespace ConsoleForum.Entities.Posts
{
    using System.Text;
    using Contracts;

    public class Answer : Post, IAnswer
    {
        private static readonly string AnswerFooter = new string('-', 20);

        public Answer(int id, string body, IUser author)
            : base(id, body, author)
        {
        }

        public override string ToString()
        {
            StringBuilder answer = new StringBuilder();

            answer.Append(base.ToString());
            answer.AppendFormat("Answer Body: {0}", this.Body).AppendLine();
            answer.AppendFormat("{0}", Answer.AnswerFooter);

            return answer.ToString();
        }
    }
}
