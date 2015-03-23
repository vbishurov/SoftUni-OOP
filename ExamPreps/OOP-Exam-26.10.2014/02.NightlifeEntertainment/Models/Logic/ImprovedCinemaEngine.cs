using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightlifeEntertainment.Models.Logic
{
    using System.Text.RegularExpressions;
    using Performances;
    using Tickets;
    using Venues;

    class ImprovedCinemaEngine : CinemaEngine
    {
        protected override void ExecuteInsertVenueCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "opera":
                    var opera = new OperaHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(opera);
                    break;
                case "sports_hall":
                    var sportsHall = new SportsHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(sportsHall);
                    break;
                case "concert_hall":
                    var concertHall = new ConcertHall(commandWords[3], commandWords[4], int.Parse(commandWords[5]));
                    this.Venues.Add(concertHall);
                    break;
                default:
                    base.ExecuteInsertVenueCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformanceCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "theatre":
                    var theatreVenue = this.GetVenue(commandWords[5]);
                    var movie = new Theatre(commandWords[3], decimal.Parse(commandWords[4]), theatreVenue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(movie);
                    break;
                case "concert":
                    var concertVenue = this.GetVenue(commandWords[5]);
                    var concert = new Concert(commandWords[3], decimal.Parse(commandWords[4]), concertVenue, DateTime.Parse(commandWords[6] + " " + commandWords[7]));
                    this.Performances.Add(concert);
                    break;
                default:
                    base.ExecuteInsertPerformanceCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyTicketsCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[3]);
            switch (commandWords[1])
            {
                case "student":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new StudentTicket(performance));
                    }

                    break;
                case "vip":
                    for (int i = 0; i < int.Parse(commandWords[4]); i++)
                    {
                        performance.AddTicket(new VIPTicket(performance));
                    }

                    break;
                default:
                    base.ExecuteSupplyTicketsCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportCommand(string[] commandWords)
        {
            var performance = this.GetPerformance(commandWords[1]);
            var soldTicketsCount = performance.Tickets.Count(t => t.Status == TicketStatus.Sold);
            var totalSum = performance.Tickets.Where(t => t.Status == TicketStatus.Sold).Sum(t => t.Price);

            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}: {1} ticket(s), total: ${2:F2}", performance.Name, soldTicketsCount, totalSum).AppendLine();
            result.AppendFormat("Venue: {0} ({1})", performance.Venue.Name, performance.Venue.Location).AppendLine();
            result.AppendFormat("Start time: {0}", performance.StartTime).AppendLine();

            this.Output.Append(result);
        }

        protected override void ExecuteFindCommand(string[] commandWords)
        {
            var searchPattern = new Regex(commandWords[1], RegexOptions.IgnoreCase);
            var startTime = DateTime.Parse(commandWords[2] + " " + commandWords[3]);

            var performances = this.Performances.Where(p => searchPattern.IsMatch(p.Name) && p.StartTime >= startTime)
                .OrderBy(p => p.StartTime)
                .ThenByDescending(p => p.BasePrice)
                .ThenBy(p => p.Name)
                .Select(p => p.Name)
                .ToList();

            var venues = this.Venues.Where(v => searchPattern.IsMatch(v.Name)).OrderBy(v => v.Name).ToList();

            StringBuilder result = new StringBuilder();
            result.AppendFormat("Search for \"{0}\"", commandWords[1]).AppendLine();
            result.AppendLine("Performances:");
            result.AppendLine(performances.Any() ? "-" + string.Join(Environment.NewLine + "-", performances) : "no results");

            result.AppendLine("Venues:");
            if (!venues.Any())
            {
                result.AppendLine("no results");
                this.Output.Append(result);
                return;
            }

            foreach (var venue in venues)
            {
                var venuePerformances = this.Performances.Where(p => p.Venue == venue && p.StartTime >= startTime)
                    .OrderBy(p => p.StartTime)
                    .ThenByDescending(p => p.BasePrice)
                    .ThenBy(p => p.Name)
                    .Select(p => p.Name)
                    .ToList();
                result.AppendFormat("-{0}", venue.Name).AppendLine();

                if (!venuePerformances.Any())
                {
                    continue;
                }

                result.AppendLine("--" + string.Join(Environment.NewLine + "--", venuePerformances));
            }

            this.Output.Append(result);
        }
    }
}
