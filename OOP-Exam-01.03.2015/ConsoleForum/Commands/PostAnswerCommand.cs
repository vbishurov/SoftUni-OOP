namespace ConsoleForum.Commands
{
    using System;
    using Contracts;
    using Entities.Posts;

    public class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            var answerId = Math.Max(this.Forum.CurrentQuestion.Answers.Count + 1, this.Forum.Answers.Count + 1);
            var answerBody = this.Data[1];
            var currentUser = this.Forum.CurrentUser;

            var answer = new Answer(answerId, answerBody, currentUser);

            this.Forum.CurrentQuestion.Answers.Add(answer);
            this.Forum.Answers.Add(answer);

            this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess, answerId));
        }
    }
}
