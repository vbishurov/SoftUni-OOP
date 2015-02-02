namespace BankOfKurtovoKunare.Custumers
{
    using System;
    using Interfaces;

    public class Custumer : ICustumer
    {
        private string name;

        protected Custumer(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name", "Name cannot be empty.");
                }

                this.name = value;
            }
        }
    }
}
