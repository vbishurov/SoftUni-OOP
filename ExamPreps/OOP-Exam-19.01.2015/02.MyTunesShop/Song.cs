namespace MyTunesShop
{
    using System;
    using System.Collections.Generic;
    using Models;

    public class Song : Media, ISong
    {
        private static readonly int MinYear = DateTime.MinValue.Year;
        private static readonly int MaxYear = DateTime.Now.Year;

        private IPerformer performer;
        private string genre;
        private int year;
        private string duration;

        public Song(string title, decimal price, IPerformer performer, string genre, int year, string duration)
            : base(title, price)
        {
            this.performer = performer;
            this.genre = genre;
            this.duration = duration;
            this.year = year;
            this.Ratings = new List<int>();
        }

        public IPerformer Performer
        {
            get
            {
                return this.performer;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("The performer of a song is required.");
                }

                this.performer = value;
            }
        }

        public string Genre
        {
            get
            {
                return this.genre;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The genre of a song is required.");
                }

                this.genre = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            private set
            {
                if (value < Song.MinYear || value > Song.MaxYear)
                {
                    throw new ArgumentException(string.Format("The year of a song must be between {0} and {1}.", Song.MinYear, Song.MaxYear));
                }

                this.year = value;
            }
        }

        public string Duration
        {
            get
            {
                return this.duration;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The duration of a song is required.");
                }

                this.duration = value;
            }
        }

        public IList<int> Ratings { get; private set; }

        public void PlaceRating(int rating)
        {
            this.Ratings.Add(rating);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", this.Title, this.Duration);
        }
    }
}
