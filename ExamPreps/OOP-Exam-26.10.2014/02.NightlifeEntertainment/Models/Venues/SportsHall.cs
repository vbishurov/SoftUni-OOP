using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightlifeEntertainment.Models.Venues
{
    class SportsHall : Venue
    {
        private static readonly IList<PerformanceType> AllowedPerformanceTypes =
            new List<PerformanceType>() { PerformanceType.Sport, PerformanceType.Concert };

        public SportsHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, SportsHall.AllowedPerformanceTypes)
        {
        }
    }
}
