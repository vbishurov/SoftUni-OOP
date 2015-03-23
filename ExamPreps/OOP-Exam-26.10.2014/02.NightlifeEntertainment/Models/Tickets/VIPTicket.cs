using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightlifeEntertainment.Models.Tickets
{
    class VIPTicket : Ticket
    {
        private const TicketType VIPTicketType = TicketType.VIP;

        public VIPTicket(IPerformance performance)
            : base(performance, VIPTicket.VIPTicketType)
        {
        }

        protected override decimal CalculatePrice()
        {
            base.CalculatePrice();
            return this.Performance.BasePrice * 1.5m;
        }
    }
}
