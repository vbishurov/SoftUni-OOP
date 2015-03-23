namespace ConsoleForum
{
    using System;
    using System.Linq;
    using Entities.Posts;

    public class ImprovedForum : Forum
    {
        private static readonly string ForumHeaderDelimeter = new string('~', 20);

        protected override void ExecuteCommandLoop()
        {
            this.Output.Clear();

            this.Output.AppendLine(ImprovedForum.ForumHeaderDelimeter);

            if (this.IsLogged)
            {
                this.Output.AppendLine(string.Format(Messages.UserWelcomeMessage, this.CurrentUser.Username));
            }
            else
            {
                this.Output.AppendLine(Messages.GuestWelcomeMessage);
            }

            var hotQuestions = this.Questions.Count(q => q.Answers.Any(a => a is BestAnswer));
            var activeUsers = (
                from user in this.Users
                let userAnswersCount = this.Answers.Count(answer => answer.Author.Username == user.Username)
                where userAnswersCount >= 3
                select user).Count();

            this.Output.AppendLine(string.Format(Messages.GeneralHeaderMessage, hotQuestions, activeUsers));

            this.Output.AppendLine(ImprovedForum.ForumHeaderDelimeter);

            Console.Write(this.Output);

            base.ExecuteCommandLoop();
        }
    }
}
