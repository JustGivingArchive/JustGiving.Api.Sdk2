using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Account.Response
{
    public class FundraisingPage
    {
        public int PageId { get; set; }
        public string PageTitle { get; set; }
        public string PageStatus { get; set; }
        public string PageShortName { get; set; }
        public decimal RaisedAmount { get; set; }
        public int DesignId { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal OfflineDonations { get; set; }
        public decimal TotalRaisedOnline { get; set; }
        public decimal GiftAidPlusSupplement { get; set; }
        public List<string> PageImages { get; set; }
        public string EventName { get; set; }
        public string Domain { get; set; }
        public InMemoryPerson InMemoryPerson { get; set; }
        public string CharityId { get; set; }
        public string SmsCode { get; set; }

        public FundraisingPage()
        {
            PageImages = new List<string>();
        }
    }
}
