namespace GalacticGPS
{
    using System;

    public struct Location
    {
        private double latitude;
        private double longtitude;
        private Planet planet;

        public Location(double latitude, double longtitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longtitude = longtitude;
            this.Planet = planet;
        }

        public double Latitude
        {
            get
            {
                return this.latitude;
            }

            private set
            {
                this.latitude = value;
            }
        }

        public double Longtitude
        {
            get
            {
                return this.longtitude;
            }

            private set
            {
                this.longtitude = value;
            }
        }

        public Planet Planet
        {
            get
            {
                return this.planet;
            }

            set
            {
                this.planet = value;
            }
        }

        public override string ToString()
        {
            string location = string.Format("{0}, {1} - {2}", this.Latitude, this.Longtitude, this.Planet);
            return location;
        }
    }
}
