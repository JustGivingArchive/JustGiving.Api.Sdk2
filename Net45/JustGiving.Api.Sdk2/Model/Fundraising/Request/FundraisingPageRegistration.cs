using System;
using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Fundraising.Request
{
    public class FundraisingPageRegistration
    {
        public string Reference { get; set; }

        public int CharityId { get; set; }

        public int? EventId { get; set; }

        public string EventRef { get; set; }

        public string PageShortName { get; set; }

        public string PageTitle { get; set; }

        public ActivityType? ActivityType { get; set; }

        public decimal? TargetAmount { get; set; }

        public bool JustGivingOptIn { get; set; }

        public bool CharityOptIn { get; set; }

        public DateTime? EventDate { get; set; }

        public string EventName { get; set; }

        public string Attribution { get; set; }

        public bool CharityFunded { get; set; }

        public int? CauseId { get; set; }

        public int? CompanyAppealId { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public string PageStory { get; set; }

        public string PageSummaryWhat { get; set; }

        public string PageSummaryWhy { get; set; }

        public PageCustomCodes CustomCodes { get; set; }

        public PageTheme Theme { get; set; }

        public List<ImageInfo> Images { get; set; }

        public List<VideoInfo> Videos { get; set; }

        public RememberedPersonReference RememberedPersonReference { get; set; }
    }
}
