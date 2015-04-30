using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Project
{
    public class GlobalProject
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Need { get; set; }

        public string Activities { get; set; }

        public string Impact { get; set; }

        public string Status { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public bool IsActive { get; set; }

        public decimal TargetAmount { get; set; }

        public decimal TotalRaised { get; set; }

        public string OrganisationName { get; set; }

        public string OrganisationCity { get; set; }

        public string OrganisationCountry { get; set; }

        public string OrganisationUrl { get; set; }

        public string OrganisationLogoUrl { get; set; }

        public int CharityId { get; set; }

        public int CharityRevenueStreamId { get; set; }

        public string DonateUrl { get; set; }

        public List<GlobalGivingImage> Images { get; set; }

        public List<ProgressUpdate> ProgressUpdates { get; set; }

    }
}
