using System;

namespace JustGiving.Api.Sdk2.Model.Event.Response
{
    public class Event
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string EventType { get; set; }
    }
}
