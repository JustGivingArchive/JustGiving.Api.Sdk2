using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Charity.Response
{
    public class Charity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string LogoUrl { get; set; }

        public string ProfilePageUrl { get; set; }

        public string RegistrationNumber { get; set; }

        public string WebsiteUrl { get; set; }

        public int Id { get; set; }

        public string PageShortName { get; set; }

        public string SmsShortName { get; set; }

        public List<MobileAppeal> MobileAppeals { get; set; }

        public string EmailAddress { get; set; }
    }

    public class MobileAppeal
    {
        public string SmsCode { get; set; }
        public string Name { get; set; }
    }
}
