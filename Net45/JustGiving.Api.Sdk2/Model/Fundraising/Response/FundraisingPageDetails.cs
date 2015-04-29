using System;
using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Fundraising.Response
{
    public class FundraisingPageDetails
    {
        public string PageId { get; set; }
        public string ActivityId { get; set; }
        public string EventName { get; set; }
        public string CurrencySymbol { get; set; }
        public string PageShortName { get; set; }
        public FundraisingPageImage Image { get; set; }
        public string ImageCount { get; set; }
        public string Status { get; set; }
        public string PageCreatorName { get; set; }
        public string PageTitle { get; set; }
        public string ShowEventDate { get; set; }
        public DateTime ActivityDate { get; set; }
        public string ShowExpiryDate { get; set; }
        public DateTime PageExpiryDate { get; set; }
        public decimal? TargetAmount { get; set; }
        public string RaisedRatioPercent { get; set; }
        public string OfflineDonations { get; set; }
        public string TotalRaisedOnline { get; set; }
        public string TotalRaisedSms { get; set; }
        public string TotalRaised { get; set; }
        public string GiftAidPlusSupplement { get; set; }
        public FundraisingPageBranding Branding { get; set; }
        public FundraisingPageCharity Charity { get; set; }
        public FundraisingPageMedia Media { get; set; }
        public string RssUrl { get; set; }
        public string Story { get; set; }

        public string PageSummaryWhat { get; set; }
        public string PageSummaryWhy { get; set; }
        public string SmsCode { get; set; }
        public int? CompanyAppealId { get; set; }
        public string Attribution { get; set; }
        public PageCustomCodes CustomCodes { get; set; }
        public RememberedPersonSummary RememberedPersonSummary { get; set; }
        public List<FundraisingPageTeam> Teams { get; set; }
    }
}
