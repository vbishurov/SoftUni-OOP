using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightlifeEntertainment.Models.Tickets
{
    class StudentTicket : Ticket
    {
        private const TicketType StudentTicketType = TicketType.Student;

        public StudentTicket(IPerformance performance)
            : base(performance, StudentTicket.StudentTicketType)
        {
        }

        protected override decimal CalculatePrice()
        {
            base.CalculatePrice();
            return this.Performance.BasePrice * 0.8m;
        }
    }
}
