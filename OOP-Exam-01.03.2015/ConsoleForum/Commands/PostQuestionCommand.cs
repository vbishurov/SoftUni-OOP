namespace ConsoleForum.Commands
{
    using Contracts;
    using Entities.Posts;

    public class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            var questionID = this.Forum.Questions.Count + 1;
            var body = this.Data[2];
            var currentUser = this.Forum.CurrentUser;
            var title = this.Data[1];

            var question = new Question(questionID, body, currentUser, title);

            this.Forum.Questions.Add(question);
            currentUser.Questions.Add(question);

            this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, questionID));
        }
    }
}
