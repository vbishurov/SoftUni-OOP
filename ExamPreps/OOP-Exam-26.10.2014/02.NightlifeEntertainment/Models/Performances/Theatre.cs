using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightlifeEntertainment.Models.Performances
{
    class Theatre : Performance
    {
        private const PerformanceType TheatrePerformanceType = PerformanceType.Theatre;

        public Theatre(string name, decimal basePrice, IVenue venue, DateTime startTime)
            : base(name, basePrice, venue, startTime, Theatre.TheatrePerformanceType)
        {
        }

        protected override void ValidateVenue()
        {
            if (!this.Venue.AllowedTypes.Contains(Theatre.TheatrePerformanceType))
            {
                throw new InvalidOperationException("Venue does not support this performance type.");
            }
        }
    }
}
