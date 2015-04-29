using System;

namespace JustGiving.Api.Sdk2.Model.Fundraising.Response
{
    public class MicroblogUpdate
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Message { get; set; }
        public string Video { get; set; }
    }
}
