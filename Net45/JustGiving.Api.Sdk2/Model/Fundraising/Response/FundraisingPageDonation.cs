using System;

namespace JustGiving.Api.Sdk2.Model.Fundraising.Response
{
    public class FundraisingPageDonation
    {
        public decimal? Amount { get; set; }

        public int DonationId { get; set; }

        public string Image { get; set; }

        public bool HasImage { get; set; }

        public DateTime? DonationDate { get; set; }

        public string DonationRef { get; set; }

        public string DonorDisplayName { get; set; }

        public string Message { get; set; }

        public bool HasMessage { get; set; }

        public decimal? EstimatedTaxReclaim { get; set; }
    }
}