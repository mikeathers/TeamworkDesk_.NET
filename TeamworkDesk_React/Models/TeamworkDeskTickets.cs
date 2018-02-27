using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace TeamworkDesk_React.Models
{
    public class TeamworkDeskTickets
    {
        public int Count { get; set; }

        public List<Ticket> Tickets { get; set; }

             

    }
}