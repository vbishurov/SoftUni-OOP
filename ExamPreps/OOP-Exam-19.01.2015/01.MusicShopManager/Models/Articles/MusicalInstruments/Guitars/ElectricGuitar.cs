namespace MusicShopManager.Models.Articles.MusicalInstruments.Guitars
{
    using System;
    using System.Text;
    using Interfaces;

    public class ElectricGuitar : Guitar, IElectricGuitar
    {
        private const string InvalidOperationExceptionMessage = "The {0} must be positive.";

        private const bool IsElectronicInstrument = true;
        private const int ElectricGuitarNumberOfStrings = 6;

        private int numberOfAdapters;
        private int numberOfFrets;

        public ElectricGuitar(
            string make,
            string model,
            decimal price,
            string color,
            string bodyWood,
            string fingerboardWood,
            int numberOfAdapters,
            int numberOfFrets)
            : base(
            make,
            model,
            price,
            color,
            ElectricGuitar.IsElectronicInstrument,
            bodyWood,
            fingerboardWood,
            ElectricGuitar.ElectricGuitarNumberOfStrings)
        {
            this.NumberOfAdapters = numberOfAdapters;
            this.NumberOfFrets = numberOfFrets;
        }

        public int NumberOfAdapters
        {
            get
            {
                return this.numberOfAdapters;
            }

            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(string.Format(ElectricGuitar.InvalidOperationExceptionMessage, "NumberOfAdapters"));
                }

                this.numberOfAdapters = value;
            }
        }

        public int NumberOfFrets
        {
            get
            {
                return this.numberOfFrets;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new InvalidOperationException(string.Format(ElectricGuitar.InvalidOperationExceptionMessage, "NumberOfFrets"));
                }

                this.numberOfFrets = value;
            }
        }

        public override string ToString()
        {
            StringBuilder electricGuitar = new StringBuilder();
            electricGuitar.Append(base.ToString());
            electricGuitar.AppendFormat("Adapters: {0}", this.NumberOfAdapters).AppendLine();
            electricGuitar.AppendFormat("Frets: {0}", this.NumberOfFrets).AppendLine();

            return electricGuitar.ToString();
        }
    }
}
