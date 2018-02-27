using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamworkDesk_React.Models
{
    public class Thread
    {
        public List<AgentsNotified> AgentsNotified { get; set; }
        public List<object> Attachments { get; set; }
        public List<string> Bcc { get; set; }
        public string Body { get; set; }
        public List<string> Cc { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public string EditMethod { get; set; }
        public object ForwardedThreadIds { get; set; }
        public object HappinessRatingName { get; set; }
        public object HelpdocsarticleId { get; set; }
        public int Id { get; set; }
        public NewTicketAssignment NewTicketAssignment { get; set; }
        public string NewTicketStatus { get; set; }
        public string S3Link { get; set; }
        public object TaskId { get; set; }
        public string TextBody { get; set; }
        public object To { get; set; }
        public string Type { get; set; }
        public string DeliveryStatus { get; set; }
        public string DeliveryReason { get; set; }
        public string DeliveryMethod { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? CreatedByCustomerId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object ViewedByCustomerAt { get; set; }
        public object MergedAt { get; set; }

        public string FullName => ($"{CreatedBy.FirstName} {CreatedBy.LastName}");

        public string Preview => Type != "eventInfo" ? StringExtensions.StripHTML(Body) : null;

        public string Action => CreatedBy.Type == "customer" ? "asked" : Actions.FirstOrDefault(a => a.Key == Type).Value;

        public string BodyNoHtml => StringExtensions.StripHTML(Body);

        public string InitialRequest
        {
            get
            {
                var initRequest = "TEST";

                if (Type == "message" && BodyNoHtml.Contains("a: Speed Medical House, Matrix Park, Chorley, PR7 7NA"))
                {
                    initRequest = BodyNoHtml.Substring(0, BodyNoHtml.LastIndexOf("a: Speed Medical House, Matrix Park, Chorley, PR7 7NA"));
                }
                else
                {
                    initRequest = BodyNoHtml;
                }

                return initRequest;
            }
        }

        public string ParsedBody
        {
            get
            {
                if (NewTicketStatus != null && Type == "eventInfo")
                {
                    Body = $" marked as {NewTicketStatus}";
                }
                if (NewTicketAssignment != null && Type == "eventInfo")
                {
                    Body = $" assigned to {NewTicketAssignment.FullName}";
                }

                return Body;

            }

        }

        private Dictionary<string, string> Actions = new Dictionary<string, string>
        {
            {"message", "replied"},
            {"note", "added a note "},
            {"eventInfo", ""}
        };




    }
}


