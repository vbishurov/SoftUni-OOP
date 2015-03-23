namespace MusicShopManager.Models.Articles.MusicalInstruments
{
    using System;
    using System.Text;
    using Interfaces;

    public class Drums : MusicInstrument, IDrums
    {
        private const bool IsElectronicInstrument = false;
        private const string InvalidOperationExceptionMessage = "The {0} must be positive.";

        private int width;
        private int height;

        public Drums(string make, string model, decimal price, string color, int width, int height)
            : base(make, model, price, color, Drums.IsElectronicInstrument)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException(string.Format(Drums.InvalidOperationExceptionMessage, "Width"));
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException(string.Format(Drums.InvalidOperationExceptionMessage, "Height"));
                }

                this.height = value;
            }
        }

        public override string ToString()
        {
            StringBuilder drums = new StringBuilder();
            drums.Append(base.ToString());
            drums.AppendFormat("Size: {0}cm x {1}cm", this.Width, this.Height).AppendLine();

            return drums.ToString();
        }
    }
}
