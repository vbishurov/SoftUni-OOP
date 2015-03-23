namespace ConsoleForum.Commands
{
    using System;
    using System.Linq;
    using Contracts;

    public class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            if (!this.Forum.Questions.Any())
            {
                throw new CommandException(Messages.NoQuestions);
            }

            this.Forum.CurrentQuestion = null;

            var questions = this.Forum.Questions.OrderBy(q => q.Id);

            this.Forum.Output.AppendLine(string.Join(Environment.NewLine, questions));
        }
    }
}
