using System;

namespace JustGiving.Api.Sdk2.Model.Account.Response
{
    public class Rating
    {
        public string Intent { get; set; }
        public string Type { get; set; }
        public string ContentData { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}