using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightlifeEntertainment.Models.Venues
{
    class ConcertHall : Venue
    {
        private static readonly IList<PerformanceType> AllowedPerformanceTypes =
            new List<PerformanceType>() { PerformanceType.Opera, PerformanceType.Theatre, PerformanceType.Concert };

        public ConcertHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, ConcertHall.AllowedPerformanceTypes)
        {
        }
    }
}
