namespace ConsoleForum
{
    using Contracts;

    public class ConsoleForumMain
    {
        public static void Main()
        {
            IForum forum = new ImprovedForum();
            forum.Run();
        }
    }
}
