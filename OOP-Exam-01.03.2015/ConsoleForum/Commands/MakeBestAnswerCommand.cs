namespace ConsoleForum.Commands
{
    using System.Linq;
    using Contracts;
    using Entities.Posts;
    using Entities.Users;

    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            var question = this.Forum.CurrentQuestion;
            if (question == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }

            var id = int.Parse(this.Data[1]);
            var answer = question.Answers.FirstOrDefault(a => a.Id == id);

            if (answer == null)
            {
                throw new CommandException(Messages.NoAnswer);
            }

            var currentUser = this.Forum.CurrentUser;
            if (question.Author != currentUser && !(currentUser is Admin))
            {
                throw new CommandException(Messages.NoPermission);
            }

            question.Answers.Remove(answer);
            answer = new BestAnswer(answer.Id, answer.Body, answer.Author);
            question.Answers.Add(answer);

            this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess, answer.Id));
        }
    }
}
