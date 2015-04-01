using System;

namespace JustGiving.Api.Sdk2.Model.Account.Request
{
    public class RateContentRequest
    {
        public string Intent { get; set; }
        public string Type { get; set; }
        public string ContentData { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
