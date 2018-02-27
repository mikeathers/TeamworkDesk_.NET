using System;

namespace TeamworkDesk_React.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int CreatedByUsersId { get; set; }
        public int UpdatedByUsersId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TicketId { get; set; }
        public int TicketCount { get; set; }
        public object LastUpdated { get; set; }
    }
}