namespace MusicShopManager.Models.Articles.MusicalInstruments.Guitars
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Guitar : MusicInstrument, IGuitar
    {
        private const string RequiredArgumentExceptionMessage = "The {0} is required.";

        private string bodyWood;
        private string fingerboardWood;

        protected Guitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood, string fingerboardWood, int numberOfStrings)
            : base(make, model, price, color, isElectronic)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fingerboardWood;
            this.NumberOfStrings = numberOfStrings;
        }

        public string BodyWood
        {
            get
            {
                return this.bodyWood;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(Guitar.RequiredArgumentExceptionMessage, "BodyWood"));
                }

                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get
            {
                return this.fingerboardWood;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(Guitar.RequiredArgumentExceptionMessage, "FingerboardWood"));
                }

                this.fingerboardWood = value;
            }
        }

        public int NumberOfStrings { get; private set; }

        public override string ToString()
        {
            StringBuilder guitar = new StringBuilder();
            guitar.Append(base.ToString());
            guitar.AppendFormat("Strings: {0}", this.NumberOfStrings).AppendLine();
            guitar.AppendFormat("Body wood: {0}", this.BodyWood).AppendLine();
            guitar.AppendFormat("Fingerboard wood: {0}", this.FingerboardWood).AppendLine();

            return guitar.ToString();
        }
    }
}
