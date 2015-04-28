using System.Collections.Generic;

namespace JustGiving.Api.Sdk2.Model.Donation.Response
{
    public class DonationsByReference
    {
        public List<Donation> Donations { get; set; }
        public Pagination Pagination { get; set; }
    }
}
