namespace ConsoleForum.Entities.Users
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Contracts;

    public class User : IUser
    {
        private const string WhitespacePattern = @"\s+";

        private int id;
        private string username;
        private string password;
        private string email;

        public User(int id, string name, string password, string email)
        {
            this.Id = id;
            this.Username = name;
            this.Password = password;
            this.Email = email;
            this.Questions = new List<IQuestion>();
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

        public string Username
        {
            get
            {
                return this.username;
            }

            set
            {
                if (Regex.IsMatch(value, User.WhitespacePattern))
                {
                    throw new ArgumentException("Username", "Username cannot contain white space(s).");
                }

                this.username = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (Regex.IsMatch(value, User.WhitespacePattern))
                {
                    throw new ArgumentException("Username", "Username cannot contain white space(s).");
                }

                this.password = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (Regex.IsMatch(value, User.WhitespacePattern))
                {
                    throw new ArgumentException("Username", "Username cannot contain white space(s).");
                }

                this.email = value;
            }
        }

        public IList<IQuestion> Questions { get; private set; }
    }
}
