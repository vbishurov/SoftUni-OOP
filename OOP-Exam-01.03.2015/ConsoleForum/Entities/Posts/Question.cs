namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using Contracts;

    public class Question : Post, IQuestion
    {
        private static readonly string QuestionFooter = new string('=', 20);
        private string title;

        public Question(int id, string body, IUser author, string title)
            : base(id, body, author)
        {
            this.Title = title;
            this.Answers = new List<IAnswer>();
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (Regex.IsMatch(value, Post.WhitespacePattern))
                {
                    throw new ArgumentException("Username", "Username cannot contain white space(s).");
                }
                
                this.title = value;
            }
        }

        public IList<IAnswer> Answers { get; private set; }

        public override string ToString()
        {
            StringBuilder question = new StringBuilder();

            question.Append(base.ToString());
            question.AppendFormat("Question Title: {0}", this.Title).AppendLine();
            question.AppendFormat("Question Body: {0}", this.Body).AppendLine();
            question.AppendFormat("{0}", Question.QuestionFooter).AppendLine();

            if (!this.Answers.Any())
            {
                question.Append("No answers");
            }
            else
            {
                question.AppendLine("Answers:");

                var bestAnswer = this.Answers.FirstOrDefault(a => a is BestAnswer);
                if (bestAnswer != null)
                {
                    question.AppendLine(bestAnswer.ToString());
                }

                var otherAnswers = this.Answers.Where(a => !(a is BestAnswer)).OrderBy(a => a.Id).ToList();

                question.Append(string.Join(Environment.NewLine, otherAnswers));
            }

            return question.ToString();
        }
    }
}
