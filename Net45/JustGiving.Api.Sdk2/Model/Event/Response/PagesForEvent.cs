using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Event.Response
{
    public class PagesForEvent
    {
        public int EventId { get; set; }
        public int TotalFundraisingPages { get; set; }
        public int TotalPages { get; set; }
        public IList<FundraisingPageSummary> FundraisingPageSummaries { get; set; }
    }
}

