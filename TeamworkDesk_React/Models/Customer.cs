using System;

namespace TeamworkDesk_React.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
        public string Type { get; set; }
        public string ExternalId { get; set; }
        public string ExtraData { get; set; }
        public string FacebookUrl { get; set; }
        public string GooglePlusUrl { get; set; }
        public string JobTitle { get; set; }
        public string Language { get; set; }
        public string LinkedinUrl { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string Notes { get; set; }
        public int NumTickets { get; set; }
        public string Organization { get; set; }
        public string Phone { get; set; }
        public int? TimezoneId { get; set; }
        public bool Trusted { get; set; }
        public string TwitterHandle { get; set; }
        public bool WelcomeEmailSent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object LastTicketDate { get; set; }
    }
}