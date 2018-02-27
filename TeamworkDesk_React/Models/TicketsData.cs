using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamworkDesk_React.Models
{
    public class TicketsData
    {
        public List<Ticket> Tickets { get; set; }

        public string EmailAddressOfLoggedOnUser { get; set; }
    }
}