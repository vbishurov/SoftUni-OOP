namespace MusicShopManager.Models.Articles.MusicalInstruments
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class MusicInstrument : Article, IInstrument
    {
        private const string RequiredArgumentExceptionMessage = "The {0} is required.";

        private string color;

        protected MusicInstrument(string make, string model, decimal price, string color, bool isElectronic)
            : base(make, model, price)
        {
            this.Color = color;
            this.IsElectronic = isElectronic;
        }

        public string Color
        {
            get
            {
                return this.color;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(MusicInstrument.RequiredArgumentExceptionMessage, "Color"));
                }

                this.color = value;
            }
        }

        public bool IsElectronic { get; private set; }

        public override string ToString()
        {
            StringBuilder instrument = new StringBuilder();

            instrument.Append(base.ToString());
            instrument.AppendFormat("Color: {0}", this.Color).AppendLine();
            instrument.AppendFormat("Electronic: {0}", this.IsElectronic ? "yes" : "no").AppendLine();

            return instrument.ToString();
        }
    }
}
