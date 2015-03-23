using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightlifeEntertainment.Models.Performances
{
    class Concert : Performance
    {
        private const PerformanceType ConcertPerformanceType = PerformanceType.Concert;

        public Concert(string name, decimal basePrice, IVenue venue, DateTime startTime)
            : base(name, basePrice, venue, startTime, Concert.ConcertPerformanceType)
        {
        }

        protected override void ValidateVenue()
        {
            if (!(this.Venue.AllowedTypes.Contains(Concert.ConcertPerformanceType) || 
                this.Venue.AllowedTypes.Contains(PerformanceType.Opera)))
            {
                throw new InvalidOperationException("Venue does not support this performance type.");
            }
        }
    }
}
