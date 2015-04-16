using System;
using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Charity.Response
{
    public class GetEventsByCharityIdResponse
    {
        public List<Event> Events { get; set; }
        public int Id { get; set; }
        public Pagination Pagination { get; set; }
    }
    
    public class Pagination
    {
        public int PageNumber { get; set; }
        public int PageSizeRequested { get; set; }
        public int pageSizeReturned { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }

    public class Event
    {
        public DateTime? CompletionDate { get; set; }
        public string Description { get; set; }
        public int EventType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int Id { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
    }

}
