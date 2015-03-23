using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightlifeEntertainment.Models.Venues
{
    class OperaHall : Venue
    {
        private static readonly IList<PerformanceType> AllowedPerformanceTypes = 
            new List<PerformanceType>() { PerformanceType.Opera, PerformanceType.Theatre };

        public OperaHall(string name, string location, int numberOfSeats)
            : base(name, location, numberOfSeats, OperaHall.AllowedPerformanceTypes)
        {
        }
    }
}
