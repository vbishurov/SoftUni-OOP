namespace ConsoleForum.Entities.Posts
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using Contracts;

    public abstract class Post : IPost
    {
        protected const string WhitespacePattern = @"\s+";

        private int id;
        private string body;

        protected Post(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Id", "User id must be bigger than 1.");
                }

                this.id = value;
            }
        }

        public string Body
        {
            get
            {
                return this.body;
            }

            set
            {
                if (Regex.IsMatch(value, Post.WhitespacePattern))
                {
                    throw new ArgumentException("Username", "Username cannot contain white space(s).");
                }
                
                this.body = value;
            }
        }

        public IUser Author { get; set; }

        public override string ToString()
        {
            StringBuilder post = new StringBuilder();

            post.AppendFormat("[ {0} ID: {1} ]", this.GetType().Name, this.Id).AppendLine();
            post.AppendFormat("Posted by: {0}", this.Author.Username).AppendLine();

            return post.ToString();
        }
    }
}
