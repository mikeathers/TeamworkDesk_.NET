using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TeamworkDesk_React.Models
{
    public class Ticket
    {

        public int Id { get; set; }
        public AssignedTo AssignedTo { get; set; }
        public Customer Customer { get; set; }
        public object CustomFields { get; set; }
        public object DeletedByUserId { get; set; }
        public object HappinessRating { get; set; }
        public bool HasAttachments { get; set; }
        public int InboxId { get; set; }
        public bool IsRead { get; set; }
        public int? MergedToId { get; set; }
        public int? NumActiveTasks { get; set; }
        public int? NumCompletedTasks { get; set; }
        public int? NumThreads { get; set; }
        public string Preview { get; set; }
        public string Source { get; set; }
        public float? SpamScore { get; set; }
        public string Status { get; set; }
        public string Subject { get; set; }
        public List<Tag> Tags { get; set; }
        public ResponseTimes ResponseTimes { get; set; }
        public string Type { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object DeletedAt { get; set; }
        public List<object> Bcc { get; set; }
        public List<object> Cc { get; set; }
        public object CreatedByUser { get; set; }
        public List<object> Fields { get; set; }
        public int? ExternalId { get; set; }
        public CustomergroupsId CustomergroupsId { get; set; }
        public bool HasTimeLogged { get; set; }
        public bool ImagesHidden { get; set; }
        public string OriginalRecipient { get; set; }
        public int? ResolutionTimeMins { get; set; }
        public int? ResponseTimeMins { get; set; }
        public List<Thread> Threads { get; set; }

        [Display(Name = "Created At:")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Original Message:")]
        public string OriginalMessage => Threads != null ? Threads[Threads.Count - 1].Body : "";

        [Display(Name = "Inbox:")]
        public string InboxName => _inboxes.First(i => i.Key == InboxId).Value;

        [Display(Name = "Assigned To:")]
        public string AssignedToFullName => AssignedTo != null ? $"{AssignedTo.FirstName} {AssignedTo.LastName}" : "Unassigned";

        [Display(Name = "Customer Name:")]
        public string CustomerName => Customer != null ? $"{Customer.FirstName} {Customer.LastName}" : "No Customer";

        public string ParsedSubject => Subject.Shorten(5);

        public string Priority { get; set; }

        public string ParsedPriority => Priority ?? "No Priority";

        public string ParsedStatus
        {
            get
            {
                var status = "";

                switch (Status)
                {
                    case "active":
                        status = "Active";
                        break;
                    case "waiting":
                        status = "Waiting on Customer";
                        break;
                    case "on-hold":
                        status = "On-Hold";
                        break;
                    case "solved":
                        status = "Solved";
                        break;
                    case "closed":
                        status = "Closed";
                        break;
                }

                return status;
            }
        }

        private readonly Dictionary<int, string> _inboxes = new Dictionary<int, string>
        {
            {880, "First Line"},
            {918, "Application Development"},
            {881, "Alerts"},
            {882, "Triage"},
            {0, "Undefined"}
        };


    }
}